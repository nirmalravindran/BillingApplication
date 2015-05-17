using System.Collections.Generic;
using System.Data;
using System.Linq;
using BillingApplication.Core.DataAccess;
using BillingApplication.Core.DomainModels;
using BillingApplication.Core.Helpers;
using BillingApplication.Core.Queries;
using ConcreteDataAccess = BillingApplication.Core.DataAccess.Concrete;
using System;

namespace BillingApplication.Core.Repositories.Concrete
{
    public class BillingRepository : IBillingRepository
    {
        #region IBillingRepository Members

        public IEnumerable<Product> GetProducts()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetProducts, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToProduct(row)).ToList();
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetCustomers, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToCustomer(row)).ToList();
            }
        }

        public IEnumerable<Cashier> GetCashiers()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetCashiers, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToCashier(row)).ToList();
            }
        }

        public IEnumerable<Cashier> GetCurrentCashiers()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetCurrentCashiers, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToCashier(row)).ToList();
            }
        }
        
        public void SaveBill(Bill bill)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var data = ConvertDomainModelToDataset(bill);
                    dataAccess.SaveData(data);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        public string GetBillNumber()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                return dataAccess.GetDataFromStoredProcedure("GETBILLNUMBER", null).Rows[0][0].ToString();
            }
        }

        public IEnumerable<Bill> GetBillForCashier(Guid cashierId, DateTime shiftStartTime)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var parameters = new Dictionary<string, object>
            {
                { "CASHIERID", cashierId },
                { "SHIFTSTARTDATETIME", shiftStartTime }
            };

                var data = dataAccess.GetData(BillingQueries.GetBillsForCashier, parameters);

                return RowToDomainModelConverter.ConvertToBill(data).ToList();
            }
        }

        public void UpdateSMSStatusForBill(Bill bill)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var data = ConvertDomainModelToDataset(bill);
                    data.Tables[0].Rows[0]["SMSSTATUS"] = string.Empty;
                    data.AcceptChanges();
                    data.Tables[0].Rows[0]["SMSSTATUS"] = bill.SMSStatus;
                    dataAccess.SaveData(data);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        private static DataSet ConvertDomainModelToDataset(Bill billDetails)
        {
            var data = new DataSet();

            data.Tables.Add(GetBillTable(billDetails));
            data.Tables.Add(GetBillItemsTable(billDetails));

            return data;
        }

        private static DataSet ConvertDomainModelToDataset(ProductReceived productReceived)
        {
            var data = new DataSet();
            data.Tables.Add(GetTankReceiptsTable(productReceived));

            return data;
        }

        private static DataTable GetTankReceiptsTable(ProductReceived productReceived)
        {
            var tankReceiptsTable = DomainModelToRowConverter.CreateTankReceiptsDataTable();
            var row = tankReceiptsTable.NewRow();
            DomainModelToRowConverter.ConvertToTankReceipt(productReceived, row);
            tankReceiptsTable.Rows.Add(row);

            return tankReceiptsTable;
 
        }

        private static DataSet ConvertDomainModelToDataset(Tank tank)
        {
            var data = new DataSet();
            data.Tables.Add(GetDailyDipTable(tank));

            return data;
        }

        private static DataTable GetDailyDipTable(Tank tank)
        {
            var dailyDipsTable = DomainModelToRowConverter.CreateDailyDipsDataTable();
            var row = dailyDipsTable.NewRow();
            DomainModelToRowConverter.ConvertToDailyDip(tank, row);
            dailyDipsTable.Rows.Add(row);

            return dailyDipsTable;

        }

        private static DataTable GetBillTable(Bill billDetails)
        {
            var billTable = DomainModelToRowConverter.CreateBillDataTable();
            var row = billTable.NewRow();
            DomainModelToRowConverter.ConvertToBill(billDetails, row);
            billTable.Rows.Add(row);

            return billTable;
        }

        private static DataTable GetBillItemsTable(Bill billDetails)
        {
            var billItemsTable = DomainModelToRowConverter.CreateBillItemDataTable();
            foreach (var billItem in billDetails.Products)
            {
                var row = billItemsTable.NewRow();
                DomainModelToRowConverter.ConvertToBillItem(billItem, row);
                billItemsTable.Rows.Add(row);
            }

            return billItemsTable;
        }

        public void UpdateBillWithCurrentCashier(Guid cashierId, string billNo)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var parameters = new Dictionary<string, object>
             {
                 { "CASHIER", cashierId},
                 { "BILLNO", billNo}
             };
                    dataAccess.ExecuteQuery(BillingQueries.UpdateBillWithCurrentCashier, parameters);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        public void RemoveCurrentCashierFromBill(string billNo)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var parameters = new Dictionary<string, object>
             {
                 { "BILLNO", billNo}
             };
                    dataAccess.ExecuteQuery(BillingQueries.RemoveCurrentCashierFromBill, parameters);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetAllProducts, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToProduct(row)).ToList();
            }
        }

        public void UpdatePriceForProduct(Guid productId, decimal price)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var parameters = new Dictionary<string, object>
             {
                 { "PRODUCTID", productId},
                 { "PRICE", price}
             };
                    dataAccess.ExecuteQuery(BillingQueries.UpdatePriceForProduct, parameters);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        public void SaveCashReceipt(CashReceipt cashReceipt)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var data = ConvertDomainModelToDataset(cashReceipt);
                    dataAccess.SaveData(data);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        private static DataSet ConvertDomainModelToDataset(CashReceipt cashReceipt)
        {
            var data = new DataSet();

            data.Tables.Add(GetCashReceiptTable(cashReceipt));
            
            return data;
        }

        private static DataTable GetCashReceiptTable(CashReceipt cashReceipt)
        {
            var cashReceiptTable = DomainModelToRowConverter.CreateCashReceiptDataTable();
            var row = cashReceiptTable.NewRow();
            DomainModelToRowConverter.ConvertToCashReceipt(cashReceipt, row);
            cashReceiptTable.Rows.Add(row);

            return cashReceiptTable;
        }

        public IEnumerable<CashReceipt> GetCashReceiptsForCashier(Guid cashierId, DateTime shiftStartTime)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var parameters = new Dictionary<string, object>
            {
                { "CASHIERID", cashierId },
                { "SHIFTSTARTDATETIME", shiftStartTime }
            };

                var data = dataAccess.GetData(CashReceiptQueries.GetCashReceiptsForCashier, parameters);

                return RowToDomainModelConverter.ConvertToCashReceipts(data).ToList();
            }
        }

        public bool DoesBillNumberExists(string billNumber)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var parameters = new Dictionary<string, object>
            {
                { "BILLNUMBER", billNumber }
            };

                var data = dataAccess.GetData(BillingQueries.GetBillWithBillNumber, parameters);

                return (data.Rows.Count > 0);
            }
        }

        public IEnumerable<Product> GetTankableProducts()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetTankableProducts, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToProduct(row)).ToList();
            }
        }

        public IEnumerable<Tank> GetTankForProduct(Guid ProductID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "PRODUCTID", ProductID }
            };

            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetTankForProduct, parameters);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToTank(row)).ToList();
            }
        }

        public void SaveProductReceived(ProductReceived productReceived)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var data = ConvertDomainModelToDataset(productReceived);
                    dataAccess.SaveData(data);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }

        public IEnumerable<Tank> GetAllTanks()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetAllTanks, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToTankWithCapacity(row)).ToList();
            }
        }

        public IEnumerable<Tank> GetPreviousVolume()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetPreviousVolume, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToTankWithPreviousVolume(row)).ToList();
            }
        }

        public IEnumerable<Tank> GetAllTankSales()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetAllTankSales, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToTankWithSales(row)).ToList();
            }
        }

        public IEnumerable<Tank> GetAllTankReceipts()
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                var data = dataAccess.GetData(BillingQueries.GetAllTankReceipts, null);

                return data.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToTankWithReceipts(row)).ToList();
            }
        }

        public void SaveDailyDip(Tank tank)
        {
            using (var dataAccess = new ConcreteDataAccess.DataAccess())
            {
                try
                {
                    dataAccess.BeginTransaction();
                    var data = ConvertDomainModelToDataset(tank);
                    dataAccess.SaveData(data);
                    dataAccess.Transaction.Commit();
                }
                catch (Exception e)
                {
                    dataAccess.Transaction.Rollback();
                    throw e;
                }
            }
        }


        #endregion
    }
}

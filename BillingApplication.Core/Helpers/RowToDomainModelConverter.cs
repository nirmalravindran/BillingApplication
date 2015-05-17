using System;
using System.Data;
using System.Linq;
using BillingApplication.Core.DomainModels;
using BillConstants = BillingApplication.Core.Constants;
using System.Collections.Generic;

namespace BillingApplication.Core.Helpers
{
    public static class RowToDomainModelConverter
    {
        public static Product ConvertToProduct(DataRow row)
        {
            return new Product
            {
                PrimaryKey = row.Field<Guid>(Constants.Product.Fields.PrimaryKey),
                Name = row.Field<string>(Constants.Product.Fields.Name),
                DimensionType = (DimensionType)Enum.Parse(typeof(DimensionType), row.Field<string>(Constants.Product.Fields.DimensionType)),
                Rate = row.Field<decimal>(Constants.Product.Fields.Rate),
                TaxClass = row.Field<string>(Constants.Product.Fields.TaxClass)
            };             
        }

        public static Customer ConvertToCustomer(DataRow row)
        {
            return new Customer
            {
                PrimaryKey = row.Field<Guid>(Constants.Customer.Fields.PrimaryKey),
                Name = row.Field<string>(Constants.Customer.Fields.Name),
                MobileNumber = row.Field<decimal?>(Constants.Customer.Fields.MobileNumber)            
            };
        }

        public static Cashier ConvertToCashier(DataRow row)
        {
            return new Cashier
            {
                PrimaryKey = row.Field<Guid>(Constants.Cashier.Fields.PrimaryKey),
                Name = row.Field<string>(Constants.Cashier.Fields.Name)
            };
        }

        public static Pump ConvertToPump(DataRow row)
        {
            return new Pump
            {
                PrimaryKey = row.Field<Guid>(BillConstants.Pump.Fields.PrimaryKey),
                Name = row.Field<string>(BillConstants.Pump.Fields.Name),
                Rate = row.Field<decimal>(BillConstants.Pump.Fields.Rate),
                InitialReading = row.Field<decimal>(BillConstants.Pump.Fields.InitialReading),
                CurrentReading = row.Field<decimal>(BillConstants.Pump.Fields.CurrentReading),
                LastUpdated = row.Field<DateTime>(BillConstants.Pump.Fields.LastUpdated),
                Cashier = ConvertToCashier(row),
                IsReadingIncremental = row.Field<bool>(BillConstants.Pump.Fields.IsReadingIncremental)
            };
        }

        public static Pump ConvertToPumpWithShiftDetails(DataRow row)
        {
            return new Pump
            {
                PrimaryKey = row.Field<Guid>(BillConstants.Pump.Fields.PrimaryKey),
                Name = row.Field<string>(BillConstants.Pump.Fields.Name),
                Rate = row.Field<decimal>(BillConstants.Pump.Fields.Rate),
                InitialReading = row.Field<decimal>(BillConstants.Pump.Fields.InitialReading),
                CurrentReading = row.Field<decimal>(BillConstants.Pump.Fields.CurrentReading),
                LastUpdated = row.Field<DateTime>(BillConstants.Pump.Fields.LastUpdated),
                Cashier = new Cashier { PrimaryKey = row.Field<Guid>("CURRENTCASHIER"), Name = row.Field<string>("CASHIERNAME") },
                PumpShiftDetails = new List<PumpShiftDetails> { ConvertToPumpShiftDetails(row) }
            };
        }

        private static PumpShiftDetails ConvertToPumpShiftDetails(DataRow row)
        {
            return new PumpShiftDetails
            {
                PrimaryKey = row.Field<Guid>(BillConstants.PumpShiftDetails.Fields.PrimaryKey),
                Pump = null,
                StartTime = row.Field<DateTime>(BillConstants.PumpShiftDetails.Fields.StartTime),
                EndTime = row.Field<DateTime>(BillConstants.PumpShiftDetails.Fields.EndTime),
                OpeningReading = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.OpeningReading),
                ClosingReading = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.ClosingReading),
                Testing = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.Testing),
                Sales = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.Sales),
                Rate = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.Rate),
                Amount = row.Field<decimal>(BillConstants.PumpShiftDetails.Fields.Amount),
                Cashier = new Cashier { PrimaryKey = row.Field<Guid>("CASHIER"), Name = row.Field<string>("CASHIERNAME") },
            };
        }
        

        public static IEnumerable<Bill> ConvertToBill(DataTable table)
        {
            var tableRowGroup = table.AsEnumerable().GroupBy(a => a.Field<Guid>(BillConstants.Bill.Fields.PrimaryKey));

            var billList = new List<Bill>();
            foreach (var rowGroup in tableRowGroup)
            {
                var mainRow = rowGroup.First();
                var bill = ConvertToBill(mainRow);
                bill.Products = rowGroup.Select(prod => ConvertToBillItem(prod)).ToList();
                billList.Add(bill);
            }

            return billList;
        }

        private static Bill ConvertToBill(DataRow row)
        {
            decimal tempNumber;
            return new Bill
            {
                BillDate = row.Field<DateTime>(BillConstants.Bill.Fields.BillDate),
                BillNumber = row.Field<string>(BillConstants.Bill.Fields.BillNumber),
                Cashier = new Cashier { PrimaryKey = row.Field<Guid>("CASHIER") },
                CustomerName = row.Field<string>(BillConstants.Bill.Fields.CustomerName),
                Number = decimal.TryParse(row.Field<string>(BillConstants.Bill.Fields.Number), out tempNumber) ? tempNumber : (decimal?)null,
                Odometer = row.Field<string>(BillConstants.Bill.Fields.Odometer),
                PrimaryKey = row.Field<Guid>(BillConstants.Bill.Fields.PrimaryKey),
                SMSStatus = row.Field<string>(BillConstants.Bill.Fields.SMSStatus),
                TotalAmount = row.Field<decimal>(BillConstants.Bill.Fields.TotalAmount),
                VehicleNumber = row.Field<string>(BillConstants.Bill.Fields.VehicleNumber)
            };
        }

        private static BillItem ConvertToBillItem(DataRow row)
        {
            return new BillItem
            {
                Product = new Product { Name = row.Field<string>(BillConstants.Product.Fields.Name), TaxClass = row.Field<string>(BillConstants.Product.Fields.TaxClass), Rate = row.Field<Decimal>(BillConstants.Product.Fields.Rate) },
                Amount = row.Field<Decimal>(BillConstants.BillItem.Fields.Amount),
                Quantity = row.Field<Decimal>(BillConstants.BillItem.Fields.Quantity)
            };
        }

        public static IEnumerable<CashReceipt> ConvertToCashReceipts(DataTable table)
        {
            var CashReceiptList = new List<CashReceipt>();
            foreach (DataRow row in table.Rows)
            {
                var cashReceipt = ConvertToCashReceipt(row);
                CashReceiptList.Add(cashReceipt);
            }

            return CashReceiptList;
        }
        private static CashReceipt ConvertToCashReceipt(DataRow row)
        {
            return new CashReceipt
            {
                PrimaryKey = row.Field<Guid>(BillConstants.CashReceipt.Fields.PrimaryKey),
                Amount = row.Field<Decimal>(BillConstants.CashReceipt.Fields.Amount),
                CashierID = row.Field<Guid>(BillConstants.CashReceipt.Fields.CashierID),
                Notes = row.Field<string>(BillConstants.CashReceipt.Fields.Notes),
                ReceiptDate = row.Field<DateTime>(BillConstants.CashReceipt.Fields.ReceiptDate),
            };
        }

        public static Tank ConvertToTank(DataRow row)
        {
            return new Tank
            {
                PrimaryKey = row.Field<Guid>(Constants.Tank.Fields.PrimaryKey),
                Name = row.Field<string>(Constants.Tank.Fields.Name)
            };
        }

        public static Tank ConvertToTankWithCapacity(DataRow row)
        {
            return new Tank
            {
                PrimaryKey = row.Field<Guid>(Constants.Tank.Fields.PrimaryKey),
                Name = row.Field<string>(Constants.Tank.Fields.Name),
                Capacity = row.Field<decimal>(Constants.Tank.Fields.Capacity),
                Product = row.Field<Guid>(Constants.Tank.Fields.Product)
            };
        }

        public static Tank ConvertToTankWithPreviousVolume(DataRow row)
        {
            return new Tank
            {
                PrimaryKey = row.Field<Guid>("TANK"),
                PreviousVolume = row.Field<decimal>("VOLUME")
            };
        }

        public static Tank ConvertToTankWithSales(DataRow row)
        {
            return new Tank
            {
                PrimaryKey = row.Field<Guid>(Constants.Tank.Fields.PrimaryKey),
                Sales = row.Field<decimal>("SALES")
            };
        }

        public static Tank ConvertToTankWithReceipts(DataRow row)
        {
            return new Tank
            {
                PrimaryKey = row.Field<Guid>(Constants.Tank.Fields.PrimaryKey),
                Receipt = row.Field<decimal>("RECEIPTS")
            };
        }

    }
}

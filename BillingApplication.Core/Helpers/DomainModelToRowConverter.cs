using System;
using System.Data;
using BillingApplication.Core.DomainModels;
using BillConstants = BillingApplication.Core.Constants;

namespace BillingApplication.Core.Helpers
{
    public static class DomainModelToRowConverter
    {
        public static void ConvertToBill(Bill billDetails, DataRow row)
        {
            row.SetField(BillConstants.Bill.Fields.PrimaryKey, billDetails.PrimaryKey);
            row.SetField(BillConstants.Bill.Fields.CustomerName, billDetails.CustomerName);
            row.SetField(BillConstants.Bill.Fields.BillNumber, billDetails.BillNumber);
            row.SetField(BillConstants.Bill.Fields.Number, billDetails.Number);
            row.SetField(BillConstants.Bill.Fields.VehicleNumber, string.IsNullOrEmpty(billDetails.VehicleNumber.Trim())? billDetails.BillNumber : billDetails.VehicleNumber);
            row.SetField(BillConstants.Bill.Fields.BillDate, billDetails.BillDate);
            row.SetField(BillConstants.Bill.Fields.Odometer, billDetails.Odometer);
            row.SetField(BillConstants.Bill.Fields.TotalAmount, billDetails.TotalAmount);
            row.SetField(BillConstants.Bill.Fields.SMSStatus, billDetails.SMSStatus);
            row.SetField(BillConstants.Bill.Fields.Cashier, billDetails.Cashier.PrimaryKey);
        }

        public static DataTable CreateBillDataTable()
        {
            var billTable = new DataTable(Constants.Bill.TableName);

            billTable.Columns.Add(BillConstants.Bill.Fields.PrimaryKey, typeof(Guid));
            billTable.Columns.Add(BillConstants.Bill.Fields.CustomerName, typeof(string));
            billTable.Columns.Add(BillConstants.Bill.Fields.BillNumber, typeof(string));
            billTable.Columns.Add(BillConstants.Bill.Fields.Number, typeof(decimal));
            billTable.Columns.Add(BillConstants.Bill.Fields.VehicleNumber, typeof(string));
            billTable.Columns.Add(BillConstants.Bill.Fields.BillDate, typeof(DateTime));
            billTable.Columns.Add(BillConstants.Bill.Fields.Odometer, typeof(string));
            billTable.Columns.Add(BillConstants.Bill.Fields.TotalAmount, typeof(decimal));
            billTable.Columns.Add(BillConstants.Bill.Fields.SMSStatus, typeof(string));
            billTable.Columns.Add(BillConstants.Bill.Fields.Cashier, typeof(Guid));

            return billTable;
        }

        public static void ConvertToBillItem(BillItem billItems, DataRow row)
        {
            row.SetField(BillConstants.BillItem.Fields.PrimaryKey, billItems.PrimaryKey);
            row.SetField(BillConstants.BillItem.Fields.ForeignKey, billItems.ForeignKey);
            row.SetField(BillConstants.BillItem.Fields.Product, billItems.Product.PrimaryKey);
            row.SetField(BillConstants.BillItem.Fields.Quantity, billItems.Quantity);
            row.SetField(BillConstants.BillItem.Fields.Amount, billItems.Amount);
            row.SetField(BillConstants.BillItem.Fields.Rate, billItems.Product.Rate);
        }

        public static DataTable CreateBillItemDataTable()
        {
            var billItemTable = new DataTable(Constants.BillItem.TableName);

            billItemTable.Columns.Add(BillConstants.BillItem.Fields.PrimaryKey, typeof(Guid));
            billItemTable.Columns.Add(BillConstants.BillItem.Fields.ForeignKey, typeof(Guid));
            billItemTable.Columns.Add(BillConstants.BillItem.Fields.Product, typeof(Guid));
            billItemTable.Columns.Add(BillConstants.BillItem.Fields.Quantity, typeof(decimal));
            billItemTable.Columns.Add(BillConstants.BillItem.Fields.Amount, typeof(decimal));
            billItemTable.Columns.Add(BillConstants.BillItem.Fields.Rate, typeof(decimal));

            return billItemTable;
        }

        public static DataTable CreatePumpTable()
        {
            var pumpTable = new DataTable(Constants.Pump.TableName);
            pumpTable.Columns.Add(BillConstants.Pump.Fields.PrimaryKey, typeof(Guid));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.Name, typeof(string));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.Rate, typeof(Decimal));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.InitialReading, typeof(decimal));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.CurrentReading, typeof(decimal));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.Cashier, typeof(Guid));
            pumpTable.Columns.Add(BillConstants.Pump.Fields.LastUpdated, typeof(DateTime));

            return pumpTable;
        }

        public static void ConvertPumpToRow(Pump pump, DataRow row)
        {
            row.SetField(BillConstants.Pump.Fields.PrimaryKey, pump.PrimaryKey);
            row.SetField(BillConstants.Pump.Fields.Name, pump.Name);
            row.SetField(BillConstants.Pump.Fields.Rate, pump.Rate);
            row.SetField(BillConstants.Pump.Fields.InitialReading, pump.InitialReading);
            row.SetField(BillConstants.Pump.Fields.CurrentReading, pump.CurrentReading);
            row.SetField(BillConstants.Pump.Fields.Cashier, pump.Cashier.PrimaryKey);
            row.SetField(BillConstants.Pump.Fields.LastUpdated, DateTime.Now);
        }

        public static void UpdateCurrentCashier(Pump pump, DataRow row)
        {
            row.SetField(BillConstants.Pump.Fields.Cashier, pump.Cashier.PrimaryKey);
        }

        public static DataTable CreatePumpShiftDetailsTable()
        {
            var pumpShiftTable = new DataTable(Constants.PumpShiftDetails.TableName);
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Amount, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Cashier, typeof(Guid));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.ClosingReading, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.EndTime, typeof(DateTime));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.OpeningReading, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.PrimaryKey, typeof(Guid));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Pump, typeof(Guid));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Rate, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Sales, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.StartTime, typeof(DateTime));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.Testing, typeof(decimal));
            pumpShiftTable.Columns.Add(BillConstants.PumpShiftDetails.Fields.ShiftCloseComplete, typeof(bool));

            return pumpShiftTable;
        }

        public static void ConvertPumpShiftDetailsToRow(PumpShiftDetails pumpShiftDetails, DataRow row, DateTime timeToBeSaved)
        {
            row.SetField(BillConstants.PumpShiftDetails.Fields.Amount, pumpShiftDetails.Amount);
            row.SetField(BillConstants.PumpShiftDetails.Fields.Cashier, pumpShiftDetails.Cashier.PrimaryKey);
            row.SetField(BillConstants.PumpShiftDetails.Fields.ClosingReading, pumpShiftDetails.ClosingReading);
            row.SetField(BillConstants.PumpShiftDetails.Fields.EndTime, timeToBeSaved );
            row.SetField(BillConstants.PumpShiftDetails.Fields.OpeningReading, pumpShiftDetails.OpeningReading);
            row.SetField(BillConstants.PumpShiftDetails.Fields.PrimaryKey, Guid.NewGuid());
            row.SetField(BillConstants.PumpShiftDetails.Fields.Pump, pumpShiftDetails.Pump.PrimaryKey);
            row.SetField(BillConstants.PumpShiftDetails.Fields.Rate, pumpShiftDetails.Rate);
            row.SetField(BillConstants.PumpShiftDetails.Fields.Sales, pumpShiftDetails.Sales);
            row.SetField(BillConstants.PumpShiftDetails.Fields.StartTime, pumpShiftDetails.StartTime);
            row.SetField(BillConstants.PumpShiftDetails.Fields.Testing, pumpShiftDetails.Testing);
            row.SetField(BillConstants.PumpShiftDetails.Fields.ShiftCloseComplete, pumpShiftDetails.ShiftComplete);
        }

        public static DataTable CreateCashReceiptDataTable()
        {
            var CashReceiptTable = new DataTable(Constants.CashReceipt.TableName);

            CashReceiptTable.Columns.Add(BillConstants.CashReceipt.Fields.PrimaryKey, typeof(Guid));
            CashReceiptTable.Columns.Add(BillConstants.CashReceipt.Fields.Amount, typeof(decimal));
            CashReceiptTable.Columns.Add(BillConstants.CashReceipt.Fields.CashierID, typeof(Guid));
            CashReceiptTable.Columns.Add(BillConstants.CashReceipt.Fields.Notes, typeof(string));
            CashReceiptTable.Columns.Add(BillConstants.CashReceipt.Fields.ReceiptDate, typeof(DateTime));
            
            return CashReceiptTable;
        }

        public static void ConvertToCashReceipt(CashReceipt CashReceiptDetails, DataRow row)
        {
            row.SetField(BillConstants.CashReceipt.Fields.PrimaryKey, CashReceiptDetails.PrimaryKey);
            row.SetField(BillConstants.CashReceipt.Fields.CashierID, CashReceiptDetails.CashierID);
            row.SetField(BillConstants.CashReceipt.Fields.ReceiptDate, CashReceiptDetails.ReceiptDate);
            row.SetField(BillConstants.CashReceipt.Fields.Notes, CashReceiptDetails.Notes);
            row.SetField(BillConstants.CashReceipt.Fields.Amount, CashReceiptDetails.Amount);
        }

        public static DataTable CreateTankReceiptsDataTable()
        {
            var TankReceiptTable = new DataTable(Constants.TankReceipts.TableName);

            TankReceiptTable.Columns.Add(BillConstants.TankReceipts.Fields.PrimaryKey, typeof(Guid));
            TankReceiptTable.Columns.Add(BillConstants.TankReceipts.Fields.InvoiceNumber, typeof(decimal));
            TankReceiptTable.Columns.Add(BillConstants.TankReceipts.Fields.Tank, typeof(Guid));
            TankReceiptTable.Columns.Add(BillConstants.TankReceipts.Fields.Quantity, typeof(decimal));
            TankReceiptTable.Columns.Add(BillConstants.TankReceipts.Fields.Date, typeof(DateTime));

            return TankReceiptTable;
        }

        public static DataTable CreateDailyDipsDataTable()
        {
            var TankReceiptTable = new DataTable("DAILYDIP");

            TankReceiptTable.Columns.Add("DAILYDIP_ID", typeof(Guid));
            TankReceiptTable.Columns.Add("TANK", typeof(Guid));
            TankReceiptTable.Columns.Add("DIP", typeof(decimal));
            TankReceiptTable.Columns.Add("WATERDIP", typeof(decimal));
            TankReceiptTable.Columns.Add("VOLUME", typeof(decimal));
            TankReceiptTable.Columns.Add("RECEIPT", typeof(decimal));
            TankReceiptTable.Columns.Add("SALES", typeof(decimal));
            TankReceiptTable.Columns.Add("DIFFERENCE", typeof(decimal));
            TankReceiptTable.Columns.Add("DATE", typeof(DateTime));

            return TankReceiptTable;
        }

        public static void ConvertToTankReceipt(ProductReceived productReceivedDetails, DataRow row)
        {
            row.SetField(BillConstants.TankReceipts.Fields.PrimaryKey, productReceivedDetails.PrimaryKey);
            row.SetField(BillConstants.TankReceipts.Fields.Tank, productReceivedDetails.Tank);
            row.SetField(BillConstants.TankReceipts.Fields.Date, productReceivedDetails.Date);
            row.SetField(BillConstants.TankReceipts.Fields.InvoiceNumber, productReceivedDetails.InvoiceNumber);
            row.SetField(BillConstants.TankReceipts.Fields.Quantity, productReceivedDetails.Quantity);
        }

        public static void ConvertToDailyDip(Tank tank, DataRow row)
        {
            row.SetField("DAILYDIP_ID", tank.DailyDipPrimaryKey);
            row.SetField("TANK", tank.PrimaryKey);
            row.SetField("DIP", tank.Dip);
            row.SetField("WATERDIP", tank.WaterDip);
            row.SetField("VOLUME", tank.CurrentVolume);
            row.SetField("RECEIPT", tank.Receipt);
            row.SetField("SALES", tank.Sales);
            row.SetField("DIFFERENCE", tank.Difference);
            row.SetField("DATE", tank.Date);
        }
    }
}
                       
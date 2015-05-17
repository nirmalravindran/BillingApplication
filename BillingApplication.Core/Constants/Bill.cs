
namespace BillingApplication.Core.Constants
{
    public static class Bill
    {
        public const string TableName = "BILLS";

        public static class Fields
        {
            public const string CustomerName = "CUSTOMERNAME";
            public const string BillNumber = "BILLNO";
            public const string Number = "NUMBER";
            public const string VehicleNumber = "VEHICLENO";
            public const string BillDate = "BILLDATE";
            public const string Odometer = "ODOMETER";
            public const string TotalAmount = "TOTALAMOUNT";
            public const string SMSStatus = "SMSSTATUS";
            public const string Cashier = "CASHIER";
            public const string PrimaryKey = "BILLS_ID";
        }
    }
}

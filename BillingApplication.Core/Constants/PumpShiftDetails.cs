
namespace BillingApplication.Core.Constants
{
    public static class PumpShiftDetails
    {
        public const string TableName = "PUMPSHIFTDETAILS";

        public static class Fields
        {
            public const string PrimaryKey = "PUMPSHIFTDETAILS_ID";
            public const string Pump = "PUMPS_ID";
            public const string StartTime = "STARTTIME";
            public const string EndTime = "ENDTIME";
            public const string OpeningReading = "OPENINGREADING";
            public const string ClosingReading = "CLOSINGREADING";
            public const string Testing = "TESTING";
            public const string Sales = "SALES";
            public const string Rate = "RATE";
            public const string Amount = "AMOUNT";
            public const string Cashier = "CASHIER";
            public const string ShiftCloseComplete = "SHIFTCLOSECOMPLETE";
        }
    }
}

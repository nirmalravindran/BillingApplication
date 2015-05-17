
namespace BillingApplication.Core.Constants
{
    public static class CashReceipt
    {
        public const string TableName = "CASHRECEIPTS";

        public static class Fields
        {
            public const string ReceiptDate = "RECEIPTDATE";
            public const string Notes = "Notes";
            public const string Amount = "AMOUNT";
            public const string CashierID = "CASHIERID";
            public const string PrimaryKey = "CASHRECEIPTS_ID";
        }
    }
}

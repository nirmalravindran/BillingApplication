
namespace BillingApplication.Core.Constants
{
    public static class TankReceipts
    {
        public const string TableName = "TANKRECEIPTS";

        public static class Fields
        {
            public const string PrimaryKey = "TANKRECEIPTS_ID";
            public const string Tank = "TANK";
            public const string InvoiceNumber = "INVOICENUMBER";
            public const string Date = "DATE";
            public const string Quantity = "QUANTITY";

        }
    }
}

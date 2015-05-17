
namespace BillingApplication.Core.Constants
{
    public static class BillItem
    {
        public const string TableName = "BILLITEMS";

        public static class Fields
        {
            public const string Product = "PRODUCT";
            public const string Quantity = "QUANTITY";
            public const string Amount = "AMOUNT";
            public const string PrimaryKey = "BILLITEMS_ID";
            public const string ForeignKey = "BILLS_ID";
            public const string Rate = "RATE";
        }
    }
}

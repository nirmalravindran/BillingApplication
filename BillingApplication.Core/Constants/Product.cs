
using System;
namespace BillingApplication.Core.Constants
{
    public static class Product
    {
        public const string TableName = "PRODUCTS";

        public static class Fields
        {
            public const string Name = "NAME";
            public const string DimensionType = "DIMENSIONTYPE";
            public const string Rate = "RATE";
            public const string TaxClass = "TAXCLASS";
            public const string PrimaryKey = "PRODUCTS_ID";
        }
    }
}

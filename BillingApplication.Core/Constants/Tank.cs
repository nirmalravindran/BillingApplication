using System;

namespace BillingApplication.Core.Constants
{
    public static class Tank
    {
        public const string TableName = "TANKS";

        public static class Fields
        {
            public const string Name = "TANKNAME";
            public const string PrimaryKey = "TANKS_ID";
            public const string Capacity = "TOTALCAPACITY";
            public const string Product = "PRODUCT";
        }
    }
}

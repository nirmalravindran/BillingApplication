using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication.Core.Constants
{
    public static class Cashier
    {
        public const string TableName = "CASHIERS";

        public static class Fields
        {
            public const string Name = "NAME";
            public const string PrimaryKey = "CASHIERS_ID";
        }
    }
}

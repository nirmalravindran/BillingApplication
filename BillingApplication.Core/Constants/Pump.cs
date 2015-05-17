using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication.Core.Constants
{
    public static class Pump
    {
        public const string TableName = "PUMPS";
        public static class Fields
        {
            public const string PrimaryKey = "PUMPS_ID";
            public const string Name = "NAME";
            public const string Rate = "RATE";
            public const string InitialReading = "INITIALREADING";
            public const string CurrentReading = "CURRENTREADING";
            public const string Cashier = "CASHIER";
            public const string LastUpdated = "LASTUPDATED";
            public const string IsReadingIncremental = "ISREADINGINCREMENTAL";
        }

    }
}

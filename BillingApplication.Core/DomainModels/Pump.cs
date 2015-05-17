using System;
using System.Collections.Generic;

namespace BillingApplication.Core.DomainModels
{
    public class Pump
    {
        public Guid PrimaryKey { get; set; }
        public string Name { get; set; }
        public decimal InitialReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal Rate { get; set; }
        public Cashier Cashier { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<PumpShiftDetails> PumpShiftDetails { get; set; }
        public bool IsReadingIncremental { get; set; }
    }
 
}

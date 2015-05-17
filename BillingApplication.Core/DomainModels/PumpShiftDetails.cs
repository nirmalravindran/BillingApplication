using System;

namespace BillingApplication.Core.DomainModels
{
    public class PumpShiftDetails
    {
        public Guid PrimaryKey { get; set; }
        public Pump Pump { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal OpeningReading { get; set; }
        public decimal ClosingReading { get; set; }
        public decimal Testing { get; set; }
        public decimal Sales{ get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public Cashier Cashier { get; set; }
        public bool ShiftComplete { get; set; }
    }
}

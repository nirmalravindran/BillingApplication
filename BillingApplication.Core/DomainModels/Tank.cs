using System;

namespace BillingApplication.Core.DomainModels
{
    public class Tank
    {
        public Guid PrimaryKey { get; set; }
        public string Name { get; set; }
        public decimal Capacity { get; set; }
        public decimal Receipt { get; set; }
        public decimal Sales { get; set; }
        public decimal PreviousVolume { get; set; }
        public decimal CurrentVolume { get; set; }
        public decimal Difference { get; set; }
        public decimal Dip { get; set; }
        public decimal WaterDip { get; set; }
        public Guid Product { get; set; }
        public Guid DailyDipPrimaryKey { get; set; }
        public DateTime Date { get; set; }
    }
}

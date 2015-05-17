using System;

namespace BillingApplication.Core.DomainModels
{
    public class Product
    {
        public Guid PrimaryKey { get; set; }
        public string Name { get; set; }
        public DimensionType DimensionType { get; set; }
        public decimal Rate { get; set; }
        public string TaxClass { get; set; }
    }

    public enum DimensionType
    {
        LITRES,
        NOS
    }
}

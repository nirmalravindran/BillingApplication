using System;

namespace BillingApplication.Core.DomainModels
{
    public class Customer
    {
        public Guid PrimaryKey { get; set; }
        public string Name { get; set; }
        public decimal? MobileNumber { get; set; }
    }
}

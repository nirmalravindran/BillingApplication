using System;

namespace BillingApplication.Core.DomainModels
{
    public class BillItem
    {
        public Guid PrimaryKey { get; set; }
        public Guid ForeignKey { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}

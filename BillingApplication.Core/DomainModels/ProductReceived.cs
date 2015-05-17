using System;

namespace BillingApplication.Core.DomainModels
{
    public class ProductReceived
    {
        public Guid PrimaryKey { get; set; }
        public Guid Tank { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}

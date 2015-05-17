using System;

namespace BillingApplication.Core.DomainModels
{
    public class CashReceipt
    {
        public Guid PrimaryKey { get; set; }
        public Guid CashierID { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BillingApplication.Core.DomainModels
{
    public class Bill
    {
        public Guid PrimaryKey { get; set; }
        public string CustomerName {get;set;}
        public string BillNumber { get; set; }
        public decimal? Number { get; set; }
        public string VehicleNumber { get; set; }
        public DateTime BillDate { get; set; }
        public string Odometer { get; set; }
        public List<BillItem> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string SMSStatus { get; set; }
        public Cashier Cashier { get; set; }
    }

}

using System.Collections.Generic;
using System.Linq;
using BillingApplication.Core.DomainModels;
using BillingApplication.Core.Repositories;
using BillingApplication.Core.Repositories.Concrete;

namespace BillingApplication.Core.Services.Concrete
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;

        public BillingService()
        {
            _billingRepository = new BillingRepository();
        }

        public string GetSMSText(Bill bill)
        {
            var item = GetProductDetails(bill.Products);
            return "Veh.no. " + bill.VehicleNumber + " fuelled with " + item.Quantity + " ltrs of " + item.Product.Name + " at " + bill.Odometer + " km on " + bill.BillDate.ToString() + " for Rs." + item.Amount;
        }

        private BillItem GetProductDetails(List<BillItem> list)
        {
            return list.Where(a => a.Product.Name.ToUpper() == "PETROL" || a.Product.Name.ToUpper() == "DIESEL").First();
        }
    }
}

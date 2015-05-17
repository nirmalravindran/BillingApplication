using System.Collections.Generic;
using BillingApplication.Core.DomainModels;
using System;

namespace BillingApplication.Core.Repositories
{
    public interface IBillingRepository
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Customer> GetCustomers();

        IEnumerable<Cashier> GetCashiers();

        IEnumerable<Bill> GetBillForCashier(Guid cashierId, DateTime shiftStartTime);

        string GetBillNumber();

        void SaveBill(Bill bill);
    }
}

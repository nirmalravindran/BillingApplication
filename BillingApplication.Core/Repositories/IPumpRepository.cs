using System;
using System.Collections.Generic;
using BillingApplication.Core.DomainModels;

namespace BillingApplication.Core.Repositories
{
    public interface IPumpRepository
    {
        IEnumerable<Pump> GetPumpForCashier(Guid cashierId);
        void SavePump(Pump pump);
        void SavePumpShiftDetails(IEnumerable<Pump> pump, Guid leavingCashier);
        Report UpdateShiftCloseComplete(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee, Expenses[] expenses);
        void AddProducts(Guid ProductID, int Count);
    }
}

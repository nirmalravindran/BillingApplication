using System.Collections.Generic;
using BillingApplication.Core.DomainModels;

namespace BillingApplication.Core.Services
{
    public interface IBillingService
    {
        string GetSMSText(Bill bill);
    }
}

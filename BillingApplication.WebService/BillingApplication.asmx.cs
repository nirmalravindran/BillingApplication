using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Services;
using BillingApplication.Core.DomainModels;
using BillingApplication.Core.Repositories.Concrete;
using BillingApplication.Core.Services.Concrete;
using System.Linq;
using System;
using BillingApplication.Core.Reporting;

namespace BillingApplication.WebService
{
    /// <summary>
    /// Summary description for BillingApplication
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BillingApplication : System.Web.Services.WebService
    {
        [WebMethod]
        public Product[] GetProducts()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetProducts().ToArray();
        }

        [WebMethod]
        public Customer[] GetCustomers()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetCustomers().ToArray();
        }

        [WebMethod]
        public Cashier[] GetCashiers()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetCashiers().ToArray();
        }

        [WebMethod]
        public Cashier[] GetCurrentCashiers()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetCurrentCashiers().ToArray();
        }

        [WebMethod]
        public void SaveBill(Bill bill)
        {
            var billingRepository = new BillingRepository();
            billingRepository.SaveBill(bill);
        }

        [WebMethod]
        public string GetBillNumber()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetBillNumber();
        }

        [WebMethod]
        public string SendSMS(Bill bill)
        {
            if (bill.Number.HasValue)
            {
                var billingService = new BillingService();
                var smsText = billingService.GetSMSText(bill);

                string strUrl = string.Format("http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=praveen1109@gmail.com:password&senderID=ARUNAA&receipientno={0}&msgtxt={1}&state=4", bill.Number, smsText);
                var request = HttpWebRequest.Create(strUrl);
                WebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                    return "Error in sending SMS";
                }
                var s = (Stream)response.GetResponseStream();
                var readStream = new StreamReader(s);
                var status = readStream.ReadToEnd();

                response.Close();
                s.Close();
                readStream.Close();

                return status;
            }
            return "No mobile number defined";
        }

        [WebMethod]
        public string SendSMStoDealer(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                string strUrl = string.Format("http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=praveen1109@gmail.com:password&senderID=ARUNAA&receipientno={0}&msgtxt={1}&state=4", "9380533374,9943022675", message);
                var request = HttpWebRequest.Create(strUrl);
                WebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                    return "Error in sending SMS";
                }
                var s = (Stream)response.GetResponseStream();
                var readStream = new StreamReader(s);
                var status = readStream.ReadToEnd();

                response.Close();
                s.Close();
                readStream.Close();

                return status;
            }
            return "No mobile number defined";
        }

        [WebMethod]
        public void UpdateSMSStatusForBill(Bill bill)
        {
            var billingRepository = new BillingRepository();
            billingRepository.UpdateSMSStatusForBill(bill);
        }  

        [WebMethod]
        public void SavePump(Pump pump)
        {
            var pumpRepository = new PumpRepository();
            pumpRepository.SavePump(pump);
        }

        [WebMethod]
        public void SavePumps(Pump[] pumps, Guid leavingCashier)
        {
            var pumpRepository = new PumpRepository();
            pumpRepository.SavePumpShiftDetails(pumps, leavingCashier);
        }
        
        [WebMethod]
        public Pump[] GetPumpsHandledByEmployee(Guid cashierId)
        {
            var pumpRepository = new PumpRepository();
            
            return pumpRepository.GetPumpForCashier(cashierId).ToArray();
        }

        /// <summary>
        /// TO DO: Bharath - Take whatever parameter necessary as input
        /// </summary>
        [WebMethod]
        public void SaveShift(PumpShiftDetails pumpShiftDetails)
        {

        }

        /// <summary>
        /// TO DO: Bharath
        /// </summary>
        /// <param name="cashierId"></param>
        /// <returns></returns>
        [WebMethod]
        public Bill[] GetEmployeeBills(Guid cashierId, DateTime shiftStartTime)
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetBillForCashier(cashierId, shiftStartTime).ToArray();
        }

        /// <summary>
        /// Updates shift close filed of pump shift details and writes to shift close report
        /// </summary>                
        [WebMethod]
        public Report UpdateShiftCloseAndGenerateReport(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee, Expenses[] expenses)
        {
            var pumpRepository = new PumpRepository();
            return pumpRepository.UpdateShiftCloseComplete(pumps, bills, cashPaidByEmployee, expenses);            
        }

        /// <summary>
        /// Add to products count
        /// </summary>                
        [WebMethod]
        public void AddProducts(Guid productID, int count)
        {
            var pumpRepository = new PumpRepository();
            pumpRepository.AddProducts(productID, count);
        }

        /// <summary>
        /// Associate the given cashier to the given Bill
        /// </summary>                
        [WebMethod]
        public void UpdateBillWithCurrentCashier(Guid cashierId, string billNo)
        {
            var billRepository = new BillingRepository();
            billRepository.UpdateBillWithCurrentCashier(cashierId, billNo);
        }

        /// <summary>
        /// Remove cashier from the given bill
        /// </summary>                
        [WebMethod]
        public void RemoveCurrentCashierFromBill(string billNo)
        {
            var billRepository = new BillingRepository();
            billRepository.RemoveCurrentCashierFromBill(billNo);
        }

        [WebMethod]
        public Product[] GetAllProducts()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetAllProducts().ToArray();
        }

        /// <summary>
        /// Update the rate for the given product.
        /// </summary>                
        [WebMethod]
        public void UpdatePriceForProduct(Guid productId, decimal price)
        {
            var billRepository = new BillingRepository();
            billRepository.UpdatePriceForProduct(productId, price);
        }

        [WebMethod]
        public void SaveCashReceipt(CashReceipt cashReceipt)
        {
            var billingRepository = new BillingRepository();
            billingRepository.SaveCashReceipt(cashReceipt);
        }

        [WebMethod]
        public CashReceipt[] GetEmployeeCashReceipts(Guid cashierId, DateTime shiftStartTime)
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetCashReceiptsForCashier(cashierId, shiftStartTime).ToArray();
        }

        [WebMethod]
        public bool DoesBillNumberExists(string billNumber)
        {
            var billingRepository = new BillingRepository();
            return billingRepository.DoesBillNumberExists(billNumber);
        }

        [WebMethod]
        public Product[] GetTankableProducts()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetTankableProducts().ToArray();
        }

        [WebMethod]
        public Tank[] GetTanksForProduct(Guid productID)
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetTankForProduct(productID).ToArray();
        }

        [WebMethod]
        public void SaveProductReceived(ProductReceived productReceived)
        {
            var billingRepository = new BillingRepository();
            billingRepository.SaveProductReceived(productReceived);
        }

        [WebMethod]
        public Tank[] GetAllTanks()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetAllTanks().ToArray();
        }

        [WebMethod]
        public Tank[] GetPreviousVolumeForTanks()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetPreviousVolume().ToArray();
        }

        [WebMethod]
        public Tank[] GetSalesForTanks()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetAllTankSales().ToArray();
        }

        [WebMethod]
        public Tank[] GetReceiptsForTanks()
        {
            var billingRepository = new BillingRepository();
            return billingRepository.GetAllTankReceipts().ToArray();
        }

        [WebMethod]
        public void SaveDailyDip(Tank tank)
        {
            var billingRepository = new BillingRepository();
            billingRepository.SaveDailyDip(tank);
        }

    }
}

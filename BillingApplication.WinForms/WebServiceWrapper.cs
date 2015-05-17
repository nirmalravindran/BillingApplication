using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public class WebServiceWrapper : IBillingServiceWrapper
    {

        #region IBillingServiceWrapper Members

        public Product[] GetProducts()
        {
            throw new NotImplementedException();
        }

        public Customer[] GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Cashier[] GetCashiers()
        {
            throw new NotImplementedException();
        }

        public Cashier[] GetCurrentCashiers()
        {
            throw new NotImplementedException();
        }

        public void SaveBill(Bill bill)
        {
            throw new NotImplementedException();
        }

        public string GetBillNumber()
        {
            throw new NotImplementedException();
        }

        public string SendSMS(Bill bill)
        {
            throw new NotImplementedException();
        }

        public void UpdateSMSStatusForBill(Bill bill)
        {
            throw new NotImplementedException();
        }

        public void SavePump(Pump pump)
        {
            throw new NotImplementedException();
        }

        public void SavePumps(Pump[] pumps, Guid leavingCashier)
        {
            throw new NotImplementedException();
        }

        public Pump[] GetPumpsHandledByEmployee(Guid cashierId)
        {
            throw new NotImplementedException();
        }

        public void SaveShift(PumpShiftDetails pumpShiftDetails)
        {
            throw new NotImplementedException();
        }

        public Bill[] GetEmployeeBills(Guid cashierId, DateTime shiftStartTime)
        {
            throw new NotImplementedException();
        }

        public void UpdateShiftCloseComplete(Guid cashierId)
        {
            throw new NotImplementedException();
        }

        public Report GenerateCloseShiftReport(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee)
        {
            throw new NotImplementedException();
        }

        public void AddProducts(Guid productID, int count)
        {
            throw new NotImplementedException();
        }

        public void UpdateBillWithCurrentCashier(Guid cashierId, string billNo)
        {
            throw new NotImplementedException();
        }

        public void RemoveCurrentCashierFromBill(string billNo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public interface IBillingServiceWrapper
    {

        //public Product[] GetProducts();


        //public Customer[] GetCustomers();


        //public Cashier[] GetCashiers();

        //public Cashier[] GetCurrentCashiers();



        //public void SaveBill(Bill bill);

        //public string GetBillNumber();

        //public string SendSMS(Bill bill);


        //public void UpdateSMSStatusForBill(Bill bill);

        //public void SavePump(Pump pump);


        //public void SavePumps(Pump[] pumps, Guid leavingCashier);

        //public Pump[] GetPumpsHandledByEmployee(Guid cashierId);

        //public void SaveShift(PumpShiftDetails pumpShiftDetails);

        //public Bill[] GetEmployeeBills(Guid cashierId, DateTime shiftStartTime);

        //public void UpdateShiftCloseComplete(Guid cashierId);

        //public Report GenerateCloseShiftReport(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee);


        //public void AddProducts(Guid productID, int count);


        //public void UpdateBillWithCurrentCashier(Guid cashierId, string billNo);

        //public void RemoveCurrentCashierFromBill(string billNo);

    }

}

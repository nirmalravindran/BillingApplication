using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication.WinForms
{
    public static class PrintRelated
    {
        public const string FullLine = "----------------------------------";
        public class Header
        {
            public const string TinAndPhone = "Tin:33474041629    Ph:04364-242776";
            public const string CompanyName = "          ARUNA AGENCIES          ";
            public const string CompanyAddress1 = " I.O.C. Dealers, Mayiladuthurai-2 ";
            public const string BillNumber = "Bill No:";
            public const string BillFormat = "ddMMyyHHmmss";
            public const string VehicleNumber = "VehNo: ";
            public const string Odometer = "Odometer: ";
            public const string CustomerName = "Name : ";
            public const string Date = "Date:";
            public const string DateFormat = "dd/MM/yyyy";
            public const string Time = "Time:";
            public const string TimeFormat = "HH:mm:ss";
        }

        public const string ItemsHeader = "Rate    Item       Lit     Amount ";
        public const string EmptyItems = "     |         |        |         ";
    }
}

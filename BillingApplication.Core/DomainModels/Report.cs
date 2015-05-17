using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication.Core.DomainModels
{
    public class Report
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}

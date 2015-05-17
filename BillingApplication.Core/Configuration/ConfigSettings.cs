using System.Configuration;

namespace BillingApplication.Core
{
    public static class ConfigSettings
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["ARUNA"];
        }

        public static string GetReportPath()
        {
            return ConfigurationManager.AppSettings["ARUNAPATH"];
        }

    }
}

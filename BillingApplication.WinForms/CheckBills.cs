using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public partial class CheckBills : Form
    {
        public CheckBills()
        {
            InitializeComponent();
        }

        private void CheckBills_Load(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            var cashiers = service.GetCurrentCashiers();

            ddlCashier.DataSource = cashiers;
            ddlCashier.DisplayMember = "NAME";
            ddlCashier.ValueMember = "PRIMARYKEY";
        }

        private void btnShowBills_Click(object sender, EventArgs e)
        {
            var pumpsHandledByEmployee = new List<Pump>();
            if (ddlCashier.SelectedValue != null)
            {
                var service = new BillingApplicationSoapClient();
                pumpsHandledByEmployee = service.GetPumpsHandledByEmployee((Guid)ddlCashier.SelectedValue).ToList();
            }
            var formToShow = new ShiftSummary(pumpsHandledByEmployee , new Cashier { Name = ddlCashier.Text, PrimaryKey = new Guid(ddlCashier.SelectedValue.ToString()) },true);
            formToShow.ShowDialog();
        }
    }
}

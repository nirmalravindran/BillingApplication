using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;
using PumpShiftDetailsUserControl = BillingApplication.WinForms.UserControls;

namespace BillingApplication.WinForms
{
    public partial class CloseShift : Form
    {
        private List<Pump> _pumpsHandledByEmployee;
        private Cashier[] _cashiers;
        public CloseShift()
        {
            InitializeComponent();
        }

        private void CloseShift_Load(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            _cashiers = service.GetCashiers();           
            ddlSelectEmployee.DisplayMember = "NAME";
            ddlSelectEmployee.ValueMember = "PRIMARYKEY";
            ddlSelectEmployee.DataSource = _cashiers;
            ddlNewCashier.DisplayMember = "NAME";
            ddlNewCashier.ValueMember = "PRIMARYKEY";
            ddlNewCashier.DataSource = _cashiers.Clone();
        }

        private void ddlSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlPumps.Enabled = true;
            RefreshLatestData();
        }

        private void GetPumpsHandledByEmployee()
        {
            if (ddlSelectEmployee.SelectedValue != null)
            {
                var service = new BillingApplicationSoapClient();
                _pumpsHandledByEmployee = service.GetPumpsHandledByEmployee((Guid)ddlSelectEmployee.SelectedValue).ToList();
            }
        }

        private void AddPumpsToPage()
        {

            var shiftDetailsExists = DoesShiftDetailsExists();

            if (shiftDetailsExists)
            {
                _pumpsHandledByEmployee = _pumpsHandledByEmployee.Where(a => a.PumpShiftDetails != null).ToList();
                btnNext.Enabled = true;
                btnSave.Enabled = false;
                ddlNewCashier.Enabled = false;
            }
            else
            {
                btnNext.Enabled = false;
                btnSave.Enabled = true;
                ddlNewCashier.Enabled = true;
            }

            AddPumpsToPage(shiftDetailsExists);
        }

        private bool DoesShiftDetailsExists()
        {
            return _pumpsHandledByEmployee.Any(a => a.PumpShiftDetails != null);
        }

        private void AddPumpsToPage(bool shiftDetailsExists)
        {
            pnlPumps.Controls.Clear();
            var db = new BillingApplicationSoapClient().GetCashiers();
            
            if(_pumpsHandledByEmployee!=null)
            {
                var count = _pumpsHandledByEmployee.Count();                         
                var top = 0;
                foreach (var pump in _pumpsHandledByEmployee)
                {
                    var array = new Cashier[db.Count()];
                    db.CopyTo(array, 0);
                    //If rate is changed .. set the new rate .
                    if (shiftDetailsExists && pump.PumpShiftDetails.First().Sales > 0)
                    {
                        pump.Rate = Math.Round(pump.PumpShiftDetails.First().Amount / pump.PumpShiftDetails.First().Sales, 2);
                        pump.PumpShiftDetails.First().Rate = pump.Rate;
                    }
                    var pumpControl = new PumpShiftDetailsUserControl.PumpShiftDetails(pump, array);
                    pumpControl.Name = "pumpDe";
                    pumpControl.CalculateAmountEventHandler += new PumpShiftDetailsUserControl.PumpShiftDetails.AmountEventHandler(pumpControl_CalculateAmountEventHandler);
                    pumpControl.Top = top;
                    pnlPumps.Controls.Add(pumpControl);                    
                    top = top + pumpControl.Height + 5;
                }
                Controls.Add(pnlPumps);
            }

            pumpControl_CalculateAmountEventHandler();
        }

        public void pumpControl_CalculateAmountEventHandler()
        {
            decimal amount = 0;
            var controls = pnlPumps.Controls.Find("pumpDe",false);

            foreach (PumpShiftDetailsUserControl.PumpShiftDetails pump in controls)
            {
                amount = amount + pump.GetAmount();
            }
            txtTotal.Text = amount.ToString(); 
        }        

        private void btnNext_Click(object sender, EventArgs e)
        {
            //var pumpDetails = GetShiftDetails();
            var pumpDetails = _pumpsHandledByEmployee;
            var formToShow = new ShiftSummary(pumpDetails, new Cashier { Name = ddlSelectEmployee.Text , PrimaryKey = new Guid(ddlSelectEmployee.SelectedValue.ToString()) },false);
            formToShow.ShowDialog();

            RefreshLatestData();
        }

        private IEnumerable<Pump> GetShiftDetails()
        {
            var lastUpdatedTime = DateTime.Now;
            var controls = pnlPumps.Controls.Find("pumpDe",false);

            foreach (PumpShiftDetailsUserControl.PumpShiftDetails pump in controls)
            {
                yield return pump.GetPumpDetails(lastUpdatedTime, false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var pumpDetails = GetShiftDetails().ToArray();

            var service = new BillingApplicationSoapClient();
            service.SavePumps(pumpDetails, new Guid(ddlSelectEmployee.SelectedValue.ToString()));

            RefreshLatestData();

            pnlPumps.Enabled = false;
            btnNext.Enabled = true;
            btnSave.Enabled = false;

        }

        private void RefreshLatestData()
        {
            //refresh the latest data.
            GetPumpsHandledByEmployee();
            AddPumpsToPage();
        }

        private void ddlNewCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var controls = pnlPumps.Controls.Find("pumpDe", false);

            foreach (PumpShiftDetailsUserControl.PumpShiftDetails pump in controls)
            {
                pump.SetCashier(ddlNewCashier.Text);
            }
        }     
    }
}

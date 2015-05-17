using System;
using System.Linq;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms.UserControls
{
    public partial class PumpShiftDetails : UserControl
    {
        private readonly Pump _pump;
        private readonly Cashier[] _cashiers;
        public delegate void AmountEventHandler();
        public event AmountEventHandler CalculateAmountEventHandler;

        public PumpShiftDetails(Pump pump, Cashier [] cashiers)
        {
            InitializeComponent();
            _pump = pump;
            _cashiers = cashiers;
        }

        #region IPumpShiftDetails Members

        public Pump GetPumpDetails(DateTime lastUpdatedTime, bool isShiftComplete)
        {
            return new Pump
            {
                Cashier = GetCashier(),
                CurrentReading = Convert.ToDecimal(txtClosingReading.Text),
                InitialReading = _pump.InitialReading,
                LastUpdated = lastUpdatedTime,
                Name = _pump.Name,
                PrimaryKey = _pump.PrimaryKey,
                Rate = _pump.Rate,
                PumpShiftDetails = new BillingServices.PumpShiftDetails[]
                {
                    new BillingServices.PumpShiftDetails
                    {
                        Amount = Convert.ToDecimal(txtAmount.Text),
                        Cashier = GetCashier(),
                        ClosingReading = Convert.ToDecimal(txtClosingReading.Text),
                        EndTime = _pump.LastUpdated,
                        OpeningReading = Convert.ToDecimal(txtOpeningReading.Text),
                        Pump = _pump,
                        Rate = Convert.ToDecimal(txtRate.Text),
                        Sales = Convert.ToDecimal(txtSales.Text),
                        StartTime = GetStartTime(),
                        Testing = Convert.ToDecimal(txtTesting.Text),
                        ShiftComplete = isShiftComplete
                        
                    }
                }
            };
        }

        private DateTime GetStartTime()
        {
            //return (_pump.PumpShiftDetails)
            //        ? _pump.PumpShiftDetails.First().StartTime
            //        : _pump.LastUpdated;

            return _pump.LastUpdated;
        }

        public decimal GetAmount()
        {
            return Convert.ToDecimal(txtAmount.Text);
        }

        public decimal GetSales()
        {
            return Convert.ToDecimal(txtSales.Text);
        }

        private Cashier GetCashier()
        {
            return new Cashier { Name = ddlNextEmployee.SelectedText, PrimaryKey = new Guid(ddlNextEmployee.SelectedValue.ToString()) };
        }

        public void SetCashier(string cashierName)
        {
            ddlNextEmployee.Text = cashierName;
        }

        public void SetRate(decimal rate)
        {
            txtRate.Text = rate.ToString();
        }

        #endregion

        private void PumpShiftDetails_Load(object sender, EventArgs e)
        {
                lblPumpName.Text = _pump.Name;
                txtRate.Text = _pump.Rate.ToString();
                txtClosingReading.Leave += new EventHandler(txtClosingReading_Leave);
                txtTesting.Leave += new EventHandler(txtTesting_Leave);

                ddlNextEmployee.DisplayMember = "NAME";
                ddlNextEmployee.ValueMember = "PRIMARYKEY";
                ddlNextEmployee.DataSource = _cashiers;

                if (_pump.PumpShiftDetails == null)
                {
                    txtOpeningReading.Text = _pump.CurrentReading.ToString();
                    txtClosingReading.Text = _pump.CurrentReading.ToString();
                }
                else
                {
                    var pumpShiftDetails = _pump.PumpShiftDetails.First();

                    txtOpeningReading.Text = pumpShiftDetails.OpeningReading.ToString();
                    txtClosingReading.Text = pumpShiftDetails.ClosingReading.ToString();
                    txtTesting.Text = pumpShiftDetails.Testing.ToString();
                    txtSales.Text = pumpShiftDetails.Sales.ToString();
                    txtAmount.Text = pumpShiftDetails.Amount.ToString();

                    ddlNextEmployee.SelectedValue = _pump.Cashier.PrimaryKey;
                    this.Enabled = false;
                }
        }

        void txtTesting_Leave(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        void txtClosingReading_Leave(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            _pump.Rate = decimal.Parse(txtRate.Text);
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            var sales = (((_pump.IsReadingIncremental) ? 1 : -1) * (decimal.Parse(txtClosingReading.Text) - decimal.Parse(txtOpeningReading.Text))) - decimal.Parse(txtTesting.Text);
            var rate = decimal.Parse(txtRate.Text);

            txtSales.Text = sales.ToString();
            txtAmount.Text = Math.Round((sales * rate),2,MidpointRounding.AwayFromZero).ToString();

            //Calculate total sales
            CalculateAmountEventHandler();
        }

    }
}

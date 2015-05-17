using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;
using System.Drawing;

namespace BillingApplication.WinForms
{
    public partial class ShiftSummary : Form
    {
        private readonly Pump[] _pumpDetails;
        private readonly Cashier _oldCashier;
        private Bill[] _bills;
        private Expenses[] _expenses;
        private CashReceipt[] _cashReceipts;

        private bool _isReadOnly;

        public ShiftSummary(IEnumerable<Pump> pumpDetails, Cashier oldCashier, bool isReadOnly)
        {
            InitializeComponent();
            _pumpDetails = pumpDetails.ToArray();
            _oldCashier = oldCashier;
            _isReadOnly = isReadOnly;
        }

        private void ShiftSummary_Load(object sender, EventArgs e)
        {
            GetBillDetailsAndInitialiseForm();

            setUpExpencesGrid();
            CalculateCashPaid();
        }

        private void GetBillDetailsAndInitialiseForm()
        {
            var service = new BillingApplicationSoapClient();
            DateTime startTime = _pumpDetails.First().LastUpdated;
            if (_pumpDetails.First().PumpShiftDetails != null && _pumpDetails.First().PumpShiftDetails.Any())
                startTime = _pumpDetails.First().PumpShiftDetails.First().StartTime;
            _bills = service.GetEmployeeBills(_oldCashier.PrimaryKey, startTime);

            grdBills.DataSource = _bills;
            InitialiseGrid();

            txtTotalCreditSales.Text = _bills.Sum(bill => bill.TotalAmount).ToString();
            if (!_isReadOnly)
            {
                txtTotalSalesAmount.Text = _pumpDetails.Sum(pump => pump.PumpShiftDetails.Single().Amount).ToString();
                ValidateAmount();
            }

            lblEmployeeName.Text = _oldCashier.Name;
            
            if (_isReadOnly)
            {
                btnSave.Visible = false;
                txtCashPaid.Enabled = false;
            }
        }

        private void CalculateCashPaid()
        {
            var service = new BillingApplicationSoapClient();
            DateTime startTime = _pumpDetails.First().LastUpdated;
            if (_pumpDetails.First().PumpShiftDetails != null && _pumpDetails.First().PumpShiftDetails.Any())
                startTime = _pumpDetails.First().PumpShiftDetails.First().StartTime;
            var cashReceipts = service.GetEmployeeCashReceipts(_oldCashier.PrimaryKey, startTime);
            _cashReceipts = cashReceipts;
            txtCashPaid.Text = cashReceipts.Sum(cashReceipt => cashReceipt.Amount).ToString();
                        
        }

        private void InitialiseGrid()
        {
            //Remove Unwanted Columns or add only the required columns
            grdBills.Columns.Remove("primarykey");
            grdBills.Columns.Remove("number");
            grdBills.Columns.Remove("vehiclenumber");
            grdBills.Columns.Remove("odometer");
            grdBills.Columns.Remove("cashier");
            grdBills.Columns.Remove("billdate");
            grdBills.Columns.Remove("smsstatus");

            grdBills.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtCashPaid_TextChanged(object sender, EventArgs e)
        {
            ValidateAmount();
        }

        private void ValidateAmount()
        {
            decimal totalSalesAmount = 0;
            decimal totalCreditAmount = 0;
            decimal totalExpenceAmount = 0;
            decimal cashPaid = 0;
            txtShortageOrExcess.Text = "0.00";

            if (decimal.TryParse(txtTotalSalesAmount.Text, out totalSalesAmount) && decimal.TryParse(txtTotalCreditSales.Text, out totalCreditAmount) && decimal.TryParse(txtCashPaid.Text, out cashPaid) && decimal.TryParse(txtTotalExpences.Text, out totalExpenceAmount))
            {
                txtShortageOrExcess.Text = (-totalSalesAmount + totalCreditAmount + totalExpenceAmount + cashPaid).ToString();
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _expenses = getExpenses();
            var service = new BillingApplicationSoapClient();
            var report = service.UpdateShiftCloseAndGenerateReport(_pumpDetails, _bills, Convert.ToDecimal(txtCashPaid.Text), _expenses);
            //
            string cwd = System.IO.Directory.GetCurrentDirectory();
            //
            var fileStream = new FileStream(string.Format(@"{0}\AA\{1}",cwd,report.FileName), FileMode.Create);
            fileStream.Write(report.Content, 0, report.Content.Length);
            fileStream.Close();
            MessageBox.Show("Shift closed Successfully..");
            this.Close();
        }

        private Expenses[] getExpenses()
        {
            var _expenses = new List<Expenses>();
            decimal amount = 0;
            for (int i = 0; i < grdExpences.Rows.Count; i++)
            {
                // handles the last empty row.
                if (grdExpences.Rows[i].Cells["Amount"].Value == null)
                    break;
                var item = new Expenses();
                decimal.TryParse(grdExpences.Rows[i].Cells["Amount"].Value.ToString(), out amount);
                item.TotalAmount = amount;
                item.Description = grdExpences.Rows[i].Cells["Desc"].FormattedValue.ToString();
                _expenses.Add(item);
            }

            return _expenses.ToArray();
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            var billNo = txtBillNo.Text;
            if (!string.IsNullOrEmpty(billNo))
            {
                var service = new BillingApplicationSoapClient();
                service.UpdateBillWithCurrentCashier(_oldCashier.PrimaryKey, billNo);

                GetBillDetailsAndInitialiseForm();
            }
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            var billNo = txtBillNo.Text;
            if (!string.IsNullOrEmpty(billNo))
            {
                var service = new BillingApplicationSoapClient();
                service.RemoveCurrentCashierFromBill(billNo);

                GetBillDetailsAndInitialiseForm();
            }
        }

        private void setUpExpencesGrid()
        {
            // Add RATE column
            var descColumn = new DataGridViewTextBoxColumn();
            descColumn.HeaderText = "Description";
            descColumn.Name = "Desc";
            descColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            descColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            grdExpences.Columns.Add(descColumn);

            // Add Amount Column
            var amountColumn = new DataGridViewTextBoxColumn();
            amountColumn.HeaderText = "Amount";
            amountColumn.Name = "Amount";
            amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            amountColumn.DefaultCellStyle.Format = "0.00";
            amountColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            grdExpences.Columns.Add(amountColumn);
        }

        private void grdExpences_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Get the changed row.
            DataGridViewRow dr = grdExpences.Rows[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 1:
                    // Amount is canged
                    decimal amount = 0;
                    if (decimal.TryParse(dr.Cells["Amount"].Value.ToString(), out amount))
                    {
                        // for .00 format
                        dr.Cells["Amount"].Value = amount;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid value...");
                        dr.Cells["Amount"].Value = 0;
                        dr.Cells["Amount"].Selected = true;
                    }
                    break;
                default:
                    return;
            }

            // Update Total
            txtTotalExpences.Text = Convert.ToDecimal(calculateTotalExpences()).ToString("F");
            ValidateAmount();
        }

        private decimal calculateTotalExpences()
        {
            decimal total = 0;
            for (int i = 0; i < grdExpences.Rows.Count; i++)
            {
                if (grdExpences.Rows[i].Cells["Amount"].Value != null)
                    total += decimal.Parse(grdExpences.Rows[i].Cells["Amount"].Value.ToString());
            }
            return total;
        }

        private void btnAddCash_Click(object sender, EventArgs e)
        {
            var childform = new CashReceiptForm();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();

            CalculateCashPaid();
        }

        private void btnCashPaid_Click(object sender, EventArgs e)
        {
            var childform = new CashPaid(_cashReceipts);
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }
      
    }
}

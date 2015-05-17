using System;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public partial class CashPaid : Form
    {
        private CashReceipt[] _cashReceipts;
        public CashPaid(CashReceipt[] cashReceipt)
        {
            InitializeComponent();
            _cashReceipts = cashReceipt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CashPaid_Load(object sender, EventArgs e)
        {
            populateCashReceiptGrid();
        }
        private void populateCashReceiptGrid()
        {
            grdCashReceipt.DataSource = _cashReceipts;
            grdCashReceipt.Columns.Remove("PrimaryKey");
            grdCashReceipt.Columns.Remove("CashierID");
            grdCashReceipt.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdCashReceipt.Columns["ReceiptDate"].Width = 150;
        }
    }
}

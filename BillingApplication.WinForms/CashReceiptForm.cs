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
    public partial class CashReceiptForm : Form
    {
        public CashReceiptForm()
        {
            InitializeComponent();
        }

        private void CashReceiptForm_Load(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            var cashiers = service.GetCashiers();

            ddlCashier.DataSource = cashiers;
            ddlCashier.DisplayMember = "NAME";
            ddlCashier.ValueMember = "PRIMARYKEY";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal amount = 0;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Please enter a valid Amount!!");
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
            else
            {
                CashReceipt cashReceipt = new CashReceipt()
                                            {
                                                CashierID = (Guid)ddlCashier.SelectedValue,
                                                Amount = amount,
                                                PrimaryKey = Guid.NewGuid(),
                                                ReceiptDate = DateTime.Now,
                                                Notes = txtNote.Text
                                            };

                var service = new BillingApplicationSoapClient();
                service.SaveCashReceipt(cashReceipt);
                MessageBox.Show("Cash Receipt saved successfully!");
                this.Close();
            }
        }
    }
}

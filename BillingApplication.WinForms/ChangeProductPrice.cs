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
    public partial class ChangeProductPrice : Form
    {
        Product[] _products;
        public ChangeProductPrice()
        {
            InitializeComponent();
        }

        private void ChangeProductPrice_Load(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            _products = service.GetAllProducts();
            cboProducts.DisplayMember = "NAME";
            cboProducts.ValueMember = "PRIMARYKEY";
            cboProducts.DataSource = _products;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            if (string.IsNullOrEmpty(txtPrice.Text) || 
                !decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                txtPrice.Text = "0";
                txtPrice.Focus();
            }
            else
            {
                var service = new BillingApplicationSoapClient();
                service.UpdatePriceForProduct(new Guid(cboProducts.SelectedValue.ToString()), price);
                MessageBox.Show("Product price updated.");
                this.Close();
            }
        }

    }
}

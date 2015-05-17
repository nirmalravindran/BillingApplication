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
    public partial class AddProducts : Form
    {
        Product[] _products;
        public AddProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            service.AddProducts(new Guid(ddlProducts.SelectedValue.ToString()), int.Parse(txtCount.Text));
            MessageBox.Show("Product added successfully.");
            this.Close();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();
            _products = service.GetProducts();

            txtCount.Text = "0";

            ddlProducts.DataSource = _products;
            ddlProducts.DisplayMember = "NAME";
            ddlProducts.ValueMember = "PRIMARYKEY";
        }

        private void txtCount_Leave(object sender, EventArgs e)
        {   
            var i = 0;
            if (!int.TryParse(txtCount.Text, out i))
            {
                MessageBox.Show("Please enter a valid number..");
                txtCount.Text = "0";
            }
        }
    }
}

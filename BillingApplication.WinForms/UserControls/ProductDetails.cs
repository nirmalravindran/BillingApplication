using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms.UserControls
{
    public partial class ProductDetails : UserControl
    {
        Tank[] _tanks;
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tank = new TankDetails();
            
            var service = new BillingApplicationSoapClient();
            _tanks = service.GetTanksForProduct(GetProduct());
            tank.setTank(_tanks);

            tank.Top = panel1.Controls.Count * 40;
            panel1.Controls.Add(tank);
        }

        public Guid GetProduct()
        {
            if (ddlProducts.SelectedValue != null)
                return (Guid)ddlProducts.SelectedValue;
            return Guid.Empty;
        }

        public string GetProductName()
        {
            return ddlProducts.Text;
        }

        public void SetProduct(Product[] product)
        {
            ddlProducts.DataSource = product;
            ddlProducts.DisplayMember = "NAME";
            ddlProducts.ValueMember = "PRIMARYKEY";
        }

        public decimal GetInvoiceDensity()
        {
            return decimal.Parse(textBox2.Text);
        }

        public decimal GetSampleDensity()
        {
            return decimal.Parse(textBox3.Text);
        }

        public Panel GetTankPanel()
        {
            return panel1;
        }

        public string GetSource()
        {
            return textBox1.Text;
        }
   }
}

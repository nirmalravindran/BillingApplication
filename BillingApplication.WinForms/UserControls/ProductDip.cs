using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication.WinForms.UserControls
{
    public partial class ProductDip : UserControl
    {
        public ProductDip()
        {
            InitializeComponent();
        }

        public void SetProduct(string product)
        {
            txtProduct.Text = product;
        }

        public void SetStock(string stock)
        {
            txtStock.Text = stock;
        }

        public void SetSales(string sales)
        {
            txtSales.Text = sales;
        }
        public void SetDifference(string difference)
        {
            txtDifference.Text = difference;
        }
    }
}

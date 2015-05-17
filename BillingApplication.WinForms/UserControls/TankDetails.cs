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
    public partial class TankDetails : UserControl
    {
        public TankDetails()
        {
            InitializeComponent();
        }

        public string GetTankName()
        {
            return ddlTank.Text;
        }

        public void setTank(Tank[] tank)
        {
            ddlTank.DataSource = tank;
            ddlTank.DisplayMember = "name";
            ddlTank.ValueMember = "primarykey";
        }

        public decimal GetQuantity()
        {
            return decimal.Parse(textBox1.Text);
        }

        public Guid GetTank()
        {
            if (ddlTank.SelectedValue != null)
                return (Guid)ddlTank.SelectedValue;
            return Guid.Empty;
        }

        private void TankDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

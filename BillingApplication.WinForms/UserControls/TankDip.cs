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
    public partial class TankDip : UserControl
    {
        private decimal _capacity;
        public delegate void DipEventHandler();
        public event DipEventHandler CalculateVolumeEventHandler;
        private Guid _product;
        private Guid _tank;

        public TankDip()
        {
            InitializeComponent();
        }

        public void SetTankName(string tankName)
        {
            txtTankName.Text = tankName;
        }

        public void SetTankPrevVolume(string tankPrevVolume)
        {
            txtPrevVolume.Text = tankPrevVolume;
        }

        public void SetTankReceipt(string tankReceipt)
        {
            txtTankReceipt.Text = tankReceipt;
        }

        public void SetTankSales(string tankSales)
        {
            txtTankSales.Text = tankSales;
        }

        public void SetTankDifference(string tankDifference)
        {
            txtTankDifference.Text = tankDifference;
        }

        public string GetFuelDip()
        {
            return txtTankDip.Text;
        }

        public string GetWaterDip()
        {
            return txtWaterDip.Text;
        }

        public void SetTankVolume(string tankVolume)
        {
            txtTankVolume.Text = tankVolume;
        }

        public void CalculateDifference()
        {
            txtTankDifference.Text = (GetVolume() - GetPrevVolume() - GetReceipt() + GetSales()).ToString();

        }

        public decimal GetPrevVolume()
        {
            decimal prevVolume = 0;
            decimal.TryParse(txtPrevVolume.Text, out prevVolume);
            return prevVolume;
        }

        public decimal GetReceipt()
        {
            decimal prevReceipt = 0;
            decimal.TryParse(txtTankReceipt.Text, out prevReceipt);
            return prevReceipt;
        }

        public decimal GetSales()
        {
            decimal prevSales = 0;
            decimal.TryParse(txtTankSales.Text, out prevSales);
            return prevSales;
        }

        public decimal GetVolume()
        {
            decimal Volume = 0;
            decimal.TryParse(txtTankVolume.Text, out Volume);
            return Volume;
        }

        public decimal GetDifference()
        {
            decimal difference = 0;
            decimal.TryParse(txtTankDifference.Text, out difference);
            return difference;
        }

        private void txtTankVolume_TextChanged(object sender, EventArgs e)
        {
            CalculateDifference();
        }

        private void txtTankDip_Leave(object sender, EventArgs e)
        {
            CalculateVolumeEventHandler();
        }

        private void txtWaterDip_Leave(object sender, EventArgs e)
        {
            CalculateVolumeEventHandler();
        }

        public void SetCapacity(decimal capacity)
        {
            _capacity = capacity;
        }

        public decimal GetCapacity()
        { 
            return _capacity; 
        }

        public void SetProduct(Guid product)
        {
            _product = product;
        }

        public Guid GetProduct()
        {
            return _product;
        }

        public void SetPrimaryKey(Guid primaryKey)
        {
            _tank = primaryKey;
        }

        public Guid GetPrimaryKey()
        {
            return _tank;
        }
    }
}

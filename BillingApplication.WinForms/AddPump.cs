using System;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public partial class AddPump : Form
    {
        public AddPump()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var service = new BillingApplicationSoapClient();

            var pump = new Pump
            {
                Name = txtPumpName.Text,
                InitialReading = Convert.ToDecimal(txtOpeningReading.Text),
                CurrentReading = Convert.ToDecimal(txtOpeningReading.Text),
                Rate = Convert.ToDecimal(txtRate.Text),
                PrimaryKey = Guid.NewGuid(),
                Cashier = new Cashier { PrimaryKey = Guid.Empty, Name = "Idle" }
            };                

            service.SavePump(pump);
        }
        
    }
}

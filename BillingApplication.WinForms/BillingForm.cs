using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BillingApplication.WinForms.BillingServices;


namespace BillingApplication.WinForms
{
    public partial class BillingForm : Form
    {
        Product[] _products;
        Bill _bill;
        Customer[] _customres;
        bool _isOffline;

        System.IO.StreamReader fileToPrint;
        System.Drawing.Font printFont;

        public BillingForm(bool isOffline)
        {
            InitializeComponent();
            _isOffline = isOffline;
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            GetInitialData();
            lblBillNo.Visible = _isOffline;
            txtBillNo.Visible = _isOffline;
            btnSave.Visible = _isOffline;
            btnPrint.Visible = !(_isOffline);
        }

        private void GetInitialData()
        {
            var service = new BillingApplicationSoapClient();
            var cashiers = service.GetCashiers();
            _customres = service.GetCustomers();
            _products = service.GetProducts();

            ddlCashier.DataSource = cashiers;
            ddlCashier.DisplayMember = "NAME";
            ddlCashier.ValueMember = "PRIMARYKEY";

            ddlCustomer.DataSource = _customres;
            ddlCustomer.DisplayMember = "NAME";
            
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            // Add ITEM column
            var itemColumn = new DataGridViewComboBoxColumn();
            itemColumn.AutoComplete = true;
            itemColumn.HeaderText = "Item";
            itemColumn.DataSource = _products;
            itemColumn.DisplayMember = "Name";
            itemColumn.ValueMember = "PrimaryKey";
            itemColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            itemColumn.Width = 250;
            itemColumn.Name = "Item";
            grdItems.Columns.Add(itemColumn);

            // Add Quantity Column
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.Name = "Quantity";
            quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            quantityColumn.DefaultCellStyle.Format = "0.00";
            quantityColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            quantityColumn.ReadOnly = true;
            grdItems.Columns.Add(quantityColumn);
            
            // Add RATE column
            var rateColumn = new DataGridViewTextBoxColumn();
            rateColumn.HeaderText = "Rate";
            rateColumn.Name = "Rate";
            rateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            rateColumn.DefaultCellStyle.Format = "0.00";
            rateColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            rateColumn.ReadOnly = true;
            grdItems.Columns.Add(rateColumn);


            // Add Amount Column
            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn();
            amountColumn.HeaderText = "Amount";
            amountColumn.Name = "Amount";
            amountColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            amountColumn.DefaultCellStyle.Format = "0.00";
            amountColumn.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            amountColumn.ReadOnly = true;
            grdItems.Columns.Add(amountColumn);
        }

        private void grdItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = grdItems.Rows[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    // Item is changed
                    var product = new Guid(dr.Cells["Item"].Value.ToString()) ;

                    dr.Cells["Rate"].Value = getRateForProduct(product);
                    // clear quantity and amount 
                    dr.Cells["Quantity"].Value = 0;
                    dr.Cells["Amount"].Value = 0;

                    dr.Cells["Rate"].ReadOnly = false;
                    dr.Cells["Quantity"].ReadOnly = false;
                    dr.Cells["Amount"].ReadOnly = false;
                    break;
                case 1:
                    // Quantity is canged
                    decimal quantity = 0; 
                    decimal rateForQuantity = 0;
                    if (decimal.TryParse(dr.Cells["Quantity"].Value.ToString(), out quantity) && decimal.TryParse(dr.Cells["Rate"].Value.ToString(), out rateForQuantity))
                    {
                        dr.Cells["Amount"].Value = (quantity * rateForQuantity);
                        // for .00 format
                        dr.Cells["Quantity"].Value = quantity;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid value...");
                        dr.Cells["Quantity"].Value = 0;
                        dr.Cells["Quantity"].Selected = true;
                    }
                    break;
                case 2:
                    // Rate is changed
                    decimal rate = 0;
                    decimal quantityForRate = 0;
                    if (decimal.TryParse(dr.Cells["Rate"].Value.ToString(), out rate) && decimal.TryParse(dr.Cells["Quantity"].Value.ToString(), out quantityForRate))
                    {
                        dr.Cells["Amount"].Value = (rate * quantityForRate);
                        // for .00 format
                        dr.Cells["Rate"].Value = rate;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid value...");
                        dr.Cells["Rate"].Value = 0;
                        dr.Cells["Rate"].Selected = true;
                    }
                    break;
                case 3:
                    // Amount is changed
                    decimal amount = 0;
                    decimal rateForAmount = 0;
                    if (decimal.TryParse(dr.Cells["Amount"].Value.ToString(), out amount) && decimal.TryParse(dr.Cells["Rate"].Value.ToString(), out rateForAmount))
                    {
                        dr.Cells["Quantity"].Value = (amount / rateForAmount);
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
                    // do nothing
                    return;
            }
            // Update Total
            txtTotalAmount.Text = Convert.ToDecimal(calculateTotalAmount()).ToString("F");
        }

        private decimal calculateTotalAmount()
        {
            decimal total = 0;
            for (int i = 0; i < grdItems.Rows.Count; i++)
            {
                if (grdItems.Rows[i].Cells["Amount"].Value != null)
                    total += decimal.Parse(grdItems.Rows[i].Cells["Amount"].Value.ToString());
            }
            return total;
        }

        private decimal getRateForProduct(Guid product)
        {
            return _products.Where(a => a.PrimaryKey == product).First().Rate;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateBill(string.Empty);
            SaveBill();
            PrintBill();
            SendSMS();
            ClearForm();

        }

        private void PrintBill()
        {
            fileToPrint = new System.IO.StreamReader(@"C:\ArunaBilling\myfile.txt");
            printFont = new System.Drawing.Font("Courier New", 10);
            printDocument1.DefaultPageSettings.Margins.Left = 50;
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.Print();
            fileToPrint.Close();
        }

        private void CreateBill(string billNumber)
        {
            // Create the bill in a text file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\ArunaBilling\myfile.txt"))
            {
                string billno;
                if (!_isOffline)
                {
                    var service = new BillingApplicationSoapClient();
                    billno = service.GetBillNumber();
                }
                else
                {
                    billno = billNumber;
                }
                
                _bill = new Bill();
                _bill.PrimaryKey = Guid.NewGuid();
                
                _bill.BillNumber = billno;
                _bill.Cashier = new Cashier { Name = ddlCashier.SelectedText, PrimaryKey = new Guid(ddlCashier.SelectedValue.ToString()) };
                var now = DateTime.Now;
                var name = ddlCustomer.Text;
                if (name.Length > 30)
                    name = name.Substring(0, 29);
                _bill.CustomerName = name.Trim();
                _bill.Number = _customres.Where(a => a.Name == _bill.CustomerName).First().MobileNumber;
                string vehiclenotext = PrintRelated.Header.VehicleNumber + txtVehicleNumber.Text;
                string timetext = PrintRelated.Header.Time + now.ToString(PrintRelated.Header.TimeFormat);
                _bill.VehicleNumber = txtVehicleNumber.Text.Trim();
                _bill.Odometer = txtOdometer.Text.Trim();
                _bill.BillDate = now;

                file.WriteLine(PrintRelated.Header.TinAndPhone);
                file.WriteLine(PrintRelated.Header.CompanyName);
                file.WriteLine(PrintRelated.Header.CompanyAddress1);
                file.WriteLine(PrintRelated.Header.BillNumber + billno + "   " + PrintRelated.Header.Date + now.ToString(PrintRelated.Header.DateFormat));
                file.WriteLine(PrintRelated.Header.CustomerName + _bill.CustomerName);
                file.WriteLine(vehiclenotext.PadRight(16) + timetext.PadLeft(34).Substring(18));

                //file.WriteLine(Constants.PrintRelated.Header.Date + now.ToString(Constants.PrintRelated.Header.DateFormat) 
                //+ Constants.PrintRelated.Header.Time + now.ToString(Constants.PrintRelated.Header.TimeFormat));
                
                
                //rate(5) | particulars(9) | Lit(8) | Amount(9)
                file.WriteLine(PrintRelated.FullLine);
                file.WriteLine(PrintRelated.ItemsHeader);
                file.WriteLine(PrintRelated.FullLine);
                _bill.Products = new BillItem[grdItems.Rows.Count-1];

                for (int i = 0; i < grdItems.Rows.Count; i++)
                {
                    // handles the last empty row.
                    if (grdItems.Rows[i].Cells["Rate"].Value == null)
                        break;
                    var item = new BillItem();
                    string rate = (grdItems.Rows[i].Cells["Rate"].Value.ToString());
                    if (rate.Length > 5)
                        rate = rate.Substring(0, 5);
                    else
                        rate = rate.PadRight(5);

                    string product = grdItems.Rows[i].Cells["Item"].FormattedValue.ToString();
                    if (product.Length > 9)
                        product = product.Substring(0, 9);
                    else
                        product = product.PadRight(9);

                    string quantity = (grdItems.Rows[i].Cells["Quantity"].Value.ToString());
                    quantity = FormatDecimalValue(quantity, 8);

                    string amount = (grdItems.Rows[i].Cells["Amount"].Value.ToString());
                    amount = FormatDecimalValue(amount, 9);

                    file.WriteLine(rate + "|" + product + "|" + quantity + "|" + amount);

                    item.PrimaryKey = Guid.NewGuid();
                    item.ForeignKey = _bill.PrimaryKey;

                    item.Product = new Product();

                    item.Product.PrimaryKey = new Guid (grdItems.Rows[i].Cells["Item"].Value.ToString());
                    item.Product.Name = product.Trim();
                    item.Quantity = decimal.Parse(quantity);
                    item.Amount = decimal.Parse(amount);
                    item.Product.Rate = decimal.Parse(rate);

                    _bill.Products[i] = item;
                }

                //buffer minimum of 5 item rows
                //there will always be one extra row in the grid than the number of items
                if (grdItems.Rows.Count <= 5)
                {
                    for (int i = 0; i <= (5 - grdItems.Rows.Count); i++)
                    {
                        file.WriteLine(PrintRelated.EmptyItems);
                    }
                }

                file.WriteLine(PrintRelated.FullLine);
                string total = txtTotalAmount.Text.ToString();
                if (!total.Contains("."))
                    total = total + ".00";
                else
                    total = total.Substring(0, total.IndexOf(".") + 3);
                _bill.TotalAmount = decimal.Parse(total);
                string odometerText = PrintRelated.Header.Odometer + txtOdometer.Text;
                file.WriteLine(odometerText.PadRight(16) + "  " + ("TOTAL :").PadLeft(24).Substring(17) + total.PadLeft(9));
                file.WriteLine("Sign. : ");
                file.WriteLine(string.Empty);
                file.WriteLine("           Thank you...           ");
            }
        }

        private string FormatDecimalValue(string Value, int length)
        {
            if (!Value.Contains("."))
                Value = Value + ".00";
            else
                Value = Value.PadRight(length, '0');
            Value = Value.Substring(0, Value.IndexOf(".") + 3);
            if (Value.Length > length)
                Value = Value.Substring(0, length - 1);
            else
                Value = Value.PadLeft(length);

            return Value;
        }

        private void SaveBill()
        { 
            var service = new BillingApplicationSoapClient();
            service.SaveBill(_bill);
        }

        private void SendSMS()
        {
            var service = new BillingApplicationSoapClient();
            _bill.SMSStatus = service.SendSMS(_bill);
            
            service.UpdateSMSStatusForBill(_bill);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtBillNo.Clear();
            txtOdometer.Clear();
            txtVehicleNumber.Clear();
            txtTotalAmount.Clear();

            grdItems.Rows.Clear();

            ddlCustomer.SelectedIndex = 0;

            ddlCashier.Focus();
        }

        private void txtVehicleNumber_Leave(object sender, EventArgs e)
        {
            txtVehicleNumber.Text = txtVehicleNumber.Text.ToUpper();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = 0f;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            while (count < linesPerPage)
            {
                line = fileToPrint.ReadLine();
                if (line == null)
                {
                    break;
                }
                yPos = topMargin + count * printFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateBillNumber())
            {
                CreateBill(txtBillNo.Text.Trim());
                if (_bill.Products.Count() > 0)
                {
                    SaveBill();
                    SendSMS();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("No Items in Bill.");
                }
            }
            else
            {
                MessageBox.Show("The Bill Number already exist. Please enter a valid Bill Number.");
                txtBillNo.Select();
                txtBillNo.Focus();
            }
        }

        private bool ValidateBillNumber()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                return false;
            }
            else
            {
                var service = new BillingApplicationSoapClient();
                return !(service.DoesBillNumberExists(txtBillNo.Text.Trim()));
            }
        }

    }
}

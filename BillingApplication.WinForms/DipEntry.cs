using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using BillingApplication.WinForms.UserControls;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public partial class DipEntry : Form
    {
        OleDbConnection _connection;
        DataTable dt15 = new DataTable();
        DataTable dt20 = new DataTable();
        Tank[] _tanks;
        Tank[] _tankPrevVolume;
        Tank[] _tankSales;
        Tank[] _tankReceipts;
        Product[] _products;
        string _smsMessage;


        public DipEntry()
        {
            InitializeComponent();

            string _connectionString;
            var cwd = System.IO.Directory.GetCurrentDirectory() + @"\dip.xlsx";
            _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + cwd + ";Extended Properties='Excel 8.0;HDR=YES;';";
            _connection = new OleDbConnection(_connectionString);
        }

        private void DipEntry_Load(object sender, EventArgs e)
        {
            _connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [15KL$]", _connection);
            da.Fill(dt15);

            da = new OleDbDataAdapter("select * from [20KL$]", _connection);
            da.Fill(dt20);
            _connection.Close();

            LoadTankPanel();
            

        }

        private void LoadProductPanel()
        {
            _smsMessage = "Tank1: Tank2: Tank3: Tank4:";
            panel2.Controls.Clear();
            foreach (Product product in _products)
            {
                var productDip = new ProductDip();
                productDip.SetProduct(product.Name);
                _smsMessage = _smsMessage + " " + product.Name;
                decimal sales = 0;
                decimal stock = 0;
                decimal difference = 0;
                foreach (TankDip tank in panel1.Controls)
                {
                    if (tank.GetProduct().Equals(product.PrimaryKey))
                    {
                        sales += tank.GetSales();
                        stock += tank.GetVolume();
                        difference += tank.GetDifference();
                    }
                }
                productDip.SetStock(stock.ToString());
                _smsMessage = _smsMessage + " STOCK " + stock.ToString();
                productDip.SetSales(sales.ToString());
                _smsMessage = _smsMessage + " SALES " + sales.ToString();
                productDip.SetDifference(difference.ToString());
                _smsMessage = _smsMessage + " DIFF " + difference.ToString();
                productDip.Top = panel2.Controls.Count * 30;
                panel2.Controls.Add(productDip);
            }
        }
        private void LoadTankPanel()
        {
            var service = new BillingApplicationSoapClient();
            _tanks = service.GetAllTanks();
            _tankPrevVolume = service.GetPreviousVolumeForTanks();
            _tankSales = service.GetSalesForTanks();
            _tankReceipts = service.GetReceiptsForTanks();
            _products = service.GetTankableProducts();

            foreach (Tank tank in _tanks)
            {
                foreach (Tank PrevVolume in _tankPrevVolume)
                {
                    if (tank.PrimaryKey.Equals(PrevVolume.PrimaryKey))
                    {
                        tank.PreviousVolume = PrevVolume.PreviousVolume;
                        break;
                    }
                }

                foreach (Tank Sales in _tankSales)
                {
                    if (tank.PrimaryKey.Equals(Sales.PrimaryKey))
                    {
                        tank.Sales = decimal.Floor(Sales.Sales);
                        break;
                    }
                }

                foreach (Tank Receipts in _tankReceipts)
                {
                    if (tank.PrimaryKey.Equals(Receipts.PrimaryKey))
                    {
                        tank.Receipt = Receipts.Receipt;
                        break;
                    }
                }
                
            }

            
            foreach (Tank tank in _tanks)
            {
                var tankDip = new TankDip();
                tankDip.SetPrimaryKey(tank.PrimaryKey);
                tankDip.SetTankName(tank.Name);
                tankDip.SetTankPrevVolume(tank.PreviousVolume.ToString());
                tankDip.SetTankReceipt(tank.Receipt.ToString());
                tankDip.SetTankSales(tank.Sales.ToString());
                tankDip.SetCapacity(tank.Capacity);
                tankDip.SetProduct(tank.Product);
                tankDip.CalculateVolumeEventHandler += new TankDip.DipEventHandler(tankDip_CalculateVolumeEventHandler);
                tankDip.CalculateDifference();
                tankDip.Top = panel1.Controls.Count * 30;
                panel1.Controls.Add(tankDip); 
            }

        }

        public void tankDip_CalculateVolumeEventHandler()
        {
            var controls = panel1.Controls;
            foreach (TankDip control in controls)
            {
                if (control.GetCapacity().Equals(15000))
                    control.SetTankVolume(Get15KLVolume(control.GetFuelDip(),control.GetWaterDip()));
                else
                    control.SetTankVolume(Get20KLVolume(control.GetFuelDip(), control.GetWaterDip()));
            }

            LoadProductPanel();
        }

        public string Get15KLVolume(string dip, string water)
        {
            double dipValue = 0;
            double waterValue = 0;

            if (!string.IsNullOrEmpty(dip) && double.TryParse(dip, out dipValue)
                && !string.IsNullOrEmpty(water) && double.TryParse(water, out waterValue))
            {

                dipValue = Math.Round(dipValue, 1);
                waterValue = Math.Round(waterValue, 1);

                var dipNumber = (int)dipValue;
                var dipDecimal = (dipValue - dipNumber) * 10;

                var waterNumber = (int)waterValue;
                var waterDecimal = (waterValue - waterNumber) * 10;


                var dipvolume = dt15.Rows[int.Parse((dipNumber).ToString())].Field<double>(1)
                              + (dt15.Rows[int.Parse((dipNumber + 1).ToString())].Field<double>(2) * dipDecimal);

                var waterVolume = dt15.Rows[int.Parse((waterNumber).ToString())].Field<double>(1)
                              + (dt15.Rows[int.Parse((waterNumber + 1).ToString())].Field<double>(2) * waterDecimal);

                var totalVolume = dipvolume - waterVolume;

                decimal result = 0;
                decimal.TryParse((Math.Round(totalVolume, 2)).ToString(),out result);
                return decimal.Floor(result).ToString();
            }
            return "0.00";
        }

        public string Get20KLVolume(string dip, string water)
        {
            double dipValue = 0;
            double waterValue = 0;

            if (!string.IsNullOrEmpty(dip) && double.TryParse(dip, out dipValue)
                && !string.IsNullOrEmpty(water) && double.TryParse(water, out waterValue))
            {

                dipValue = Math.Round(dipValue, 1);
                waterValue = Math.Round(waterValue, 1);

                var dipNumber = (int)dipValue;
                var dipDecimal = (dipValue - dipNumber) * 10;

                var waterNumber = (int)waterValue;
                var waterDecimal = (waterValue - waterNumber) * 10;


                var dipvolume = dt20.Rows[int.Parse((dipNumber).ToString())].Field<double>(1)
                              + (dt20.Rows[int.Parse((dipNumber + 1).ToString())].Field<double>(2) * dipDecimal);

                var waterVolume = dt20.Rows[int.Parse((waterNumber).ToString())].Field<double>(1)
                              + (dt20.Rows[int.Parse((waterNumber + 1).ToString())].Field<double>(2) * waterDecimal);

                var totalVolume = dipvolume - waterVolume;

                decimal result = 0;
                decimal.TryParse(Math.Round(totalVolume, 2).ToString(),out result);
                return decimal.Floor(result).ToString();
            }
            return "0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var service = new BillingApplicationSoapClient();
            foreach (TankDip control in panel1.Controls)
            {
                decimal test = 0;
                
                Tank dailyDip = new Tank()
                {
                    PrimaryKey = control.GetPrimaryKey(),
                    CurrentVolume = control.GetVolume(),
                    Receipt = control.GetReceipt(),
                    Sales = control.GetSales(),
                    Difference = control.GetDifference()
                };

                decimal.TryParse(control.GetFuelDip(), out test);
                dailyDip.Dip = test;
                decimal.TryParse(control.GetWaterDip(), out test);
                dailyDip.WaterDip = test;
                dailyDip.Date = date;
                dailyDip.DailyDipPrimaryKey = Guid.NewGuid();
                
                service.SaveDailyDip(dailyDip);
            }
            string status =  service.SendSMStoDealer(_smsMessage);
            MessageBox.Show("Dip details saved successfully : " + status);
            this.Close();
        }
                    
    }
}

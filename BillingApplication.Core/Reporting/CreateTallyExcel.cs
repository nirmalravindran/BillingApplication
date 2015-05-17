using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using BillingApplication.Core.DomainModels;


namespace BillingApplication.Core.Reporting
{
    public class CreateTallyExcel
    {
        private readonly string _connectionString;
        private OleDbConnection _connection;
        private DateTime _shiftDate;
        private List<string> _idVchno;

        public CreateTallyExcel(string fileName)
        {
            _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=YES;';";
            _connection = new OleDbConnection(_connectionString);
            _connection.Open();
            _idVchno = new List<string>();
        }

        public void SaveDataToExcel(IEnumerable<Bill> bills)
        {
            using (_connection)
            {
                // by creating the worksheet from scratch we can explicitly tell Excel 
                // the data type of each column
                using (OleDbCommand cmd = new OleDbCommand(@"CREATE TABLE [DATA] ([IDVchno] VARCHAR(255),
                                                            [Vch Type] VARCHAR(255),
                                                            [Date] DATE,
                                                            [Reference] VARCHAR(255),
                                                            [Ledgername] VARCHAR(255),
                                                            [Amount] DECIMAL,
                                                            [DrCr] VARCHAR(255),
                                                            [ItemName] VARCHAR(255),
                                                            [Qty] DECIMAL,
                                                            [Rate] DECIMAL,
                                                            [Godown] VARCHAR(255),
                                                            [BatchName] VARCHAR(255),
                                                            [OrderNum] VARCHAR(255),
                                                            [Order Dt] VARCHAR(255),
                                                            [Bill Type] VARCHAR(255),
                                                            [Billname] VARCHAR(255),
                                                            [Narration] VARCHAR(255))", _connection))
                    cmd.ExecuteNonQuery();
                if (bills.Any())
                    _shiftDate = bills.First().BillDate;

                foreach (var bill in bills)
                {
                    if (_idVchno.Contains(bill.VehicleNumber))
                    {
                        var i = 1;
                        while (_idVchno.Contains(bill.VehicleNumber + "_" + i.ToString()))
                        {
                            i++;
                        }
                        bill.VehicleNumber = bill.VehicleNumber + "_" + i.ToString();
                    }
                    _idVchno.Add(bill.VehicleNumber);
                    PublishMainBill(bill);
                    PublishProductBills(bill);
                }

                _connection.Close();
                
            }            
        }

        private void PublishMainBill(Bill bill)
        {
            using (OleDbCommand cmd = new OleDbCommand(@"INSERT INTO [Data] (IDVchno,
                                                            [Vch Type],
                                                            [Date] ,
                                                            [Reference] ,
                                                            [Ledgername] ,
                                                            [Amount] ,
                                                            [DrCr] ,
                                                            [Bill Type] ,
                                                            [Billname] ,
                                                            [Narration]) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)"))
            {
                cmd.Connection = _connection;

                cmd.Parameters.Add("@p1", OleDbType.VarChar);
                cmd.Parameters.Add("@p2", OleDbType.VarChar);
                cmd.Parameters.Add("@p3", OleDbType.Date);
                cmd.Parameters.Add("@p4", OleDbType.VarChar);
                cmd.Parameters.Add("@p5", OleDbType.VarChar);
                cmd.Parameters.Add("@p6", OleDbType.Decimal);
                cmd.Parameters.Add("@p7", OleDbType.VarChar);
                cmd.Parameters.Add("@p8", OleDbType.VarChar);
                cmd.Parameters.Add("@p9", OleDbType.VarChar);
                cmd.Parameters.Add("@p10", OleDbType.VarChar);
                
                cmd.Parameters["@p1"].Value = bill.VehicleNumber;
                cmd.Parameters["@p2"].Value = "Sales";
                cmd.Parameters["@p3"].Value = _shiftDate;
                cmd.Parameters["@p4"].Value = bill.VehicleNumber;
                cmd.Parameters["@p5"].Value = bill.CustomerName;
                cmd.Parameters["@p6"].Value = bill.Products.Sum(p => p.Amount);
                cmd.Parameters["@p7"].Value = "Dr";
                cmd.Parameters["@p8"].Value = "New Ref";
                cmd.Parameters["@p9"].Value = bill.BillNumber;
                cmd.Parameters["@p10"].Value = "Odometer : " + bill.Odometer + " Bill Date : " + bill.BillDate.ToString("dd:MM:yyyy hh:mm:ss");
               cmd.ExecuteNonQuery();
            }
        }

        private void PublishProductBills(Bill bill)
        {
            foreach (var billItem in bill.Products)
            {

                using (OleDbCommand cmd = new OleDbCommand(@"INSERT INTO [Data] (IDVchno,
                                                            [Vch Type] ,
                                                            [Date] ,
                                                            [Ledgername] ,
                                                            [Amount] ,
                                                            [DrCr] ,
                                                            [ItemName] ,
                                                            [Qty] ,
                                                            [Rate])  VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)"))
                {
                    cmd.Connection = _connection;

                    cmd.Parameters.Add("@p1", OleDbType.VarChar);
                    cmd.Parameters.Add("@p2", OleDbType.VarChar);
                    cmd.Parameters.Add("@p3", OleDbType.Date);
                    cmd.Parameters.Add("@p4", OleDbType.VarChar);
                    cmd.Parameters.Add("@p5", OleDbType.Decimal);
                    cmd.Parameters.Add("@p6", OleDbType.VarChar);
                    cmd.Parameters.Add("@p7", OleDbType.VarChar);
                    cmd.Parameters.Add("@p8", OleDbType.Decimal);
                    cmd.Parameters.Add("@p9", OleDbType.Decimal);
                                        
                    cmd.Parameters["@p1"].Value = bill.VehicleNumber;
                    cmd.Parameters["@p2"].Value = "Sales";
                    cmd.Parameters["@p3"].Value = _shiftDate;
                    cmd.Parameters["@p4"].Value = billItem.Product.TaxClass;
                    cmd.Parameters["@p5"].Value = billItem.Amount;
                    cmd.Parameters["@p6"].Value = "cr";
                    cmd.Parameters["@p7"].Value = billItem.Product.Name;
                    cmd.Parameters["@p8"].Value = billItem.Quantity;
                    cmd.Parameters["@p9"].Value = billItem.Product.Rate;
                                        
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}

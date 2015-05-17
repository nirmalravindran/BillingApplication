using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingApplication.WinForms.UserControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using BillingApplication.WinForms.BillingServices;

namespace BillingApplication.WinForms
{
    public partial class SampleTag : Form
    {
        Product[] _products;
        
        iTextSharp.text.Font courier = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10f);
        iTextSharp.text.Font courierBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10f, iTextSharp.text.Font.BOLD);

        public SampleTag()
        {
            InitializeComponent();
            GetInitialData();

        }

        private void GetInitialData()
        {
            var service = new BillingApplicationSoapClient();
            _products = service.GetTankableProducts();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var product = new ProductDetails();
            product.SetProduct(_products);
            product.Top = panel1.Controls.Count * 150;
            panel1.Controls.Add(product);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 40, 10, 30, 10);
            var fileName = string.Format("{0}-SampleTag.pdf", DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"));
            var cwd = System.IO.Directory.GetCurrentDirectory();
            var pdfFilePath = string.Format(@"{0}\AA\{1}", cwd, fileName);
            var wri = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
            doc.Open();

            var pageBreak = 0;
            
            foreach (ProductDetails prod in panel1.Controls)
            {
                foreach (TankDetails tank in prod.GetTankPanel().Controls)
                {
                    var sampleTable = new PdfPTable(2);
                    sampleTable.SpacingBefore = 15F;
                    sampleTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    sampleTable.TotalWidth = 500f;
                    sampleTable.LockedWidth = true;

                    var p1 = new Paragraph();
                    p1.Add(new Paragraph(new Chunk("    INDIAN OIL CORPORATION LIMITED", courierBold)));
                    p1.Add(new Paragraph(new Chunk("            NARIMANAM DEPOT", courierBold)));
                    p1.Add(new Paragraph(new Chunk("              SAMPLE TAG", courierBold)));
                    var temp = new Paragraph(new Chunk("1.Retail Outlet Name : ", courier));
                    temp.Add(new Chunk("Aruna Agencies", courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("Location : ",courier));
                    temp.Add(new Chunk("Koranad,Mayiladuthurai", courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("2.Name of the Oil Company: ", courier));
                    temp.Add(new Chunk("I.O.C.L", courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("3.Product                : ", courier));
                    temp.Add(new Chunk(prod.GetProductName(),courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("4.Source of Sample       : ", courier));
                    temp.Add(new Chunk(prod.GetSource(),courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("5.Tanker Lorry No : ", courier));
                    temp.Add(new Chunk(textBox2.Text,courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("Invoice Number    : ", courier));
                    temp.Add(new Chunk(textBox3.Text,courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("6.Sample drawn on : ", courier));
                    temp.Add(new Chunk(dateTimePicker1.Value.ToString("dd-MMM-yyyy"),courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("at :", courier));
                    temp.Add(new Chunk(textBox1.Text,courierBold));
                    temp.Add(new Chunk(" hours", courier));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("7.Density at 15 C", courier));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("a)As per challan   : ",courier));
                    temp.Add(new Chunk(prod.GetInvoiceDensity().ToString(),courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("b)Sample collected : ",courier));
                    temp.Add(new Chunk(prod.GetSampleDensity().ToString(), courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("8.Decantation Tank No.: ", courier));
                    temp.Add(new Chunk(tank.GetTankName(),courierBold));
                    p1.Add(temp);
                    p1.Add(new Paragraph(new Chunk("9.Plastic Seals Nos of Aluminium Container: ", courier)));
                    p1.Add(new Paragraph(new Chunk("10.Seals Nos. of wooden box : ", courier)));
                    p1.Add(new Paragraph(new Chunk("  Certified that empty containers had been rinsed with the product before drawing of sample in my presence and the sample is retained after proper labeling and sealing.", courier)));
                    p1.Add(new Paragraph(new Chunk("Signature of the Dealer/", courier)));
                    p1.Add(new Paragraph(new Chunk("Dealer representative   :", courier)));
                    p1.Add(new Paragraph(new Chunk("Name of the Dealer/", courier)));
                    temp = new Paragraph(new Chunk("Dealer representative   : ",courier));
                    temp.Add(new Chunk(textBox10.Text, courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("Place  and  date : ", courier));
                    temp.Add(new Chunk("Mayiladuthurai",courierBold));
                    p1.Add(temp);
                    p1.Add(new Paragraph(new Chunk("Sign of T/L Driver      : ", courier)));
                    temp = new Paragraph(new Chunk("Name of  of T/L Driver  : ", courier));
                    temp.Add(new Chunk(textBox9.Text, courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("Transporter’s  Name     : ", courier));
                    temp.Add(new Chunk(textBox8.Text, courierBold));
                    p1.Add(temp);
                    temp = new Paragraph(new Chunk("Oil Company             : ", courier));
                    temp.Add(new Chunk("I.O.C", courierBold));
                    p1.Add(temp);

                    var cell = new PdfPCell(p1);
                    sampleTable.AddCell(cell);
                    sampleTable.AddCell(cell);
                    if (pageBreak != 0 && pageBreak % 4 == 0)
                        doc.Add(new Chunk().SetNewPage());
                    pageBreak += 2;
                    doc.Add(sampleTable);
                    if (prod.GetProduct().ToString().ToUpperInvariant().Equals("7244F333-F533-438E-BBDE-83FE2ABC9C8A"))
                    {
                        if (pageBreak != 0 && pageBreak % 4 == 0)
                            doc.Add(new Chunk().SetNewPage());
                        pageBreak += 2;
                        doc.Add(sampleTable);
                    }

                    //Create domain model to save in DB
                    var productReceived = new ProductReceived()
                    {
                        InvoiceNumber = textBox3.Text,
                        PrimaryKey = Guid.NewGuid(),
                        Quantity =tank.GetQuantity(),
                        Tank = tank.GetTank(),
                        Date = DateTime.Now
                    };

                    

                    var service = new BillingApplicationSoapClient();
                    service.SaveProductReceived(productReceived);
                }
            }
            doc.Close();
            
            MessageBox.Show("Sample Tag created successfully..");
            this.Close();
        }

        private PdfPCell GetPDFPCellCourierAlignLeft(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, courier)));
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            return cell;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

    }
}

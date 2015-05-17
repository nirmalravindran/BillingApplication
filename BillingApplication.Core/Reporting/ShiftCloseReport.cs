using System;
using System.IO;
using System.Linq;
using BillingApplication.Core.DomainModels;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BillingApplication.Core.Reporting
{
    public class ShiftCloseReport
    {
        Font _courierBold = new Font(Font.FontFamily.COURIER, 10f, Font.BOLD);
        Font _courier = new Font(Font.FontFamily.COURIER, 10f);

        public Report GenerateReport(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee, Expenses[] expenses)
        {
            var pumpGenericDetails = pumps.First().PumpShiftDetails.Single();
            //var cashier = string.Format("CASHIER : {0}", pumpGenericDetails.Cashier.Name);
            //var fromDate = string.Format("FROM    : {0}", pumpGenericDetails.StartTime.ToString("dd-MM-yyyy hh-mm-ss"));
            //var toDate = string.Format("TO      : {0}", pumpGenericDetails.EndTime.ToString("dd-MM-yyyy hh-mm-ss"));
            Document doc = new Document(iTextSharp.text.PageSize.A4, 40, 10, 30, 10);
            var fileName = string.Format("{0}-{1}.pdf", pumpGenericDetails.EndTime.ToString("dd-MM-yyyy hh-mm-ss"), pumpGenericDetails.Cashier.Name);

            string pdfFilePath = string.Format(@"{0}\{1}", ConfigSettings.GetReportPath(), fileName);
            //Create Document class object and set its size to letter and give space left, right, Top, Bottom Margin
            var wri = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
            doc.Open();

            //var p1 = new Paragraph(new Chunk(cashier, _courierBold));
            //var p2 = new Paragraph(new Chunk(fromDate, _courierBold));
            //var p3 = new Paragraph(new Chunk(toDate, _courierBold));

            //doc.Add(p1);
            //doc.Add(p2);
            //doc.Add(p3);
            doc.Add(GetHeaderTable(pumpGenericDetails));
            doc.Add(GetShiftCloseTable(pumps));
            doc.Add(new Paragraph(new Chunk("CREDIT DETAILS", _courierBold)));
            doc.Add(GetBillTable(bills));
            doc.Add(new Paragraph(new Chunk("EXPENSES", _courierBold)));
            doc.Add(GetExpensesTable(expenses));
            doc.Add(GetShortageTable(pumps.SelectMany(a => a.PumpShiftDetails).Sum(a => a.Amount), bills.Sum(a => a.TotalAmount), cashPaidByEmployee, expenses.Sum(a => a.TotalAmount)));
            doc.Close();

            var fileStream = File.Open(pdfFilePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            fileStream.Close();
            string excelFilePath = string.Format(@"{0}\{1}", ConfigSettings.GetReportPath(), fileName).Replace(".pdf", ".xls");
            new CreateTallyExcel(excelFilePath).SaveDataToExcel(bills);
            return new Report { FileName = fileName, Content = bytes };
        }

        private PdfPTable GetHeaderTable(PumpShiftDetails details)
        {
            var headerTable = new PdfPTable(3);
            headerTable.SpacingBefore = 15F;
            headerTable.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTable.TotalWidth = 500f;
            headerTable.LockedWidth = true;

            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless("ARUNA AGENCIES"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("Date"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss")));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless("INDIAN OIL DEALER,"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("Cashier"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(details.Cashier.Name));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless("111 A, GANDHIJI ROAD,"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("From"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(details.StartTime.ToString("dd-MMM-yyyy hh-mm-ss")));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless("KORANAD, MAYILADUTHURAI."));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("To"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(details.EndTime.ToString("dd-MMM-yyyy hh-mm-ss")));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless(""));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("Pump Boy 1"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(""));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignCenterBorderless(""));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft("Pump Boy 2"));
            headerTable.AddCell(GetPDFPCellCourierBoldAlignLeft(""));

            float[] widths = new float[3];
            widths[0] = 55;
            widths[1] = 15;
            widths[2] = 30;
            headerTable.SetWidths(widths);

            return headerTable;
        }

        private PdfPTable GetShiftCloseTable(Pump[] pumps)
        {
            var shiftCloseTable = new PdfPTable(7);
            shiftCloseTable.SpacingBefore = 15F;
            shiftCloseTable.HorizontalAlignment = Element.ALIGN_LEFT;
            shiftCloseTable.TotalWidth = 500f;
            shiftCloseTable.LockedWidth = true;
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("ITEM"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("OPENING"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("CLOSING"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("TEST"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("SALES"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("RATE"));
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("AMOUNT"));
            foreach (var pump in pumps)
            {
                foreach (var detail in pump.PumpShiftDetails)
                {
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignLeft(pump.Name));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.OpeningReading)));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.ClosingReading)));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.Testing)));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.Sales)));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.Rate)));
                    shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(detail.Amount)));
                }
            }
            // Last row for Total
            var cell = new PdfPCell();
            shiftCloseTable.AddCell(cell);
            shiftCloseTable.AddCell(cell);
            shiftCloseTable.AddCell(cell);
            shiftCloseTable.AddCell(cell);
            shiftCloseTable.AddCell(cell);
            shiftCloseTable.AddCell(GetPDFPCellCourierBoldAlignCenter("TOTAL"));
            shiftCloseTable.AddCell(GetPDFPCellCourierAlignRight(pumps.SelectMany(a => a.PumpShiftDetails).Sum(a => a.Amount).ToString()));

            float[] widths = new float[7];
            widths[0] = 25;
            widths[1] = 15;
            widths[2] = 15;
            widths[3] = 10;
            widths[4] = 10;
            widths[5] = 10;
            widths[6] = 15;
            shiftCloseTable.SetWidths(widths);

            return shiftCloseTable;
        }

        private PdfPTable GetBillTable(Bill[] bills)
        {
            var billTable = new PdfPTable(4);
            billTable.SpacingBefore = 15F;
            billTable.HorizontalAlignment = Element.ALIGN_LEFT;
            billTable.TotalWidth = 400f;
            billTable.LockedWidth = true;

            billTable.AddCell(GetPDFPCellCourierBoldAlignCenter("NO"));
            billTable.AddCell(GetPDFPCellCourierBoldAlignCenter("NAME"));
            billTable.AddCell(GetPDFPCellCourierBoldAlignCenter("BILL NO"));
            billTable.AddCell(GetPDFPCellCourierBoldAlignCenter("AMOUNT"));
            var count = 1;
            foreach (var bill in bills)
            {
                billTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(count)));
                billTable.AddCell(GetPDFPCellCourierAlignLeft(bill.CustomerName));
                billTable.AddCell(GetPDFPCellCourierAlignLeft(bill.BillNumber));
                billTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(bill.TotalAmount)));
                count++;
            }

            // Last row for Total
            var cell = new PdfPCell();
            billTable.AddCell(cell);
            billTable.AddCell(cell);
            billTable.AddCell(GetPDFPCellCourierBoldAlignCenter("TOTAL"));
            billTable.AddCell(GetPDFPCellCourierAlignRight(bills.Sum(a => a.TotalAmount).ToString()));

            float[] widths = new float[4];
            widths[0] = 10;
            widths[1] = 75;
            widths[2] = 20;
            widths[3] = 20;
            billTable.SetWidths(widths);

            return billTable;
        }

        private PdfPTable GetExpensesTable(Expenses[] expenses)
        {
            var expensesTable = new PdfPTable(3);
            expensesTable.SpacingBefore = 15F;
            expensesTable.HorizontalAlignment = Element.ALIGN_LEFT;
            expensesTable.TotalWidth = 400f;
            expensesTable.LockedWidth = true;

            expensesTable.AddCell(GetPDFPCellCourierBoldAlignCenter("NO"));
            expensesTable.AddCell(GetPDFPCellCourierBoldAlignCenter("DESCRIPTION"));
            expensesTable.AddCell(GetPDFPCellCourierBoldAlignCenter("AMOUNT"));
            var count = 1;
            foreach (var expense in expenses)
            {
                expensesTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(count)));
                expensesTable.AddCell(GetPDFPCellCourierAlignLeft(expense.Description));
                expensesTable.AddCell(GetPDFPCellCourierAlignRight(Convert.ToString(expense.TotalAmount)));
                count++;
            }

            // Last row for Total
            var cell = new PdfPCell();
            expensesTable.AddCell(cell);
            expensesTable.AddCell(GetPDFPCellCourierBoldAlignCenter("TOTAL"));
            expensesTable.AddCell(GetPDFPCellCourierAlignRight(expenses.Sum(a => a.TotalAmount).ToString()));

            float[] widths = new float[3];
            widths[0] = 10;
            widths[1] = 70;
            widths[2] = 20;
            expensesTable.SetWidths(widths);

            return expensesTable;
        }

        private PdfPTable GetShortageTable(decimal totalSales, decimal totalCredit, decimal cashPaid, decimal totalExpenses)
        {
            var shortageTable = new PdfPTable(2);
            shortageTable.SpacingBefore = 15F;
            shortageTable.HorizontalAlignment = Element.ALIGN_LEFT;
            shortageTable.TotalWidth = 250f;
            shortageTable.LockedWidth = true;

            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("BY SALES"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(totalSales.ToString()));
            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("BY CREDIT"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(totalCredit.ToString()));
            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("BY EXPENSES"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(Math.Round(totalExpenses,2).ToString()));
            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("Balance To Pay"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(Math.Round((totalSales - totalCredit - totalExpenses),2).ToString()));
            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("CASH PAID"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(Math.Round((cashPaid * 100 / 100), 2).ToString()));
            shortageTable.AddCell(GetPDFPCellCourierBoldAlignLeft("SHORT / EXCESS"));
            shortageTable.AddCell(GetPDFPCellCourierAlignRight(Math.Round((totalCredit + totalExpenses + cashPaid - totalSales),2).ToString()));

            return shortageTable;
        }

        private PdfPCell GetPDFPCellCourierBoldAlignCenterBorderless(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, _courierBold)));
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            cell.BorderWidthLeft = 0;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            return cell;
        }

        private PdfPCell GetPDFPCellCourierBoldAlignCenter(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, _courierBold)));
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            return cell;
        }
        private PdfPCell GetPDFPCellCourierBoldAlignLeft(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, _courierBold)));
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            return cell;
        }
        private PdfPCell GetPDFPCellCourierAlignLeft(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, _courier)));
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            return cell;
        }
        private PdfPCell GetPDFPCellCourierAlignRight(string content)
        {
            var cell = new PdfPCell(new Phrase(new Chunk(content, _courier)));
            cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            return cell;
        }
    }
}

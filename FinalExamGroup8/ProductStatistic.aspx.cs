using FinalExamGroup8.model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinalExamGroup8
{
    public partial class ProductStatistic : System.Web.UI.Page
    {
        AnalysticDataUtil data = new AnalysticDataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                // Nếu không tồn tại, chuyển hướng đến trang đăng nhập
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                BindDailyStatistics();
                BindMonthlyStatistics();
                BindYearlyStatistics();
            }
        }

        private void BindDailyStatistics()
        {
            List<OrderDate> list = data.GetOrderDate("day");
            dtgDaily.DataSource = list;
            dtgDaily.DataBind();
        }

        private void BindMonthlyStatistics()
        {
            List<OrderDate> list = data.GetOrderDate("month");
            dtgMonthly.DataSource = list;
            dtgMonthly.DataBind();
        }

        private void BindYearlyStatistics()
        {
            List<OrderDate> list = data.GetOrderDate("year");
            dtgYearly.DataSource = list;
            dtgYearly.DataBind();
        }

        protected void btnExportDaily_Click(object sender, EventArgs e)
        {
            ExportGridViewToPDF(dtgDaily, "DailyStatistics.pdf", "Doanh thu theo ngày");
        }

        protected void btnExportMonthly_Click(object sender, EventArgs e)
        {
            ExportGridViewToPDF(dtgMonthly, "MonthlyStatistics.pdf", "Doanh thu theo tháng");
        }

        protected void btnExportYearly_Click(object sender, EventArgs e)
        {
            ExportGridViewToPDF(dtgYearly, "YearlyStatistics.pdf", "Doanh thu theo năm");
        }

        private void ExportGridViewToPDF(GridView gridView, string fileName, string titleDoc)
        {
            // Create a Document object
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
            string fontPath = Server.MapPath("~/fonts/arialuni.ttf"); // Font that supports Unicode characters

            // Create a MemoryStream to store the PDF data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                // Load the custom font
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(bf, 12);

                // Add a title to the PDF document
                Paragraph title = new Paragraph(titleDoc, font)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                pdfDoc.Add(title);
                pdfDoc.Add(new Paragraph(" ")); // Add a blank line

                // Create a PdfPTable with the number of columns equal to the GridView's columns
                PdfPTable table = new PdfPTable(gridView.HeaderRow.Cells.Count);

                // Add the headers from the GridView to the PdfPTable
                foreach (TableCell headerCell in gridView.HeaderRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, font))
                    {
                        Padding = 5 // Add padding to the header cells
                    };
                    table.AddCell(pdfCell);
                }

                // Add the data rows from the GridView to the PdfPTable
                foreach (GridViewRow gridViewRow in gridView.Rows)
                {
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {
                        string cellText = tableCell.Text;

                        // Check if the cell text is a date and format it if necessary
                        if (DateTime.TryParse(cellText, out DateTime dateValue))
                        {
                            cellText = dateValue.ToString("dd/MM/yyyy");
                        }

                        PdfPCell pdfCell = new PdfPCell(new Phrase(cellText, font))
                        {
                            Padding = 5 // Add padding to the data cells
                        };
                        table.AddCell(pdfCell);
                    }
                }

                // Add the table to the document
                pdfDoc.Add(table);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }



    }
}
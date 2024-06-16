using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Controllers
{
    public class PDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "dosya.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Yeşil Ayak Rezervasyon PDF Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/PDFReport/dosya.pdf", "application/pdf", "dosya.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soy Adı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Yavuz");
            pdfPTable.AddCell("Koz");
            pdfPTable.AddCell("34231224455");

            pdfPTable.AddCell("Yavuz");
            pdfPTable.AddCell("Koz");
            pdfPTable.AddCell("34231224455");

            pdfPTable.AddCell("Yavuz");
            pdfPTable.AddCell("Koz");
            pdfPTable.AddCell("34231224455");

            document.Add(pdfPTable);
            document.Close();
            return File("/PDFReport/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
    }
}

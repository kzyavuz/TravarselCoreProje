using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravarselCoreProje.Models;

namespace TravarselCoreProje.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticExcelList()
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //ExcelPackage excel = new ExcelPackage();
            //var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            //workSheet.Cells[1, 1].Value = "Etkinlik";
            //workSheet.Cells[1, 2].Value = "Rehber";
            //workSheet.Cells[1, 3].Value = "Kontenjan";

            //workSheet.Cells[2, 1].Value = "Kontenjan";
            //workSheet.Cells[2, 2].Value = "Kontenjan";
            //workSheet.Cells[2, 3].Value = "Kontenjan";

            //var bytes = excel.GetAsByteArray();
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Yenidosya.xlsx");
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    DestinationName = x.DestinationName,
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Description = x.Description,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }
        public IActionResult DestinationExcelRapor()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Etkinlik Adı";
                workSheet.Cell(1, 2).Value = "Sehir";
                workSheet.Cell(1, 3).Value = "Süre";
                workSheet.Cell(1, 4).Value = "Açıklama";
                workSheet.Cell(1, 5).Value = "Kapasite";
                workSheet.Cell(1, 6).Value = "Kişi Bası Fiyat";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.DestinationName;
                    workSheet.Cell(rowCount, 2).Value = item.City;
                    workSheet.Cell(rowCount, 3).Value = item.DayNight;
                    workSheet.Cell(rowCount, 4).Value = item.Description;
                    workSheet.Cell(rowCount, 5).Value = item.Capacity;
                    workSheet.Cell(rowCount, 6).Value = item.Price;

                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}

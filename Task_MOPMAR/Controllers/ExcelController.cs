using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.IO;

namespace Task_MOPMAR.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExcelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExcelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ExportToExcel()
        {
            var data = _context.Employees.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");
                worksheet.Cells.LoadFromCollection(data, true);
                MemoryStream stream = new MemoryStream(package.GetAsByteArray());

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }
        public IActionResult DownloadExcel()
        {
            return View();
        }
    }
}


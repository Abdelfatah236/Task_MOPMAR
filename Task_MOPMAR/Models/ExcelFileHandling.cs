using ClosedXML.Excel;

namespace Task_MOPMAR.Models
{
    public class ExcelFileHandling
    {
        public MemoryStream CreateExcelFile(List<Employee> employees)
        {
            //Create an Instance of Workbook, i.e., Creates a new Excel workbook
            var workbook = new XLWorkbook();
            //Add a Worksheets with the workbook
            //Worksheets name is Employees
            IXLWorksheet worksheet = workbook.Worksheets.Add("Employees");
            //Create the Cell
            //First Row is going to be Header Row
            worksheet.Cell(1, 1).Value = "ID"; 
            worksheet.Cell(1, 2).Value = "NationalId"; 
            worksheet.Cell(1, 3).Value = "FirstName"; 
            worksheet.Cell(1, 4).Value = "MiddleName"; 
            worksheet.Cell(1, 5).Value = "LastName";
            worksheet.Cell(1, 6).Value = "Gender";
            worksheet.Cell(1, 7).Value = "Salary";            
            worksheet.Cell(1, 8).Value = "GovernorateId";
            worksheet.Cell(1, 9).Value = "CenterId";
            worksheet.Cell(1, 10).Value ="VillageId";
            worksheet.Cell(1, 11).Value = "Governorate";
            worksheet.Cell(1, 12).Value = "Center";
            worksheet.Cell(1, 13).Value = "Village";
            int row = 2;
            //Loop Through Each Employees and Populate the worksheet
            //For Each Employee increase row by 1
            foreach (var emp in employees)
            {
                worksheet.Cell(row, 1).Value = emp.Id;
                worksheet.Cell(row, 2).Value = emp.NationalId;
                worksheet.Cell(row, 3).Value = emp.FirstName;
                worksheet.Cell(row, 4).Value = emp.MiddleName;
                worksheet.Cell(row, 5).Value = emp.LastName;
                worksheet.Cell(row, 6).Value = ((int)emp.Gender);
                worksheet.Cell(row, 7).Value = emp.Salary; 
                worksheet.Cell(row, 8).Value = emp.GovernorateId;
                worksheet.Cell(row, 9).Value = emp.CenterId;
                worksheet.Cell(row, 10).Value= emp.VillageId;
                worksheet.Cell(row, 11).Value = emp.Governorate.Name;
                worksheet.Cell(row, 12).Value = emp.Center.Name;
                worksheet.Cell(row, 13).Value = emp.Village.Name;
                row++; //Increasing the Data Row by 1
            }
            //Create an Memory Stream Object
            var stream = new MemoryStream();
            //Saves the current workbook to the Memory Stream Object.
            workbook.SaveAs(stream);
            //The Position property gets or sets the current position within the stream.
            //This is the next position a read, write, or seek operation will occur from.
            stream.Position = 0;
            return stream;
        }
    }
}
 
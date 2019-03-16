using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Project6.COM
{
    static class Example1
    {
        public static void Run()
        {
            //Demo1();
            Demo2();
        }

        static void Demo1()
        {
            var excelApp = new Excel.Application()  // new operator being used on an interface
            {
                Visible = true
            };

            var workbook = excelApp.Workbooks.Add();    // interesting... the syntax of optional argument. It's an enhacement for COM
            excelApp.Cells[1, 1].Font.FontStyle = "Bold";   // Cells[1, 1] has static type of Excel.Range but is used like dynamic. Another COM enhancement
            excelApp.Cells[1, 1].Value2 = "Hello Excel!";
            workbook.SaveAs(System.IO.Path.Combine(Environment.CurrentDirectory, "sheet.xlsx"));

            // the above anomolities happen only for COM operations.
        }

        static void Demo2()
        {
            // the old fashioned way to interact with COM

            var missingValue = System.Reflection.Missing.Value; // a value to represent a value that the COM method expects but is not supplied from .NET
            var excelApp = new Excel.Application
            {
                Visible = true,
            };

            var workbook = excelApp.Workbooks.Add(missingValue); // without COM enhancement, the syntax in Demo1 will look like this one
            var cells = (Excel.Range)excelApp.Cells[1, 1];  // Had there been not COM enhancements since C# 4.0, Cells[1, 1] could not be accessed like dynamic way. It had to be done like this one
            cells.Font.FontStyle = "Bold";
            cells.Value2 = "Hello from C# earlier than 4.0";
            workbook.SaveAs(System.IO.Path.Combine(Environment.CurrentDirectory, "sheet2.xlsx"), missingValue, missingValue, missingValue,
                missingValue, missingValue, Excel.XlSaveAsAccessMode.xlNoChange, missingValue, missingValue, missingValue, missingValue, missingValue);
        }
    }
}

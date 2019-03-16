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
            Demo1();
        }

        static void Demo1()
        {
            var excelApp = new Excel.Application()  // new operator being used on an interface
            {
                Visible = true
            };

            var workbook = excelApp.Workbooks.Add();
            excelApp.Cells[1, 1].Font.FontStyle = "Bold";   // Cells[1, 1] has static type of Excel.Range but is used like dynamic
            excelApp.Cells[1, 1].Value2 = "Hello Excel!";
            workbook.SaveAs(System.IO.Path.Combine(Environment.CurrentDirectory, "sheet.xlsx"));
        }
    }
}

using Microsoft.Office.Interop.Excel;//Nuget
using System;
using System.Runtime.InteropServices;
//https://msdn.microsoft.com/en-us/library/office/bb610378.aspx

namespace ConsoleApplication.Examples.Interop
{
    public class Excel
    {
        private static string filename = @"C:\Users\Public\Documents\Book1.xlsx";
        static void Main(string[] args)
        {
            Write();
            Read();
        }

        private static void Write()
        {
            var excel = new Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add();
            excel.Cells[1, 1].Value2 = 2;
            excel.Cells[2, 1].Value2 = 3;
            excel.Cells[3, 1].Value2 = 7;
            excel.Cells[1, 1].Font.FontStyle = "Bold";
            workbook.SaveAs(filename);
            workbook.Close(true, filename, false);
            Release(workbook);
            Release(excel);
            workbook = null;
            excel = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void Read()
        {
            var excel = new Application();
            Workbook workbook = excel.Workbooks.Open(filename);
            _Worksheet worksheet = workbook.Sheets[1];
            Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            for (int row = 1; row <= rowCount; row++)
            {
                double value = range.Cells[row, 1].Value2;
                Console.WriteLine(value);
            }
            workbook.Close(true, filename, false);
            Release(worksheet);
            Release(workbook);
            Release(excel);
            worksheet = null;
            workbook = null;
            excel = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadKey();
        }

        private static void Release(object obj)
        {
            // Errors are ignored per Microsoft's suggestion for this type of function:
            // http://support.microsoft.com/default.aspx/kb/317109
            try
            {
                Marshal.FinalReleaseComObject(obj);
            }
            catch
            {
            }
        }
    }
}

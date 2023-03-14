using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;


namespace ConsoleApp1.Lib
{
    class Fuction
    {
        public static class WebDriverFactory
        {
            private static readonly ThreadLocal<IWebDriver> threadDriver = new ThreadLocal<IWebDriver>(() =>
            {
                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                return driver;
            });

            public static IWebDriver Driver => threadDriver.Value;
        }
        

        public static string DataTable(int Row, String columnHeader)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo file = new FileInfo(@"E:\Work\Learn\Selenium\ConsoleApp1\Excel\Book1.xlsx");
            ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
            int lastRow = worksheet.Dimension.End.Row;
            int lastCol = worksheet.Dimension.End.Column;

            // Get the column by the header name
            int columnIndex = worksheet.Cells["1:1"].FirstOrDefault(cell => cell.Value.ToString() == columnHeader).Start.Column;
            var column = worksheet.Cells[Row, columnIndex].Value;
            return column.ToString();
        }

        public static int LastRowExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo file = new FileInfo(@"E:\Work\Learn\Selenium\ConsoleApp1\Excel\Book1.xlsx");
            ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
            int lastRow = worksheet.Dimension.End.Row;

            return lastRow;
        }
    }
}

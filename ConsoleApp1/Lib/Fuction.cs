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
        public static string PathProject()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            return projectDirectory.Replace("\\", "/");
        }
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
            FileInfo file = new FileInfo(Fuction.PathProject() + "/Excel/" + Main_Test.FileExcel()[0]);
            ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet worksheet = package.Workbook.Worksheets[Main_Test.FileExcel()[1]];
            int lastRow = worksheet.Dimension.End.Row;
            int lastCol = worksheet.Dimension.End.Column;

            // Get the column by the header name
            int columnIndex = worksheet.Cells["1:1"].FirstOrDefault(cell => cell.Value.ToString() == columnHeader).Start.Column;
            var column = worksheet.Cells[Row, columnIndex].Value;
            if (column != null)
            {
                return column.ToString();
            }
            else
            {
                return null;
            }
        }

        public static int LastRowExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo file = new FileInfo(Fuction.PathProject() + "/Excel/" + Main_Test.FileExcel()[0]);
            ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet worksheet = package.Workbook.Worksheets[Main_Test.FileExcel()[1]];
            int lastRow = worksheet.Dimension.End.Row;

            return lastRow;
        }
    }
}

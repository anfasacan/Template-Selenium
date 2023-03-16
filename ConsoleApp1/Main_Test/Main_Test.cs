using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using static ConsoleApp1.Lib.Fuction;
using ConsoleApp1.Lib;
using System.IO;
using OfficeOpenXml;

using System.Security.Cryptography.X509Certificates;

class Main_Test
{
    public static ExtentReports extent;

    public static void Main(string[] args)
    {
        Login_Test.Login_test();
    }
    public static String[] FileExcel()
    {
        Console.WriteLine(Fuction.PathProject());
        String[] file = Login_Test.ExcelFile().Split("||");
        return file;
    }
}

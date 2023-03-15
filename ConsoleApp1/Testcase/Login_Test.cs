using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using static ConsoleApp1.Lib.Fuction;
using ConsoleApp1.Lib;
using System.IO;
using OfficeOpenXml;

using System.Security.Cryptography.X509Certificates;

class Login_Test
{
    public static ExtentReports extent;
    static void Main(string[] args)
    {
        //Start
       
        // Create a new instance ExtentReports object And Excel Application class
        ExtentReports extent = new ExtentReports();

        // Create an ExtentHtmlReporter object
        ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Fuction.PathProject() + "/Report/index.html");

        // Attach the htmlReporter to the extent object
        extent.AttachReporter(htmlReporter);
        int LastRow = Fuction.LastRowExcel();
        for (int iteration = 2; iteration <= LastRow; iteration++)
        {
            if (Fuction.DataTable(iteration,"RUN") != null)
            {
                try
                {
                    WebDriverFactory.Driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

                    //Start Running Test
                    Lib_Menu.Login(extent, iteration);
                    Lib_Menu.Logout(extent);
                }
                catch (Exception ex)
                {
                    ExtentTest error = extent.CreateTest("Error", "There is Error");
                    Report_Lib.ScreenShot(error, ex.Message, "error");
                    continue;
                }
                    
            }   
        }
        extent.Flush();
        File.Move(Fuction.PathProject() + "/Report/index.html", Fuction.PathProject() + "/Report/" + DateTime.Now.ToString().Replace("/", "").Replace(":", "") + ".html");
        // Quit the driver
        WebDriverFactory.Driver.Quit();
        

        
    }
}

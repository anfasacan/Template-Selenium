using AventStack.ExtentReports;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Model;
using static ConsoleApp1.Lib.Fuction;

namespace ConsoleApp1.Lib
{
    class Report_Lib
    {
        public static ExtentReports extent;
        public static string screenshotPath;
        //public static ExtentReports extent = new ExtentReports();
        public static ITakesScreenshot screenshotDriver = (ITakesScreenshot)WebDriverFactory.Driver;

        public static void ScreenShot(ExtentTest Test_menu, string Description, string Information)
        {
            // Take a screenshot and save it to a file and Add the screenshot to the test report
            Thread.Sleep(2000);
            screenshotPath = "E:/Work/Learn/Selenium/ConsoleApp1/screenshot/screenshot" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".png";
            screenshotDriver.GetScreenshot().SaveAsFile(screenshotPath);
            //Console.WriteLine(Information);
            if (Information == "passed")
            {
                Test_menu.Log(Status.Pass, Description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            else if (Information == "failed")
            {
                Test_menu.Log(Status.Fail, Description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            else if (Information == "info")
            {
                Test_menu.Log(Status.Info, Description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            else if (Information == "warning")
            {
                Test_menu.Log(Status.Warning, Description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            else if (Information == "error")
            {
                Test_menu.Log(Status.Error, Description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
        public static void ExtentReports()
        {
            string reportPath = @"E:/Work/Learn/Selenium/ConsoleApp1/Report/" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".html";
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }

        public static void SaveReport()
        {
            // Flush the report to write the test results to the file

        }
    }
}

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Xml.Linq;
using static ConsoleApp1.Lib.Fuction;
using OpenQA.Selenium.DevTools.V108.Network;

namespace ConsoleApp1.Lib
{
    public class Lib_Menu
    {

        public static ITakesScreenshot screenshotDriver = (ITakesScreenshot)WebDriverFactory.Driver;

        public static void Login(ExtentReports extent,int Iteration)
        {
            // Create a test with a name and description
            ExtentTest Login = extent.CreateTest("Login", "Should Be Login To Dashboard");

            //Initiated Object Login
            IWebElement Username = WebDriverFactory.Driver.FindElement(By.Name("username"));
            IWebElement Password = WebDriverFactory.Driver.FindElement(By.Name("password"));
            IWebElement BtnSubmit = WebDriverFactory.Driver.FindElement(By.Id("submit"));

            //Do List Fill Username And Password, And Click Button Login
            Username.SendKeys(Fuction.DataTable(Iteration,"USERNAME"));
            Password.SendKeys(Fuction.DataTable(Iteration,"PASSWORD"));
            Report_Lib.ScreenShot(Login, "Fill Field Username and Password", "info");

            BtnSubmit.Click();
            IWebElement element = WebDriverFactory.Driver.FindElement(By.ClassName("post-title"));
            Report_Lib.ScreenShot(Login, "Click Button Login", "passed");
        }

        public static void Logout(ExtentReports extent)
        {
            // Create a test with a name and description
            ExtentTest Logout = extent.CreateTest("Logout", "Should Be Logout To Login Menu");

            //Initiated Object Login
            IWebElement BtnLogout = WebDriverFactory.Driver.FindElement(By.LinkText("Log out"));
            //Do List To Click Button Logout
            BtnLogout.Click();

            try
            {
                //Check If Logout Success By Detecting Object Exits Or Not 
                IWebElement Username = WebDriverFactory.Driver.FindElement(By.Name("username"));
                // Take a screenshot and save it to a file and Add the screenshot to the test report
                Report_Lib.ScreenShot(Logout, "Click Button Logout", "passed");
            }
            catch (NoSuchElementException)
            {

                Report_Lib.ScreenShot(Logout, "Logout Failed", "failed");
            }
           
        }
    }
}

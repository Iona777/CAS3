using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Capita.PruApp.BusinessTests.Phase2.Constants;

namespace Capita.PruApp.BusinessTests.Phase2.Utilities
{
    public static class Driver
    {
        public static IWebDriver driver;
        //public static WebDriverWait wait;  //Perhaps use this later

        public static void OpenBrowser(string selectedBrowser)
        {
            switch (selectedBrowser.ToLower())
            {
                case ConstantsList.fireFox:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case ConstantsList.chrome:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case ConstantsList.ie10:
                case ConstantsList.ie11:
                    {
                        driver = new InternetExplorerDriver();
                        driver.Manage().Window.Maximize();
                        break;
                    }
                default:
                    Console.WriteLine("Invalid browser type");
                    break;
            }

        }
        
        public static void NavigateTo(string targetURL)
        {
            driver.Navigate().GoToUrl(targetURL);

        }

        public static void Quit()
        {

            driver.Quit();
        }

        //Try putting the pause method into the base page so that it can be inherited by other pages

        
           
    }
}

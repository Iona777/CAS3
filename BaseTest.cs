using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Capita.PruApp.BusinessTests.Phase2.Pages;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Capita.PruApp.BusinessTests.Phase2.Tests
{
    [TestClass]
    public class BaseTest
    {
        private WebDriverWait _wait = null;

        [TestInitialize]
        public void SetUp()
        {
            Driver.OpenBrowser(ConstantsList.chrome);//CHANGE BROWSWER HERE.
            
            this._wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

            BasePage theBasePage = new BasePage();
            PageFactory.InitElements(Driver.driver, theBasePage);

        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
            
        }

        //Helper methods
        public void pause(int time)
        {
            Thread.Sleep(time);
        }

        public void moveToElement(IWebElement element)
        {
            Actions act = new Actions(Driver.driver);
            act.MoveToElement(element);
            Thread.Sleep(500);
        }

        public void scrollDown()
        {
            Console.WriteLine("In scroll down");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Console.WriteLine("end of scroll down");
            Thread.Sleep(500);
        }

        public void EnterText(string input, IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).SendKeys(input);
        }

        //The code for selecting a radio button and clicking a button are identical. 
        //Separate methods are just included for readability. Better to say what you are clicking on/selecting.

        public void SelectRadioBtn(IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public void ClickOnButton(IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }
    }
}

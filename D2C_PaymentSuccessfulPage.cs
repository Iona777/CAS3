using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class D2C_PaymentSuccessfulPage : BasePage
    {
        //Constructor
        public D2C_PaymentSuccessfulPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }

        //Fields
        [FindsBy(How = How.CssSelector, Using = "[translate ='d2c.end.title']")] 
        public IWebElement SuccessfulHeader;

        
        //Buttons
        

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(SuccessfulHeader);
            return SuccessfulHeader.Text;
        }

    }


}

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
    public sealed class D2C_SummaryPage : BasePage
    {
        //Constructor
        public D2C_SummaryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Summary')]")]
                                           
        public IWebElement SummaryHeader;


        //Buttons
        [FindsBy(How = How.CssSelector, Using = "button[class='std-btn pull-right ladda-button']")]
        private IWebElement ContinueBtn;


        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(SummaryHeader);
            return SummaryHeader.Text;

        }

        public void ClickOnContinueBtn()
        {
            Helper.ClickOnButton(ContinueBtn);
        }
    }


}

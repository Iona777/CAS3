using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class ApplicationSummaryPage : BasePage
    {
        //Constructor
        public ApplicationSummaryPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Fields
        [FindsBy(How = How.CssSelector, Using = "h1[translate='application.summary.heading']")]
        IWebElement ApplicationSummaryHeader;

        //New investor details
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[3]/div/div/ng-include[1]/div/div[1]/div/div[1]/ul/li[1]/span[2]")]
        IWebElement FullNameTextDisplay;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[3]/div/div/ng-include[1]/div/div[1]/div/div[1]/ul/li[2]/span[2]")]
        IWebElement DOBTextDisplay;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[3]/div/div/ng-include[1]/div/div[1]/div/div[1]/ul/li[3]/span[2]")]
        IWebElement AddressLine1TextDisplay;

        //Investment details  - Need to get code changed to be able to indentify the fields
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[3]/div/div/ng-include[1]/div/div[1]/div/div[1]/ul/li[3]/span[2]")]                                           
        IList<IWebElement> FundNamesTextDisplay;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[3]/div/div/ng-include[1]/div/div[1]/div/div[1]/ul/li[3]/span[2]")]
        IList<IWebElement> FundValuesTextDisplay;

        //Ongoing adviser charges
        [FindsBy(How = How.CssSelector, Using = "[translate='application.summary.ongoing-adviser-charges.percentage-and-frequency']")]
        IWebElement OngoingChargesTextDisplay; //Will need to use substring or similar to extract various parts of text for comparison


        //Regular withdrawal
        [FindsBy(How = How.CssSelector, Using = "[translate='application.summary.regular-withdrawal.summary']")]
        IWebElement RegularWithdrawalSummaryTextDisplay; //Will need to use substring or similar to extract various parts of text for comparison

        //Single investment payment details
        [FindsBy(How = How.CssSelector, Using = "[translate='application.summary.payment.single-investment.instructions']")]
        IWebElement SinglePaymentDetailsTextDisplay;


        //Investor CVI



        //Buttons
        [FindsBy(How = How.CssSelector, Using = "[translate='application.summary.submit']")]
        IWebElement SubmitBtn;

        [FindsBy(How = How.CssSelector, Using = ("button[ui-sref='app.dashboard']"))]
        public IWebElement SummaryReturntoDashboardBtn;

        //Other variables
        //A change 


        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(ApplicationSummaryHeader);
            return ApplicationSummaryHeader.Text;
        }


        public bool HeaderDisplayed()
        {
            Helper.WaitForElement(ApplicationSummaryHeader);
            return ApplicationSummaryHeader.Displayed;
        }

        public void ClickOnReturnToDashboardBtn()
        {
            Helper.ClickOnButton(SummaryReturntoDashboardBtn);
        }

        public void SubmitApplication()
        {
            Helper.ClickOnButton(SubmitBtn);

        }

        
    }
}

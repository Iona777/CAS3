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
    public sealed class D2C_InvestorDeclarationPage : BasePage
    {
        //Constructor
        public D2C_InvestorDeclarationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Investor Declaration')]")]
        public IWebElement InvestorDeclarationHeader;


        //Buttons
        [FindsBy(How = How.XPath, Using = "//label[@for='data-protection']/span[@class='checkbox-img']")]
        private IWebElement DataProtectionCheckbox;

        [FindsBy(How = How.XPath, Using = "//label[@for='allow-statements-ifa']/span[@class='checkbox-img']")]
        private IWebElement PermissionCheckbox;

        [FindsBy(How = How.XPath, Using = "//label[@for='acceptance']/span[@class='checkbox-img']")]
        private IWebElement TermsAndConditionsCheckbox;

        [FindsBy(How = How.CssSelector, Using = "button[class='std-btn pull-right ladda-button']")]
        private IWebElement ContinueBtn;

        //Other data
        IsaApplication myData;



        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(InvestorDeclarationHeader);
            return InvestorDeclarationHeader.Text;

        }

        public void ClickOnDataProtectionTickbox()
        {
            Helper.TickCheckBox(DataProtectionCheckbox);
        }

        public void ClickOnPermissionTickBox()
        {
            Helper.TickCheckBox(PermissionCheckbox);
        }

        public void ClickOnTermsAndConditionsTickBox()
        {
            Helper.TickCheckBox(TermsAndConditionsCheckbox);
        }

        public void ClickOnContinueBtn()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

        public void EnterAllValid(IsaApplication myData)
        {
            if (myData.InvestorDeclaration.OptOutOfMarketing == true)
            {
                ClickOnDataProtectionTickbox();
            }
            if (myData.InvestorDeclaration.AllowStatementsToGoToIfa == true)
            {
                ClickOnPermissionTickBox();
            }

            ClickOnTermsAndConditionsTickBox();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages.D2C_Pages
{
    [Binding]
    public sealed class D2C_NextStepsPage: BasePage
    {
        //Constructor
        public D2C_NextStepsPage(IWebDriver driver)
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        //
        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Thank you for completing the application')]")]
        public IWebElement NextStepsHeader;

        //Buttons
        [FindsBy(How= How.XPath, Using = "//*[@id='main-content']/div/main/div/div[2]/main/div/div[2]/form/div[3]/div[1]/div/div/a[1]/button/span[1]/translate")]
        private IWebElement ContinueBtn;
        

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(NextStepsHeader);
            return NextStepsHeader.Text;
        }

        public void clickOnContinueButton()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

    }
}

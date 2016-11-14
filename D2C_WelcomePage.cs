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
    public sealed class D2C_WelcomePage : BasePage
    {
        //Constructor
        public D2C_WelcomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = ("//h1[contains(.,'Welcome to the Prudential ISA application site')]"))]
        public IWebElement D2C_WelcomeHeader;

        //Buttons
        [FindsBy(How = How.CssSelector, Using = "a[class='std-btn']")]
        private IWebElement ContinueBtn;


        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(D2C_WelcomeHeader);
            return D2C_WelcomeHeader.Text;
        }

        public void ClickOnContinueBtn()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

    }
 }


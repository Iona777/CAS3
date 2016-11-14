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
    public sealed class CVIInvestor2ndPage : BasePage
    {
        //Constructor
        public CVIInvestor2ndPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }

        //Title - use Assert.IsTrue(Driver.driver.Title==CVIInvestor2_Title to check title);
        string CVIInvestor2_Title = "Confirmation of verification of identity";

        //Fields
        [FindsBy(How = How.CssSelector, Using = "[translate = 'application.confirmation-evidence.title-individual']")]
        private IWebElement CVIInvestor2Header;

        [FindsBy(How = How.CssSelector, Using = "[name = 'evidenceObtained'][value='Meets']")]
        private IWebElement EvidenceMeetsRadioBtn;

        [FindsBy(How = How.CssSelector, Using = "[name = 'evidenceObtained'][value='Exceeds']")]
        private IWebElement EvidenceExceedsRadioBtn;

        [FindsBy(How = How.CssSelector, Using = "[name = 'knowledgecheck'][value='false']")]
        private IWebElement NoReasonRadioBtn;

        [FindsBy(How = How.CssSelector, Using = "[name = 'knowledgecheck'][value='true']")]
        private IWebElement ReasonRadioBtn;

        [FindsBy(How = How.Name, Using = "referenceNumber")]
        private IWebElement RefNoTextInput;

        [FindsBy(How = How.Id, Using = "followupAction")]
        private IWebElement FollowUpActionTextBox;

        //Other variables
        IsaApplication myData;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(CVIInvestor2Header);
            return CVIInvestor2Header.Text;
        }

        public bool HeaderDisplayed()
        {
            Helper.WaitForElement(CVIInvestor2Header);
            return CVIInvestor2Header.Displayed;
        }

        public void clickOnMeetsEvidenceBtn()
        {
            Helper.ClickOnButton(EvidenceMeetsRadioBtn);
        }

        public void clickOnExceedsEvidenceBtn()
        {
            Helper.ClickOnButton(EvidenceExceedsRadioBtn);
        }

        public void clickOnNoReasonBtn()
        {
            Helper.ClickOnButton(NoReasonRadioBtn);
        }

        public void clickOnReasonBtn()
        {
            Helper.ClickOnButton(ReasonRadioBtn);
        }

        public void enterReferncenNo(string input)
        {
            Helper.EnterText(input, RefNoTextInput);
        }

        public void enterFollowUpAction(string input)
        {
            Helper.EnterText(input,FollowUpActionTextBox);
        }

        public void clickOnContinueBtn()
        {
            Helper.ClickOnButton(continueAppbtn);
        }

        public void EnterAllValid()
        {
            clickOnExceedsEvidenceBtn();
            clickOnReasonBtn();
            enterFollowUpAction("This is the follow up reason");
        }
    }
}

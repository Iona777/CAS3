using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Utilities;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class AdviserDeclarationPage : BasePage
    {
        //Constructor
        public AdviserDeclarationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Fields
        [FindsBy(How = How.CssSelector, Using = "h1[translate='application.declaration.title']")]
        IWebElement AdviserDeclarationHeader;


        [FindsBy(How = How.CssSelector, Using = "[name='isMoneyLaunderingChecksCarriedOut']")]
        IWebElement MoneyLaunderingCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[name='isConfirmationOfIdentityOfVerificationCompleted']")]
        IWebElement ConfirmationOfIdenityCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[name='isInvestorBankDetailsVerified']")]
        IWebElement InvestorBankDetailsCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[name='isSourceOfFundsVerified']")]
        IWebElement SourceOfFundsCheckbox;

        //Bank Details fields
        [FindsBy(How = How.Id, Using = "bankname")]
        private IWebElement BankNameTextInput;

        [FindsBy(How = How.Id, Using = "line1")]
        private IWebElement FirstLineTextInput;

        [FindsBy(How = How.Id, Using = "line2")]
        private IWebElement SecondLineTextInput;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement CityTextInput;

        [FindsBy(How = How.Id, Using = "county")]
        private IWebElement CountyTextInput;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement CountryDropdown;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement PostcodeTextInput;

        [FindsBy(How = How.Id, Using = "bankaccountholdername")]
        private IWebElement AccountNameTextInput;

        [FindsBy(How = How.Name, Using = "sortcode_partA")]
        private IWebElement SortCodeTextInputA;

        [FindsBy(How = How.Name, Using = "sortcode_partB")]
        private IWebElement SortCodeTextInputB;

        [FindsBy(How = How.Name, Using = "sortcode_partC")]
        private IWebElement SortCodeTextInputC;

        [FindsBy(How = How.CssSelector, Using = "[data-tid=account-number]")]                                   
        private IWebElement AccountNumberTextInput;

        //Adviser Details fields - these will need to be changed once the Data-TID attribute is added.
        [FindsBy(How = How.CssSelector, Using = "[data-tid='name']")]
        private IWebElement AdviserNameDisplay;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='address']")]
        private IWebElement AdviserAddressDisplay;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='email']")]
        private IWebElement AdviserEmailDisplay;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='telephone]")]
        private IWebElement AdviserTelephoneDisplay;

        [FindsBy(How = How.CssSelector, Using = "[translate='application.declaration.mobile']")]
        private IWebElement AdviserMobileDisplay;

        [FindsBy(How = How.CssSelector, Using = "[translate='application.declaration.fax']")]
        private IWebElement AdviserFaxDisplay;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='firm-reference']")]
        private IWebElement AdviserFRNDisplay;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='reference']")]
        private IWebElement AdviserIRNDisplay;

        //Other variables
        IsaApplication myData;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(AdviserDeclarationHeader);
            return AdviserDeclarationHeader.Text;
        }

        public bool HeaderDisplayed()
        {
            Helper.WaitForElement(AdviserDeclarationHeader);
            return AdviserDeclarationHeader.Displayed;
        }

        public void TickMoneyLaunderingCheckbox()
        {
            Helper.TickCheckBox(MoneyLaunderingCheckbox);
        }

        public void TickConfirmationOfIdenityCheckbox()
        {
            Helper.TickCheckBox(ConfirmationOfIdenityCheckbox);
        }

        public void TickInvestorBankDetailsCheckbox()
        {
            Helper.TickCheckBox(InvestorBankDetailsCheckbox);
        }

        public void TickSourceOfFundsCheckbox()
        {
            Helper.TickCheckBox(SourceOfFundsCheckbox);
        }

        public void AddNewBankAccount(string bankName, string line1, string line2, string city,
           string county, string country, string postcode, string accountName, string sortCode,
           string accountNo)
        {
            string sortCodePartA = sortCode.Substring(0, 2);
            string sortCodePartB = sortCode.Substring(2, 2);
            string sortCodePartC = sortCode.Substring(4, 2);

            Helper.EnterText(bankName, BankNameTextInput);
            Helper.EnterText(line1, FirstLineTextInput);
            Helper.EnterText(line2, SecondLineTextInput);
            Helper.EnterText(city, CityTextInput);
            Helper.EnterText(county, CountyTextInput);
            Helper.SelectByText(country, CountryDropdown);
            Helper.EnterText(postcode, PostcodeTextInput);
            Helper.EnterText(accountName, AccountNameTextInput);
            Helper.EnterText(sortCodePartA, SortCodeTextInputA);
            Helper.EnterText(sortCodePartB, SortCodeTextInputB);
            Helper.EnterText(sortCodePartC, SortCodeTextInputC);
            Helper.EnterText(accountNo, AccountNumberTextInput);

        }

       
        public bool checkAdviserDeclarationMandatoryFieldsPopulated()
        {
            string name = AdviserNameDisplay.Text;
            string address = AdviserAddressDisplay.Text;
            string email = AdviserEmailDisplay.Text;
            string frd = AdviserFRNDisplay.Text;
            string RND = AdviserIRNDisplay.Text;

            if (
                string.IsNullOrEmpty(AdviserNameDisplay.Text) ||
                string.IsNullOrEmpty(AdviserAddressDisplay.Text) ||
                string.IsNullOrEmpty(AdviserEmailDisplay.Text) ||
                string.IsNullOrEmpty(AdviserFRNDisplay.Text) ||
                string.IsNullOrEmpty(AdviserIRNDisplay.Text) 
               )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EnterAllValid(IsaApplication myData)
        {
            //myData = getJsonData();

            TickConfirmationOfIdenityCheckbox();
            TickInvestorBankDetailsCheckbox();
            TickMoneyLaunderingCheckbox();
            TickSourceOfFundsCheckbox();

            AddNewBankAccount(
                myData.AdviserDeclaration.CompanyAccount.BankName,
                myData.AdviserDeclaration.CompanyAccount.Address.Line1,
                myData.AdviserDeclaration.CompanyAccount.Address.Line2,
                myData.AdviserDeclaration.CompanyAccount.Address.City,
                myData.AdviserDeclaration.CompanyAccount.Address.County,
                myData.AdviserDeclaration.CompanyAccount.Address.Country,
                myData.AdviserDeclaration.CompanyAccount.Address.Postcode,
                myData.AdviserDeclaration.CompanyAccount.AccountHolderName,
                myData.AdviserDeclaration.CompanyAccount.Sortcode,
                myData.AdviserDeclaration.CompanyAccount.AccountNumber);
        }

        public void ClickOnContinueApplicationBtn()
        {
            Helper.ClickOnButton(continueAppbtn);
        }

     }

    }


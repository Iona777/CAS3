using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
//using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class D2C_RegularWithdrawalPage : BasePage
    {
        public D2C_RegularWithdrawalPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Regular withdrawal')]")]
        public IWebElement RegularWithdrawalHeader;

        [FindsBy(How = How.Id, Using = "amount")]
        private IWebElement WithdrawalAmountTextInput;

        [FindsBy(How = How.Name, Using = "regularInvestment")]
        private IWebElement RegularInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "transferInInvestment")]
        private IWebElement TransferInvestmentTextInput;
        
        //Although there may be many funds, there is only one set of these fields visible at any point, so multiple instances are not required
        [FindsBy(How = How.Name, Using = "editSingleInvestment")]
        private IList<IWebElement> EditSingleInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "frequency")]
        private IWebElement WithdrawalFrequencyDropdown;

        [FindsBy(How = How.Name, Using = "startDay")]
        private IWebElement DayDropdown;

        [FindsBy(How = How.Name, Using = "startMonth")]
        private IWebElement MonthTextInput;

        [FindsBy(How = How.Name, Using = "startYear")]
        private IWebElement YearTextInput;

        //Bank Details fields
        [FindsBy(How = How.Name, Using = "bankAccount")]
        private IWebElement BankAccountDropdown;

        [FindsBy(How = How.Name, Using = "bank")]
        private IWebElement BankNameTextInput;

        [FindsBy(How = How.Name, Using = "accountHolderName")]
        private IWebElement AccountNameTextInput;

        [FindsBy(How = How.Name, Using = "sortCode_partA")]
        private IWebElement SortCodeTextInputA;

        [FindsBy(How = How.Name, Using = "sortCode_partB")]
        private IWebElement SortCodeTextInputB;

        [FindsBy(How = How.Name, Using = "sortCode_partC")]
        private IWebElement SortCodeTextInputC;

        [FindsBy(How = How.CssSelector, Using = "[data-tid='account-number']")]
        private IWebElement AccountNumberTextInput;

        [FindsBy(How = How.XPath, Using = "//label[@for='is-building-society']/span[@class='checkbox-img']")]
        private IWebElement BuildingSocietyCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.buildSociety']")]
        private IWebElement RollNumberTextInput;

        [FindsBy(How = How.Name, Using = "postcode")]
        private IWebElement PostcodeTextInput;

        [FindsBy(How = How.Name, Using = "line1")]
        private IWebElement FirstLineTextInput;

        [FindsBy(How = How.Name, Using = "line2")]
        private IWebElement SecondLineTextInput;

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement CityTextInput;

        [FindsBy(How = How.Name, Using = "county")]
        private IWebElement CountyTextInput;

        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement CountryDropdown;


        //Buttons
        [FindsBy(How = How.CssSelector, Using = "[class='fa fa-chevron-up']")]
        private IList<IWebElement> EditChevronBtns;

        [FindsBy(How = How.XPath, Using = "//span[@class='detail pull-right'][contains(.,'Cancel edit')]")]
        private IWebElement CancelEditBtn;


        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='saveFund(withdrawalFund, editWithdrawalForm, $index)']"))]
        private IWebElement SaveBtn;

        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='deleteFund($index)']"))]
        private IWebElement RemoveBtn;

        [FindsBy(How = How.CssSelector, Using = "[class='confirm'][tabindex='1']")]
        private IWebElement DeleteConfirmBtn;

        [FindsBy(How = How.CssSelector, Using = "[class='cancel'][tabindex='2']")]
        private IWebElement DeleteCancelBtn;

        [FindsBy(How = How.CssSelector, Using = "[class='std-btn pull-right ladda-button'][type='submit']")]
        private IWebElement ContinueBtn;


        //Other variables
        IsaApplication myData;


    

        //Methods
        public string getHeader()
        {
            Helper.pause(1000); //Hack for intermittent synch problem
            Helper.WaitForElement(RegularWithdrawalHeader);
            return RegularWithdrawalHeader.Text;
        }
        
        public void ClickOnEditChevron(int index)
        {
            Helper.ClickOnButton(EditChevronBtns[index]);
        }

        public void ClickOnCancelEditBtn()
        {
            Helper.ClickOnButton(CancelEditBtn);
        }


        public void EnterWithdrawalAmount(string inputAmount)
        { 
            Helper.EnterText(inputAmount, WithdrawalAmountTextInput);
        }

        public void SelectWithdrawalFrequency(string frequency)
        {
            Helper.SelectByText(frequency, WithdrawalFrequencyDropdown);
        }

        public void EnterStartDate(string day, string month, string year)
        {

            Helper.SelectByText(day, DayDropdown);
            Helper.EnterText(month, MonthTextInput);
            Helper.EnterText(year, YearTextInput);
        }

        public void EnterStartDate(DateTime? inputDate)
        {
            Helper.SelectByText(inputDate.Value.Day.ToString(), DayDropdown);
            Helper.EnterText(inputDate.Value.Month.ToString(), MonthTextInput);
            Helper.EnterText(inputDate.Value.Year.ToString(), YearTextInput);
        }

       

        public void AddNewBankAccount(string bankName, string line1, string line2, string city,
            string county, string country, string postcode, string accountName, string sortCode,
            string accountNo)
        {
            string sortCodePartA = sortCode.Substring(0, 2);
            string sortCodePartB = sortCode.Substring(2, 2);
            string sortCodePartC = sortCode.Substring(4, 2);

            Helper.SelectByText("Add a new bank account", BankAccountDropdown);
            Helper.EnterText(bankName, BankNameTextInput);
            Helper.EnterText(accountName, AccountNameTextInput);
            Helper.EnterText(sortCodePartA, SortCodeTextInputA);
            Helper.EnterText(sortCodePartB, SortCodeTextInputB);
            Helper.EnterText(sortCodePartC, SortCodeTextInputC);
            Helper.EnterText(accountNo, AccountNumberTextInput);

            Helper.EnterText(postcode, PostcodeTextInput);
            Helper.EnterText(line1, FirstLineTextInput);
            if (!(line2 == null))
            {
                Helper.EnterText(line2, SecondLineTextInput);
            }
            
            Helper.EnterText(city, CityTextInput);
            Helper.EnterText(county, CountyTextInput);
            Helper.SelectByText(country, CountryDropdown);
        }

        public void TickBuildingSociety()
        {
            Helper.TickCheckBox(BuildingSocietyCheckbox);
        }


        public void EnterRollNumber(string input)
        {
            Helper.EnterText(input, RollNumberTextInput);
        }

        public void clickOnSaveBtn()
        {

            Helper.ClickOnButton(SaveBtn);
        }

        public void clickOnRemoveBtn()
        {

            Helper.ClickOnButton(RemoveBtn);
        }


        public void clickOnDeleteConfirmBtn()
        {
            Helper.ClickOnButton(DeleteConfirmBtn);
        }

        public void clickOnDeleteCancelBtn()
        {
            Helper.ClickOnButton(DeleteCancelBtn);
        }


        public void clickOnContinueBtn()
        {
            Helper.scrollDown();
            Helper.ClickOnButton(ContinueBtn);
        }


        public void EnterHardCodedAllValid()
        {
            ClickOnEditChevron(0);
            EnterWithdrawalAmount("50");
            SelectWithdrawalFrequency("Yearly");
            EnterStartDate("5","12", "2016");

            AddNewBankAccount(
                "TSB", "1 Bank Road", "Bank District", "Leeds", "West Yorkshire",
                "United Kingdom", "LS01 1AB", "J Bloggs", "121212", "12345678");
            clickOnSaveBtn();
        }

        public void EnterAllValidSingleFund(IsaApplication myData)
        {
            ClickOnEditChevron(0);
            EnterWithdrawalAmount(myData.RegularWithdrawal.WithdrawalFunds[0].Amount.ToString());
            SelectWithdrawalFrequency(myData.RegularWithdrawal.Frequency.ToString());
            EnterStartDate(myData.RegularWithdrawal.StartDate);
            AddNewBankAccount(
                myData.RegularWithdrawal.IncomeAccount.BankName,
                myData.RegularWithdrawal.IncomeAccount.Address.Line1,
                myData.RegularWithdrawal.IncomeAccount.Address.Line2,
                myData.RegularWithdrawal.IncomeAccount.Address.City,
                myData.RegularWithdrawal.IncomeAccount.Address.County,
                myData.RegularWithdrawal.IncomeAccount.Address.Country,
                myData.RegularWithdrawal.IncomeAccount.Address.Postcode,
                myData.RegularWithdrawal.IncomeAccount.AccountHolderName,
                myData.RegularWithdrawal.IncomeAccount.Sortcode,
                myData.RegularWithdrawal.IncomeAccount.AccountNumber
                );
            clickOnSaveBtn();
        }

    }
}

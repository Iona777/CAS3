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
    public sealed class DirectDebitPage : BasePage
    {
        //Constructor
        public DirectDebitPage (IWebDriver Driver)
        {
            PageFactory.InitElements(Driver,this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Direct debit')]")]
        IWebElement DirectDebitHeader;

        [FindsBy(How = How.Name, Using = "day")]
        IWebElement DDday;

        [FindsBy(How = How.Name, Using = "month")]
        IWebElement DDmonth;

        [FindsBy(How = How.Name, Using = "year")]
        IWebElement DDyear;

        [FindsBy(How = How.Name, Using = "bankAccount")]
        private IWebElement BankAccountDropdown;

        //Bank Details fields
        [FindsBy(How = How.Name, Using = "bank")]
        private IWebElement BankNameTextInput;

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

        [FindsBy(How = How.Name, Using = "postcode")]
        private IWebElement PostcodeTextInput;

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

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(DirectDebitHeader);
            return DirectDebitHeader.Text;
        }


        public void EnterDate(DateTime startDate)
        {
            //var text = startDate.ToString();
            ////"12:34:56 08/12/2014"

            //string[] splitStarteDate = startDate.ToString().Split('/');
            //string month = splitStarteDate[1];
            //string year  = splitStarteDate[2];
            //"startDate": "2016-12-06T00:00:00",


            string month = startDate.Month.ToString();
            string year = startDate.Year.ToString();

            
            Helper.EnterText(month, DDmonth);
            Helper.EnterText(year, DDyear);

            //startDate": "2016 - 12 - 06T00: 00:00",
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


        public void EnterAllValid(IsaApplication myData)
        {
            EnterDate(myData.RegularSaverPayment.StartDate);

            AddNewBankAccount(
                myData.RegularSaverPayment.DirectDebit.BankName,
                myData.RegularSaverPayment.DirectDebit.Address.Line1,
                myData.RegularSaverPayment.DirectDebit.Address.Line2,
                myData.RegularSaverPayment.DirectDebit.Address.City,
                myData.RegularSaverPayment.DirectDebit.Address.County,
                myData.RegularSaverPayment.DirectDebit.Address.Country,
                myData.RegularSaverPayment.DirectDebit.Address.Postcode,
                myData.RegularSaverPayment.DirectDebit.AccountHolderName, //Note: there is only 1 account holder at present. This may change in phase 2
                myData.RegularSaverPayment.DirectDebit.Sortcode,
                myData.RegularSaverPayment.DirectDebit.AccountNumber
                );

        }

        public void ClickOnContinueApplicationButton()
        {
            Helper.ClickOnButton(continueAppbtn);
        }



    }
}

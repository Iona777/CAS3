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
    public sealed class DonorDetailsPage : BasePage
    {
        //Constructor
        public DonorDetailsPage (IWebDriver Driver)
        {
            PageFactory.InitElements(Driver,this);
        }

        //Fields
        [FindsBy(How = How.CssSelector, Using = "h1[translate='application.donor.title']")]
        private IWebElement DonorDetailsHeader;

        [FindsBy(How = How.Name, Using = "fullname")]
        private IWebElement DonorName;

        //Address Fields
        [FindsBy(How = How.Id, Using = "line1")]
        private IWebElement FirstLineTextInput;

        [FindsBy(How = How.Id, Using = "line2")]
        private IWebElement SecondLineTextInput;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement CityTextInput;

        [FindsBy(How = How.Id, Using = "county")]
        private IWebElement CountyTextInput;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement CountryDropDown;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement Postcode;

        [FindsBy(How = How.Name, Using = "relationship")]
        private IWebElement RelationshiptTextInput;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(DonorDetailsHeader);
            return DonorDetailsHeader.Text;
        }

        public void EnterDonorName(string input)
        {
            Helper.EnterText(input,DonorName);
        }

       public void EnterPostcode(string input)
        {
            Helper.EnterText(input, Postcode);
        }

        public void EnterLine1(string input)
        {
            Helper.EnterText(input,FirstLineTextInput);
        }

        public void EnterLine2(string input)
        {
            Helper.EnterText(input, SecondLineTextInput);
        }

        public void EnterCity(string input)
        {
            Helper.EnterText(input, CityTextInput);
        }

        public void EnterCounty(string input)
        {
            Helper.EnterText(input, CountyTextInput);
        }


        public void SelectCountry(string input)
        {
            Helper.SelectByText(input, CountryDropDown);
        }

        public void EnterRelationship(string input)
        {
            Helper.EnterText(input, RelationshiptTextInput);
        }

        public void EnterAllValid(IsaApplication myData)
        {
            EnterDonorName(myData.SingleInvestmentPayment.Donor.Name);
            EnterPostcode(myData.SingleInvestmentPayment.Donor.Address.Postcode);
            EnterLine1(myData.SingleInvestmentPayment.Donor.Address.Line1);
            EnterLine2(myData.SingleInvestmentPayment.Donor.Address.Line2);
            EnterCity(myData.SingleInvestmentPayment.Donor.Address.City);
            EnterCounty(myData.SingleInvestmentPayment.Donor.Address.County);
            SelectCountry(myData.SingleInvestmentPayment.Donor.Address.Country);
            EnterRelationship(myData.SingleInvestmentPayment.Donor.RelationshipToInvestor);
        }

        public void ClickOnContinueApplicatonButton()
        {
            Helper.ClickOnButton(continueAppbtn);
        }

    }
}

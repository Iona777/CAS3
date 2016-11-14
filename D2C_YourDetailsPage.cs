using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class D2C_YourDetailsPage : BasePage
    {
        private static WebDriverWait wait2 = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));

        public D2C_YourDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Your details')]")]
        public IWebElement YourDetailsHeader;
     

        //Title and Name Fields
        [FindsBy(How = How.Id, Using = ("title"))]
        public IWebElement TitleDropdown;

        [FindsBy(How = How.Id, Using = ("titleother"))]
        public IWebElement TitleOtherTextInput;

        [FindsBy(How = How.Id, Using = ("gender"))]
        public IWebElement GenderDropdown;

        [FindsBy(How = How.Id, Using = ("forename"))]
        public IWebElement ForeNameReadOnly;

        [FindsBy(How = How.Id, Using = ("middlename"))]
        public IWebElement MiddleNameTextInput;

        [FindsBy(How = How.Id, Using = ("surname"))]
        public IWebElement SurnameReadOnly;

        //DOB Fields
        [FindsBy(How = How.Name, Using = "dobDay")]
        public IWebElement DOBDayReadOnly;

        [FindsBy(How = How.Name, Using = "dobMonth")]
        public IWebElement DOBMonthReadOnly;

        [FindsBy(How = How.Name, Using = "dobYear")]
        public IWebElement DOBYearReadOnly;

        //Nationality fields
        [FindsBy(How = How.Id, Using = "ni")]
        private IWebElement NINOTextInput;

        [FindsBy(How = How.Id, Using = "nationality")]
        private IWebElement NationalityDropDown;

        [FindsBy(How = How.Id, Using = "placeofbirth")]
        private IWebElement PlaceOfBirthTextInput;

        [FindsBy(How = How.Id, Using = "countryofbirth")]
        private IWebElement CountryOfBithDropDown;

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


        //Phone and email fields
        [FindsBy(How = How.Id, Using = "daytime")]
        private IWebElement DaytimePhone;

        [FindsBy(How = How.Id, Using = "work")]
        private IWebElement WorkPhone;

        [FindsBy(How = How.Id, Using = "home")]
        private IWebElement HomePhone;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailAddress;

        [FindsBy(How = How.Id, Using = "emailAgain")]
        private IWebElement ConfirmEmailAddress;

        //Buttons
        [FindsBy (How = How.XPath, Using = "//*[@id='main-content']/div/main/div/div[2]/form/div[2]/div/div[1]/div/button/span[1]/translate")]
        private IWebElement ContinueBtn;

        //Other variables
        IsaApplication myData;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(YourDetailsHeader);
            return YourDetailsHeader.Text;
        }


        public void SelectTitle(string selectedTitle)
        {
         //To be used if title = "Mr", "Mrs, "Miss" or "Ms"
         Helper.SelectByText(selectedTitle, TitleDropdown);           
        }

        public void SelectTitleAndGender(string selectedTitle, string selectedGender)
        {
            //To be used if title = "Dr" or "Other"
            switch (selectedTitle)
            {
                case "Mr":
                case "Mrs":
                case "Miss":
                case "Ms":
                    Helper.SelectByText(selectedTitle, TitleDropdown);
                    break;
                case "Dr":
                    Helper.SelectByText(selectedTitle, TitleDropdown);
                    Helper.SelectByText(selectedGender, GenderDropdown);
                    break;    
                default:
                    Helper.SelectByText("Other", TitleDropdown);
                    Helper.EnterText(selectedTitle, TitleOtherTextInput);
                    Helper.SelectByText(selectedGender, GenderDropdown);
                    break;
            }
         }


        

        public string GetForename()
        {
            return ForeNameReadOnly.Text;
        }

        public string GetSurname()
        {
            return SurnameReadOnly.Text;
        }

        public void EnterMiddleName(string MiddleName)
        {
            if (!(MiddleName == null))
            {
                Helper.EnterText(MiddleName, MiddleNameTextInput);
            }
            
        }

        public string GetDOB()
        {
            string dob = DOBDayReadOnly.Text + DOBMonthReadOnly.Text + DOBYearReadOnly.Text;
            return dob;
        }

        public void EnterNino(string nino)
        {
            Helper.EnterText(nino,NINOTextInput);
        }


        public void SelectNationalityByText(string input)
        {
            Helper.SelectByText(input, NationalityDropDown);
        }

        public void  EnterPlaceOfBirth(string input)
        {
            Helper.EnterText(input,PlaceOfBirthTextInput);
        }

        public void SelectCountryOfBirthByText(string input)
        {
            Helper.SelectByText(input, CountryOfBithDropDown);
        }


        public void EnterFirstLine(string input)
        {
            Helper.EnterText(input, FirstLineTextInput);
        }

        public void EnterSecondLine(string input)
        {
            if (!(input == null))
            {
                Helper.EnterText(input, SecondLineTextInput);
            }
            
        }

        public void EnterCity(string input)
        {
            Helper.EnterText(input, CityTextInput);
        }

        public void EnterCounty(string input)
        {
            Helper.EnterText(input, CountyTextInput);
        }

        public void SelectCountrybyText(string input)
        {
            Helper.SelectByText(input, CountryDropDown);
        }

        public void EnterPostCode(string input)
        {
            Helper.EnterText(input, Postcode);
        }

        public void EnterDaytimePhone(string input)
        {
            Helper.EnterText(input, DaytimePhone);
        }

        public void EnterWorkPhone(string input)
        {
            if (!(input==null))
            {
                Helper.EnterText(input, WorkPhone);
            }
            
        }

        public void EnterHomePhone(string input)
        {
            if (!(input == null))
            {
                Helper.EnterText(input, HomePhone);
            }
            
        }


        public void EnterEmailAddress(string input)
        {
            Helper.EnterText(input, EmailAddress);
        }

        public void EnterConfirmEmailAddress(string input)
        {
            Helper.EnterText(input, ConfirmEmailAddress);
        }

        public void EnterHardCodedAllValid()
        {

            SelectTitle("Mr");
            EnterMiddleName("Fred");
            //EnterNino("NW727200C"); - already entered in previous page
            SelectNationalityByText("German");
            EnterPlaceOfBirth("Munich");
            SelectCountryOfBirthByText("Germany");
            EnterPostCode("LS11 1AB");
            EnterFirstLine("1 The Street");
            EnterSecondLine("The Village");
            EnterCity("Hobbiton");
            EnterCounty("The Shire");
            SelectCountrybyText("Canada");
            EnterDaytimePhone("01131234567");
            EnterWorkPhone   ("01137894561");
            EnterHomePhone   ("01134561230");
            EnterEmailAddress       ("hardcoded@abc.com");
            EnterConfirmEmailAddress("hardcoded@abc.com");    
        }

        public void EnterAllValid(IsaApplication myData)
        {
            //Get the necessary data from data file that has been serialized into a IsaApplicaton object based on model.
            //myData = getJsonData();

            //Enter data into all the fields
            SelectTitleAndGender(myData.Investor.Title, myData.Investor.Gender.ToString());
            //Forename, surname and DOB all pulled in from previous page
            EnterMiddleName(myData.Investor.Middlename);

            //Only fill in NINO if not populated already. Because it is an input field. USe GetAttribute("value") instead of .Length
            int length = NINOTextInput.GetAttribute("value").Length;
                        
            if (length==0)
            {
                EnterNino(myData.Investor.NationalInsuranceNumber); // Enter only if not entered previously on first page
            }
    
            SelectNationalityByText(myData.Investor.Nationality);
            EnterPlaceOfBirth(myData.Investor.PlaceOfBirth);
            SelectCountryOfBirthByText(myData.Investor.CountryOfBirth);

            EnterPostCode(myData.Investor.Address.Postcode);
            EnterFirstLine(myData.Investor.Address.Line1);
            EnterSecondLine(myData.Investor.Address.Line2);
            EnterCity(myData.Investor.Address.City);
            EnterCounty(myData.Investor.Address.County);
            SelectCountrybyText(myData.Investor.Address.Country);
            
            EnterDaytimePhone(myData.Investor.DayTimeTelephone);
            EnterWorkPhone(myData.Investor.WorkTelephone);
            EnterHomePhone(myData.Investor.HomeTelephone);
            EnterEmailAddress(myData.Investor.Email);
            EnterConfirmEmailAddress(myData.Investor.Email);
            Helper.pause(2000);   
        }

        public void clickOnContinueBtn()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

    }
}
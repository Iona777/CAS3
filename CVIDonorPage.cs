using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class CVIDonorPage : BasePage
    {
        //Constructor
        public CVIDonorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Confirmation of verification of identity – private donor')]")]                                                               
        private IWebElement CVIDonorHeader;

        [FindsBy(How = How.Name, Using = "surname")]
        private IWebElement surnameTextInput;

        [FindsBy(How = How.Name, Using = "forename")]
        private IWebElement otherNamesTextInput;

        [FindsBy(How = How.Name, Using = "dobDay")]
        private IWebElement dobDayTextInput;

        [FindsBy(How = How.Name, Using = "dobMonth")]
        private IWebElement dobMonthTextInput;

        [FindsBy(How = How.Name, Using = "dobYear")]
        private IWebElement dobYearTextInput;

        //Current Address fields
        [FindsBy(How = How.Name, Using = "line1")]
        private IWebElement currentLine1TextInput;

        [FindsBy(How = How.Name, Using = "line2")]
        private IWebElement currentLine2TextInput;

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement currentCityTextInput;

        [FindsBy(How = How.Name, Using = "county")]
        private IWebElement currentCountyTextInput;

        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement currentCountryDropdown;

        [FindsBy(How = How.Name, Using = "postcode")]
        private IWebElement currentPostCodeTextInput;

        //Previous Address fields - THE REFERENCES TO ALL THESE FIELDS WILL NEED TO USE 
        //LONG AND FRAGILE XPATH REFENCES BECAUSE EDEN HAVE USED THE SAME IDS AND NAMES FOR 
        //BOTH ADDRESS AND PREVIOUS ADDRESS FIELDS

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[2]/input")]
        private IWebElement previousLine1TextInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[3]/input")]
        private IWebElement previousLine2TextInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[4]/input")]
        private IWebElement previousCityTextInput;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[5]/input")]
        private IWebElement previousCountyTextInput;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[6]")]
        private IWebElement previousCountryDropdown;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div[1]/main/div[2]/div/form/div/div[1]/div[2]/div[2]/div/div[2]/fieldset/div/div[1]/div[1]/input")]
        private IWebElement previousPostCodeTextInput;

        [FindsBy(How = How.Name, Using = "changed-address")]
        private IWebElement changedAddressCheckbox;


        //Other variables
        IsaApplication myData;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(CVIDonorHeader);
            return CVIDonorHeader.Text;
        }

        public bool HeaderDisplayed()
        {
            Helper.WaitForElement(CVIDonorHeader);
            return CVIDonorHeader.Displayed;
        }

        public void EnterSurname(string input)
        {
            Helper.EnterText(input, surnameTextInput);
        }

        public void EnterOtherNames(string input)
        {
            Helper.EnterText(input, otherNamesTextInput);
        }


        public void EnterDOB(string day, string month, string year)
        {
            Helper.EnterText(day, dobDayTextInput);
            Helper.EnterText(month,dobMonthTextInput);
            Helper.EnterText(year,dobYearTextInput);
        }


        //Enter current address fields
        public void EnterCurrentLine1(string input)
        {
            Helper.EnterText(input, currentLine1TextInput);
        }

        public void EnterCurrentLine2(string input)
        {
            Helper.EnterText(input, currentLine2TextInput);
        }

        public void EnterCurrentCity(string input)
        {
            Helper.EnterText(input, currentCityTextInput);
        }

        public void EnterCurrentCounty(string input)
        {
            Helper.EnterText(input,currentCountyTextInput);
        }


        public void SelectCurrentCountry(string input)
        {
            Helper.SelectByText(input, currentCountryDropdown);
        }

        public void EnterCurrentPostcode(string input)
        {
            Helper.EnterText(input, currentPostCodeTextInput);
        }


        public void TickChangedAddress()
        {
            Helper.TickCheckBox(changedAddressCheckbox);
        }


        //Enter previous address fields
        public void EnterPreviousLine1(string input)
        {
            Helper.EnterText(input, previousLine1TextInput);
        }

        public void EnterPreviousLine2(string input)
        {
            Helper.EnterText(input, previousLine2TextInput);
        }

        public void EnterPreviousCity(string input)
        {
            Helper.EnterText(input, previousCityTextInput);
        }

        public void EnterPreviousCounty(string input)
        {
            Helper.EnterText(input, previousCountyTextInput);
        }


        public void SelectPreviousCountry(string input)
        {
            Helper.SelectByText(input, previousCountryDropdown);
        }

        public void EnterPreviousPostcode(string input)
        {
            Helper.EnterText(input, previousPostCodeTextInput);
        }

        public void EnterAllValidPrevious(IsaApplication myData)
        {
            EnterPreviousPostcode(myData.DonorConfirmationOfVerificationOfIdentity.Previous.Postcode);
            EnterPreviousLine1(myData.DonorConfirmationOfVerificationOfIdentity.Previous.Line1);
            EnterPreviousLine2(myData.DonorConfirmationOfVerificationOfIdentity.Previous.Line2);
            EnterPreviousCity(myData.DonorConfirmationOfVerificationOfIdentity.Previous.City);
            EnterPreviousCounty(myData.DonorConfirmationOfVerificationOfIdentity.Previous.County);
            SelectPreviousCountry(myData.DonorConfirmationOfVerificationOfIdentity.Previous.Country);

        }

        public bool checkMandatoryFieldsNotNull()
        {

            if (
                
                checkFieldNotNull(surnameTextInput)         &&
                checkFieldNotNull(otherNamesTextInput)      &&
                checkFieldNotNull(dobDayTextInput)          &&
                checkFieldNotNull(dobMonthTextInput)        &&
                checkFieldNotNull(dobYearTextInput)         &&
                checkFieldNotNull(currentLine1TextInput)    &&
                checkFieldNotNull(currentCityTextInput)     &&
                checkFieldNotNull(currentCountryDropdown)   &&
                checkFieldNotNull(currentPostCodeTextInput) 
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearNameFields()
        {
            surnameTextInput.Clear();
            otherNamesTextInput.Clear();
        }

        public void clickOnContinueApplicationBtn()
        {
            Helper.ClickOnButton(continueAppbtn);

        }


    }

}

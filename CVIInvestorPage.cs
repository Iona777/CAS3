using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class CVIInvestorPage : BasePage
    {
        //Constructor
        public CVIInvestorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        
        }

        //Title - use Assert.IsTrue(Driver.driver.Title==CVIInvestor_Title to check title);
        string CVIInvestor_Title = "Confirmation of verification of identity";

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Confirmation of verification of identity – private individual')]")]                                                               
        private IWebElement CVIInvestorHeader;

       // [FindsBy(How = How.Name, Using = "surname")]
        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.surname']")]
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

        //Previous Address fields - THE REFERENCES TO ALL THESE FIELDS WILL NEED TO BE CHANGED. 
        //EITHER WHEN EDEN ADD DATA-TID OR TO LONG AND FRAGILE XPATH REFENCES
        [FindsBy(How = How.Name, Using = "previous_line1")]
        private IWebElement previousLine1TextInput;

        [FindsBy(How = How.Name, Using = "previous_line2")]
        private IWebElement previousLine2TextInput;

        [FindsBy(How = How.Name, Using = "previous_city")]
        private IWebElement previousCityTextInput;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.previous.county'][Name='county']")]
        private IWebElement previousCountyTextInput;

        [FindsBy(How = How.Name, Using = "previous_country")]
        private IWebElement previousCountryDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.previous.postcode'][Name='previous_postcode']")]
        private IWebElement previousPostCodeTextInput;

        [FindsBy(How = How.Name, Using = "changed-address")]
        private IWebElement changedAddressCheckbox;


        //Other variables
        IsaApplication myData;
        private static WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(30));


        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(CVIInvestorHeader);
            return CVIInvestorHeader.Text;
        }

        public bool HeaderDisplayed()
        {
            Helper.WaitForElement(CVIInvestorHeader);
            return CVIInvestorHeader.Displayed;
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

        

        public bool checkMandatoryFieldsNotNull()
        {
            Helper.pause(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("surname")));
            
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

        public void clickOnContinueApplicationBtn()
        {
            Helper.ClickOnButton(continueAppbtn);

        }


    }

}

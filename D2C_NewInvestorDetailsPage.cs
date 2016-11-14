using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public sealed class D2C_NewInvestorDetailsPage : BasePage
    {

        //Class constructor
        public D2C_NewInvestorDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'New/Existing investor')]")]
        public IWebElement NewInvestorDetailsHeader;
     

        //Name Fields
        [FindsBy(How = How.Id, Using = ("forename"))]
        public IWebElement ForenameTextInput;

        [FindsBy(How = How.Id, Using = ("surname"))]
        public IWebElement SurnameTextInput;

        //Date of birth Fields
        [FindsBy(How = How.Name, Using = "dobDay")]
        public IWebElement DOBDayTextInput;

        [FindsBy(How = How.Name, Using = "dobMonth")]
        public IWebElement DOBMonthTextInput;

        [FindsBy(How = How.Name, Using = "dobYear")]
        public IWebElement DOBYearTextInput;


        //Other fields
        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement Postcode;

        
        [FindsBy(How = How.Id, Using = "ni")]
        private IWebElement Nino;


        //Buttons
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/main/div/div[2]/form/div[2]/div/div[1]/div/button/span[1]/translate")]
        //[FindsBy(How = How.CssSelector, Using = "button['type='submit']")]
        private IWebElement ContinueBtn;


        //Other variables
        IsaApplication myData;

        //Methods
        public string getHeader()
        {
            Helper.WaitForElement(NewInvestorDetailsHeader);
            return NewInvestorDetailsHeader.Text;
        }


        public void EnterForename(string input)
        {
            Helper.EnterText(input, ForenameTextInput);
        }

        public void EnterSurname(string input)
        {
            Helper.EnterText(input, SurnameTextInput);
        }

        public void EnterDOB(string day, string month, string year)
        {
            Helper.EnterText(day, DOBDayTextInput);
            Helper.EnterText(month, DOBMonthTextInput);
            Helper.EnterText(year, DOBYearTextInput);
        }

        //Overload EnterDOB so that we can take input in form of DateTime object since that is what the model uses.
        public void EnterDOB(DateTime? dob)
        {
            Helper.EnterText(dob.Value.Day.ToString(), DOBDayTextInput);
            Helper.EnterText(dob.Value.Month.ToString(), DOBMonthTextInput);
            Helper.EnterText(dob.Value.Year.ToString(), DOBYearTextInput);
        }

        
        public void EnterPostCode(string input)
        {
            Helper.EnterText(input, Postcode);
        }

        

        public void EnterNino(string input)
        {
            Helper.EnterText(input, Nino);
        }



        public void EnteHardCodedAllValid()
        {
            EnterForename("Harry");
            EnterSurname("Hardcoded-Data");
            EnterDOB("22","12","1975");
            EnterPostCode("LS11 0NE");
            EnterNino("NW727200C");
        }
        
        public void EnterAllValid(IsaApplication myData)
        {
            //Get the necessary data from data file that has been serialized into a IsaApplicaton object based on model.
            //myData = getJsonData();

            //Enter data into all the fields
            EnterForename(myData.Investor.Forename);
            EnterSurname(myData.Investor.Surname);
            EnterDOB(myData.Investor.DateOfBirth);          
            EnterPostCode(myData.Investor.Address.Postcode);
            EnterNino(myData.Investor.NationalInsuranceNumber); 
            Helper.pause(2000);   
        }

        public void clickOnContinueBtn()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

    }
}
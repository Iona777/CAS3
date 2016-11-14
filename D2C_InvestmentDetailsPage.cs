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
    public sealed class D2C_InvestmentDetailsPage : BasePage
    {
        public D2C_InvestmentDetailsPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        //Fields
        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Investment details')]")]
        public IWebElement InvestmentDetailsHeader;


        //h1[contains(.,'Investment details')]

        //Like the EditPencil elements, there will be dropdowns for each fund, so need to use list if using multiple funds
        [FindsBy(How = How.Name, Using = "fund-name")]
        private IList<IWebElement> FundNameDropDown;

        [FindsBy(How = How.Name, Using = "singleInvestment")]
        private IWebElement SingleInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "regularInvestment")]
        private IWebElement RegularInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "transferInInvestment")]
        private IWebElement TransferInvestmentTextInput;

        //Fields for editing
        public int fundCount = 0; //Incremented every time a fund is selected.  Used to select correct EditPencil and fund name

        [FindsBy(How = How.Name, Using = "editSingleInvestment")]
        private IList<IWebElement> EditSingleInvestmentTextInputs;

        [FindsBy(How = How.Name, Using = "editRegularInvestment")]
        private IList<IWebElement> EditRegularInvestmentTextInputs;

        [FindsBy(How = How.Name, Using = "editTranferInInvestmentPercentage")]
        private IList<IWebElement> EditTransferInInvestmentTextInputs;


        //Funds fields
        [FindsBy(How = How.XPath, Using = ("//*[contains(text(),'Prudential PruFund')]"))]
        private IList<IWebElement> AllPruFunds;
  

        //Buttons
        [FindsBy(How = How.CssSelector, Using = "label[for='single-investment']")]
        private IWebElement SingleInvestmentTickBox;

        [FindsBy(How = How.CssSelector, Using = "label[for='regular-investment']")]
        private IWebElement RegularInvestmentTickBox;

        [FindsBy(How = How.CssSelector, Using = "label[for='transfer-in']")]
        private IWebElement TransferInInvestmentTickBox;



        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='addNewFund()']"))]
        private IWebElement AddNewFundBtn;

        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='addFund(addFundForm)']"))]
        private IWebElement AddFundBtn;


        [FindsBy(How = How.CssSelector, Using = "[class='instruction'][ng-hide='fund.editMode']")]
        private IList<IWebElement> EditPencilBtns;

        [FindsBy(How = How.CssSelector, Using = "[class='instruction'][ng-show='fund.editMode']")]
        private IList<IWebElement> CancelPencilBtns;


        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='saveFund(fund, editFundForm, $index)']"))]
        private IList<IWebElement> SaveFundBtns;

        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='deleteFund($index)']"))]
        private IList<IWebElement> RemoveFundBtns;

        [FindsBy(How = How.CssSelector, Using = "[class='confirm'][tabindex='1']")]
        private IWebElement DeleteConfirmBtn;

        [FindsBy(How = How.CssSelector, Using = "[class='cancel'][tabindex='2']")]
        private IWebElement DeleteCancelBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/main/div/div[2]/form/div[2]/div/div[1]/div/button/span[1]/translate")]
        private IWebElement ContinueBtn;

        //Other variables
        IsaApplication mydata;


        //Methods
        public string getHeader()
        {
            Helper.pause(1000); //Hack for intermittent synch problem
            Helper.WaitForElement(InvestmentDetailsHeader);
            return InvestmentDetailsHeader.Text;

        }
        public void SelectFundByName(string fundText, int index)
        {
            Helper.SelectByText(fundText, FundNameDropDown[index]);
            fundCount++;
        }    


        public void SelectFundByIndex(int index, int optionIndex)
        {
            Helper.SelectByIndex(optionIndex, FundNameDropDown[index]);
            fundCount++;
        }


        //Enter Investment Amounts
        public void EnterSingleInvestment(string inputAmount)
        {
          
            Helper.EnterText(inputAmount, SingleInvestmentTextInput);
        }

        public void EnterRegularInvestment(string inputAmount)
        {
         
            Helper.EnterText(inputAmount, RegularInvestmentTextInput);
        }

        public void EnterTransferInInvestment(string inputAmount)
        {
         
            Helper.EnterText(inputAmount, TransferInvestmentTextInput);
        }

        

        //Edit investment amounts
        public void EditSingleInvestment(string inputAmount, int fundNo)
        {
            //All single investment edit fields have same id. So the IWebelements are in a list. Use fundNo
            //to refer to select which fund you want to edit a single investment for.
            //Input index starts at 1 for convenience

            Helper.ClickOnButton(EditPencilBtns[fundNo-1]);
            //clickOnEditPencilBtn(fundNo-1);
            EditSingleInvestmentTextInputs[fundNo-1].Clear();
            Helper.EnterText(inputAmount, EditSingleInvestmentTextInputs[fundNo-1]);
        }



        public void EditRegularInvestment(string inputAmount, int fundNo)
        {
            //All regular investment edit fields have same id. So the IWebelements are in a list. Use fundNo
            //to refer to select which fund you want to edit a regular investment for.
            //Input index starts at 1 for convenience

            Helper.ClickOnButton(EditPencilBtns[fundNo-1]);
            EditRegularInvestmentTextInputs[fundNo-1].Clear();
            Helper.EnterText(inputAmount, EditRegularInvestmentTextInputs[fundNo-1]);
        }

        

        public void EditTransferInInvestment(string inputAmount, int fundNo)
        {
            //All transfer in investment edit fields have same id. So the IWebelements are in a list. Use fundNo
            //to refer to select which fund you want to edit a transfer in investment for.
            //Input index starts at 1 for convenience

            Helper.ClickOnButton(EditPencilBtns[fundNo - 1]);
            EditTransferInInvestmentTextInputs[fundNo - 1].Clear();
            Helper.EnterText(inputAmount, EditTransferInInvestmentTextInputs[fundNo - 1]);
        }

        public void tickSingleInvestment()
        {
            Helper.TickCheckBox(SingleInvestmentTickBox);
        }

        public void tickRegularInvestment()
        {
            Helper.TickCheckBox(RegularInvestmentTickBox);
        }

        public void tickTransferInInvestment()
        {
            Helper.TickCheckBox(TransferInInvestmentTickBox);
        }

        public void clickOnAddNewFundBtn()
        {
            Helper.ClickOnButton(AddNewFundBtn);
        }


        public void clickonAddFundBtn(int fundNo)
        {

            Helper.ClickOnButton(AddFundBtn);
        }

        public void clickOnEditPencilBtn(int fundNo)
        {
            
            Helper.ClickOnButton(EditPencilBtns[fundNo-1]);
        }

        public void clickOnCancelPencilBtn(int fundNo)
        {

            Helper.ClickOnButton(CancelPencilBtns[fundNo-1]);
        }

        public void clickOnSaveFundBtn(int fundNo)
        {

            Helper.ClickOnButton(SaveFundBtns[fundNo-1]);
        }

        public void clickOnRemoveFundBtn(int fundNo)
        {

            Helper.ClickOnButton(RemoveFundBtns[fundNo-1]);
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

        public void DeleteAllFunds()
        {
            for (int i = 1; i <= fundCount; i++)
            {
                //Assuming that number of pencil buttons reduces as they are deleted
                //so using index of 0 will always refer to the first one available.
                clickOnEditPencilBtn(0);
                clickOnRemoveFundBtn(0);
                clickOnDeleteConfirmBtn();
            }
        }



        public void EnterAllValidSingleInvestment()
        {
            Helper.pause(1000);

            //Enter a payment
            tickSingleInvestment();
            clickOnAddNewFundBtn();
            //1st time round, fundCount=0, so will select 0th index (1st element) in IList of funds. 
            //subsequent interations will select 2nd, 3rd etc. elements of IList of funds as fundCount is incremented
            SelectFundByIndex(fundCount,1); 
            EnterSingleInvestment("1000");
            clickonAddFundBtn(fundCount); //This method will take 1 from fundCount to get right element in AddFundBtn IList

            Helper.pause(2000);
        }

        public void EnterAllValidRegularInvestment()
        {
            //Enter a payment
            tickRegularInvestment();
            clickOnAddNewFundBtn();
            //1st time round, fundCount=0, so will select 0th index (1st element) in IList of funds. 
            //subsequent interations will select 2nd, 3rd etc. elements of IList of funds as fundCount is incremented
            SelectFundByIndex(fundCount,1);
            EnterRegularInvestment("200");
            clickonAddFundBtn(fundCount); //This method will take 1 from fundCount to get right element in AddFundBtn IList

            Helper.pause(2000);
        }

        public void EnterAllValidTransferIn()
        {
            //Enter a payment
            tickTransferInInvestment();
            clickOnAddNewFundBtn();
            //1st time round, fundCount=0, so will select 0th index (1st element) in IList of funds. 
            //subsequent interations will select 2nd, 3rd etc. elements of IList of funds as fundCount is incremented
            SelectFundByIndex(fundCount,1);
            EnterTransferInInvestment("100");
            clickonAddFundBtn(fundCount); //This method will take 1 from fundCount to get right element in AddFundBtn IList

            Helper.pause(2000);
        }

    }
}

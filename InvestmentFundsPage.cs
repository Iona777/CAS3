using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Constants;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class InvestmentFundsPage : BasePage
    {
        public InvestmentFundsPage(IWebDriver Driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        //Fields
        [FindsBy(How = How.CssSelector, Using = "h1[translate='application.funds.title']")]
        private IWebElement InvestmentFundsHeader;

        [FindsBy(How = How.Name, Using = "fundName")]
        private IWebElement FundNameDropDown;

        [FindsBy(How = How.Name, Using = "singleInvestmentAmount")]
        private IWebElement SingleInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "regularMonthlyInvestmentAmount")]
        private IWebElement RegularInvestmentTextInput;

        [FindsBy(How = How.Name, Using = "tranferInInvestmentPercentage")]
        private IWebElement TransferInvestmentTextInput;

        //Fields for editing
        [FindsBy(How = How.Name, Using = "editSingleInvestmentAmount")]
        private IList<IWebElement> EditSingleInvestmentTextInputs;

        [FindsBy(How = How.Name, Using = "editRegularMonthlyInvestmentAmount")]
        private IList<IWebElement> EditRegularInvestmentTextInputs;

        [FindsBy(How = How.Name, Using = "editTranferInInvestmentPercentage")]
        private IList<IWebElement> EditTransferInvestmentTextInputs;


        //Funds fields
        [FindsBy(How = How.XPath, Using = ("//*[contains(text(),'Prudential PruFund')]"))]
        private IList<IWebElement> AllPruFunds;


        [FindsBy(How = How.XPath, Using = ("//*[contains(text(),'CF Prudential')]"))]
        private IList<IWebElement> AllCFFunds;


        //Buttons
        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.currentTaxYear'][value='true']")]
        private IWebElement CurrentTaxYearRadiobtn;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.currentTaxYear'][value='false']")]
        private IWebElement NextTaxYearRadiobtn;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='model.isAdvised'][value='true']")]
        private IWebElement AdviceYesRadiobtn;

         [FindsBy(How = How.CssSelector, Using = "[ng-model='model.isAdvised'][value='false']")]
        private IWebElement AdviceNoRadiobtn;

        [FindsBy(How = How.CssSelector, Using = ("button[ng-click='addFund(newFundForm)']"))]
        private IWebElement AddBtn;

        [FindsBy(How = How.CssSelector, Using = ("[translate='core.delete']"))]
        private IList<IWebElement> DeleteBtns;

        [FindsBy(How = How.ClassName, Using = "confirm")]
        private IWebElement DeleteConfirmBtn;

        [FindsBy(How = How.ClassName, Using = "cancel")]
        private IWebElement DeleteCancelBtn;

        [FindsBy(How = How.CssSelector, Using = ("[translate='core.edit']"))]
        private IList<IWebElement> EditBtns;

        [FindsBy(How = How.CssSelector, Using = ("[translate='core.save']"))]
        private IList<IWebElement> SaveBtns;

        [FindsBy(How = How.CssSelector, Using = ("[translate='core.cancel']"))]
        private IList<IWebElement> CancelBtns;

        //Other variables
        IsaApplication mydata;


        //Methods
        public string getHeader()
        {
            Helper.pause(1000); //Hack for intermittent synch problem
            Helper.WaitForElement(InvestmentFundsHeader);
            return InvestmentFundsHeader.Text;

        }
        public void SelectAdviceYesBtn()
        {
            Helper.SelectRadioBtn(AdviceYesRadiobtn);
        }

        public void SelectAdviceNoBtn()
        {
            Helper.SelectRadioBtn(AdviceNoRadiobtn);
        }

        public void SelectCurrentTaxYearBtn()
        {
            Helper.SelectRadioBtn(CurrentTaxYearRadiobtn);
        }

        public void SelectNextTaxYearBtn()
        {
            Helper.SelectRadioBtn(NextTaxYearRadiobtn);
        }

        public void SelectFundByName(string fundName)
        {
            Helper.SelectByText(fundName, FundNameDropDown);
        }


        public void SelectFundByIndex(int index)
        {
            Helper.SelectByIndex(index, FundNameDropDown);
        }

        public void EnterSingleInvestment(string inputAmount)
        {
            Helper.EnterText(inputAmount, SingleInvestmentTextInput);
        }

        public void EditSingleInvestment(string inputAmount)
        {
            int index = EditSingleInvestmentTextInputs.Count - 1;
            EditSingleInvestmentTextInputs[index].Clear();
            Helper.EnterText(inputAmount, EditSingleInvestmentTextInputs[index]);
        }

        public void EnterRegularInvestment(string inputAmount)
        {
            Helper.EnterText(inputAmount, RegularInvestmentTextInput);
        }

        public void EditRegularInvestment(string inputAmount)
        {
            int index = EditRegularInvestmentTextInputs.Count - 1;
            EditRegularInvestmentTextInputs[index].Clear();
            Helper.EnterText(inputAmount, EditRegularInvestmentTextInputs[index]);
        }

        public void EnterTransferInvestment(string inputAmount)
        {
            Helper.EnterText(inputAmount, TransferInvestmentTextInput);
        }

        public void EditTransferInvestment(string inputAmount)
        {
            int index = EditTransferInvestmentTextInputs.Count - 1;
            EditTransferInvestmentTextInputs[index].Clear();
            Helper.EnterText(inputAmount, EditTransferInvestmentTextInputs[index]);
        }

        public void SelectMultipleCFFFunds(int noOfFunds, double investmentAmount, string investmentType)
        {
            for (int index = 0; index < noOfFunds; index++)
            {
                if (investmentType == ConstantsList.TransferInPayment)
                {
                    //Total input amount must = 100. Need to make the 100 double to force the calcualtion result to be a dobule
                    double input = (100d / noOfFunds);

                    SelectACFFFund(input, index, investmentType);
                }
                else
                {
                    SelectACFFFund(investmentAmount, index, investmentType);
                }
            }
        }


        public void SelectACFFFund(double investmentAmount, int fundIndex, string investmentType)
        {
            Helper.scrollDown();

            switch (investmentType)
            {
                case ConstantsList.SinglePayment:
                    Helper.ClickOnButton(AllCFFunds[fundIndex]);
                    EnterSingleInvestment(investmentAmount.ToString());
                    clickOnAddBtn();
                    break;
                case ConstantsList.RegularPayment:
                    Helper.ClickOnButton(AllCFFunds[fundIndex]);
                    EnterRegularInvestment(investmentAmount.ToString());
                    clickOnAddBtn();
                    break;
                case ConstantsList.TransferInPayment:
                    Helper.ClickOnButton(AllCFFunds[fundIndex]);
                    EnterTransferInvestment(investmentAmount.ToString());
                    clickOnAddBtn();
                    break;
                default:
                    Console.WriteLine("Invalid investment type selected");
                    break;

            }

        }

        public void SelectAllCFFunds(string investmentType)
        {
            int singleInvestmentAmount = 1000;
            int regularInvestmentAmount = 200;
            //Total input amount must = 100
            double transferInvestmentPercent = 100d / AllCFFunds.Count;

            Helper.pause(1000);
            switch (investmentType)
            {
                case ConstantsList.SinglePayment:
                    for (int i = 0; i < AllCFFunds.Count; i++)
                    {
                        Helper.ClickOnButton(AllCFFunds[i]);
                        EnterSingleInvestment(singleInvestmentAmount.ToString());
                        clickOnAddBtn();
                    }
                    break;

                case ConstantsList.RegularPayment:
                    for (int i = 0; i < AllCFFunds.Count; i++)
                    {
                        Helper.ClickOnButton(AllCFFunds[i]);
                        EnterRegularInvestment(regularInvestmentAmount.ToString());
                        clickOnAddBtn();
                    }
                    break;

                case ConstantsList.TransferInPayment:
                    for (int i = 0; i < AllCFFunds.Count; i++)
                    {  
                        Helper.ClickOnButton(AllCFFunds[i]);
                        EnterTransferInvestment(transferInvestmentPercent.ToString());
                        clickOnAddBtn();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid investment type selected");
                    break;
            }

        }

        public void clickOnAddBtn()
        {
            Helper.ClickOnButton(AddBtn);
        }

        public void clickOnEditBtn()
        {
            int index = EditBtns.Count - 1;
            Helper.ClickOnButton(EditBtns[index]);
        }

        public void clickOnSaveBtn()
        {
            int index = SaveBtns.Count - 1;
            Helper.ClickOnButton(SaveBtns[index]);
        }



        public void clickOnCancelBtn()
        {
            int index = CancelBtns.Count - 1;
            Helper.ClickOnButton(CancelBtns[index]);
        }

        public void clickOnDeleteBtn()
        {
            int index = DeleteBtns.Count - 1;
            Helper.ClickOnButton(DeleteBtns[index]);
            Helper.ClickOnButton(DeleteConfirmBtn);
        }


        public void clickOnContinueApplicationBtn()
        {
            Helper.ClickOnButton(continueAppbtn);
        }

        public void DeleteAllFunds()
        {
            while(DeleteBtns.Count>0)
            {
                clickOnDeleteBtn();
            }

        }

        public void EnterAllValidSingleInvestment()
        {

            //Only had this in to check buttons worked
            //SelectAdviceNoBtn();
            //Helper.pause(1000);
            //SelectAdviceYesBtn();
            //Helper.pause(1000);
            //SelectNextTaxYearBtn();
            //Helper.pause(1000);
            //SelectCurrentTaxYearBtn(); 

            Helper.pause(1000);

            //Enter a payment
            SelectFundByIndex(1);
            EnterSingleInvestment("1000");
            clickOnAddBtn();
            Helper.pause(2000);
        }

        public void EnterAllValidRegularInvestment()
        {
            SelectAdviceNoBtn();
            Helper.pause(1000);
            SelectAdviceYesBtn();
            Helper.pause(1000);
            SelectNextTaxYearBtn();
            Helper.pause(1000);
            SelectCurrentTaxYearBtn();
            Helper.pause(1000);

            //Enter a payment
            SelectFundByIndex(1);
            EnterRegularInvestment("500");
            clickOnAddBtn();
            Helper.pause(2000);
        }

        public void EnterAllValidTransferIn()
        {
            SelectAdviceNoBtn();
            Helper.pause(1000);
            SelectAdviceYesBtn();
            Helper.pause(1000);
            SelectNextTaxYearBtn();
            Helper.pause(1000);
            SelectCurrentTaxYearBtn();
            Helper.pause(1000);

            //Enter a payment
            SelectFundByIndex(1);
            EnterTransferInvestment("100");
            clickOnAddBtn();
            Helper.pause(2000);
        }

    }
}

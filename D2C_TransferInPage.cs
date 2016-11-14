using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    [Binding]
    public sealed class D2C_TransferInPage : BasePage
    {
        //Constructor
        public D2C_TransferInPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
         
        //Fields
        [FindsBy( How = How.XPath, Using ="//h1[contains(.,'Transfer in')]")]
        public IWebElement TransferInHeader;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='isaManager.name']")]
        private IWebElement ISAManagerTextInput;

        [FindsBy(How = How.Id, Using = "line1")]
        private IWebElement Line1TextInput;

        [FindsBy(How = How.Id, Using = "line2")]
        private IWebElement Line2TextInput;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement CityTextInput;

        [FindsBy(How = How.Id, Using = "county")]
        private IWebElement CountyTextInput;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement CountryDropdown;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement PostcodeTextInput;

        [FindsBy(How = How.Name, Using = "planReference")]
        private IList<IWebElement> PlanRefTextInput;

        [FindsBy(How = How.CssSelector, Using = "[translate='application.transfer-in.transfer-previous-year']")]
        private IList<IWebElement> PreviousTaxYearCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[translate='application.transfer-in.transfer-current-year']")]
        private IList<IWebElement> CurrentTaxYearCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='plan.previousTaxYear.type']")]
        private IList<IWebElement> AmountDropdown;

        [FindsBy(How = How.Name, Using = "previousTaxPercentage")]
        private IList<IWebElement> PreviousTaxPercentTextInput;

        [FindsBy(How = How.Name, Using = "previousTaxAmount")]
        private IList<IWebElement> PreviousTaxAmountTextInput;

        [FindsBy(How = How.Name, Using = "address-list")]
        private IWebElement AddressDropdown;

        //Buttons
        [FindsBy(How = How.CssSelector, Using = "[ng-click='findAddress()']")]
        private IWebElement FindAddressBtn;

        //[FindsBy(How = How.CssSelector, Using = "[name='isCashIsa0'][value='true']")]
        [FindsBy(How = How.XPath, Using = "//*[@id='collapse-manager-plan-1']/div[1]/ng-form/div[2]/div/div[1]/label/span/span[1]")]
        private IWebElement CashISARadioBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='collapse-manager-plan-1']/div[1]/ng-form/div[2]/div/div[2]/label/span/span[1]")]
        private IWebElement StocksSharesISARadioBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='collapse-manager-plan-1']/div[1]/ng-form/div[2]/div/div[3]/label/span/span[1]")]
        private IWebElement InnovativeISARadioBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='collapse-manager-plan-1']/div[1]/ng-form/div[3]/div/div[1]/label/span/span[1]")]
        private IWebElement ServeFullNoticeRadioBtn;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='collapse-manager-plan-1']/div[1]/ng-form/div[3]/div/div[2]/label/span/span[1]")]
        private IWebElement ProceedImmediatelyRadioBtn;

        [FindsBy(How = How.CssSelector, Using = "[translate='d2c.transfer-in.save']")]
        private IList<IWebElement> SavePlanBtn;

        [FindsBy(How = How.CssSelector, Using = "[translate='d2c.transfer-in.remove']")]
        private IWebElement RemovePlanBtn;

        [FindsBy(How = How.CssSelector, Using = "[ng-click='addPlan(isaManager)']")]
        private IWebElement AddAnotherPlanBtn;

        [FindsBy(How = How.CssSelector, Using = "[translate='d2c.transfer-in.add-another-request']")]
        private IWebElement AddAnotherTransfertBtn;

        [FindsBy(How = How.CssSelector, Using = "[class='instruction'][ng-hide='plan.isEditing']")]
        private IList<IWebElement> EditPencilBtns;

        [FindsBy(How = How.CssSelector, Using = "[class='instruction'][ng-show='plan.isEditing']")]
        private IList<IWebElement> CancelPencilBtns;

        [FindsBy(How =How.CssSelector, Using = "[translate='core.continue-application']")]
        private IWebElement ContinueBtn;


        //Other variables
        IsaApplication myData;
        int planCount = 0; //To keep track of how many plans we have for the indices on planReference etc.
        int previousYearcount = 0;
        int previousYearAmountCount = 0;
        int previousYearPercentCount = 0;
        bool previousYearSelected = false;

        //Methods

        public string getHeader()
        {
            Helper.WaitForElement(TransferInHeader);
            return TransferInHeader.Text;
        }

        public void EnterISAMangerName(string input)
        {
            Helper.EnterText(input, ISAManagerTextInput);
        }

        public void clickOnCashISABtn()
        {
            Helper.SelectRadioBtn(CashISARadioBtn);
        }

        public void clickOnStocksISABtn()
        {
            Helper.SelectRadioBtn(StocksSharesISARadioBtn);
        }

        public void clickOnInnovativeISABtn()
        {
            Helper.SelectRadioBtn(InnovativeISARadioBtn);
        }

        public void clickOnNoticePeriodServe()
        {
            Helper.SelectRadioBtn(ServeFullNoticeRadioBtn);
        }

        public void clickOnNoticePeriodProceed()
        {
            Helper.SelectRadioBtn(ProceedImmediatelyRadioBtn);
        }


        public void EnterPlanReference(string input, int index)
        {
            Helper.EnterText(input, PlanRefTextInput[index]);
        }

        public void clickOnSavePlanBtn()
        {
            Helper.ClickOnButton(SavePlanBtn[planCount]);
            planCount++;
            if (previousYearSelected)
            {
                previousYearcount++;
                previousYearSelected = false;

            }
        }

        public void clickOnRemovePlanBtn()
        {
            Helper.ClickOnButton(RemovePlanBtn);
        }

        public void clickOnEditPencil(int index)
        {
            Helper.ClickOnButton(EditPencilBtns[index]);
        }

        public void clickOnCancelPencil(int index)
        {
            Helper.ClickOnButton(CancelPencilBtns[index]);
        }

        public void clickOnAddAnotherPlanBtn()
        {
            Helper.ClickOnButton(AddAnotherPlanBtn);
        }

        public void clickOnAddAnotherTransferBtn()
        {
            Helper.ClickOnButton(AddAnotherTransfertBtn);
        }

        public void tickCurrentTaxYearBox()
        {
            Helper.TickCheckBox(CurrentTaxYearCheckbox[planCount]);
        }

        public void tickPreviousTaxYearBox()
        {
            Helper.TickCheckBox(PreviousTaxYearCheckbox[planCount]);
            previousYearSelected = true;
           

        }

        public void selectAmountType(string input)
        {
            Helper.SelectByValue(input, AmountDropdown[previousYearcount]);
        }

        public void EnterPreviousTaxPercent(string input)
        {
            Helper.EnterText(input,PreviousTaxPercentTextInput[previousYearPercentCount]);
            previousYearPercentCount++;
        }

        public void EnterPreviousTaxAmount(string input)
        {
            Helper.EnterText(input, PreviousTaxAmountTextInput[previousYearAmountCount]);
            previousYearAmountCount++;
        }


        //Methods for Address

        public void EnterLine1(string input)
        {
            Helper.EnterText(input, Line1TextInput);
        }

        public void EnterLine2(string input)
        {
            if (!(input == null))
            {
                Helper.EnterText(input, Line2TextInput);
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

        public void SelectCountry(string input)
        {
            Helper.SelectByText(input,CountryDropdown);
        }

        public void EnterPostcode(string input)
        {
            Helper.EnterText(input,PostcodeTextInput);
        }

        public void ClickOnFindAddressBtn()
        {
            Helper.ClickOnButton(FindAddressBtn);
        }

        public void SelectAddressByIndex(int index)
        {
            Helper.SelectByIndex(index,AddressDropdown);
        }

        public void SelectAddressByText(string address)
        {
            Helper.SelectByText(address,AddressDropdown);
        }

        public void EnterHardCodedAllValid()
        {
            EnterISAMangerName("Mr ISA Manager");
            clickOnCashISABtn();
            clickOnNoticePeriodServe();
            //Use postcode lookup
            EnterPostcode("LS11 0NE");
            ClickOnFindAddressBtn();
            Helper.WaitForElement(AddressDropdown);
            SelectAddressByIndex(1);

            EnterPlanReference("Testplan123",planCount);
            tickCurrentTaxYearBox();
            clickOnSavePlanBtn();

            //Add another plan
            clickOnAddAnotherPlanBtn();
            EnterPlanReference("Testplan456", planCount);
            tickPreviousTaxYearBox();
            selectAmountType("percentage");
            EnterPreviousTaxPercent("75.12");
            clickOnSavePlanBtn();
        }


        //This method currently cannot be used due to problem with Eden's Json
        //IS THERE A WAY TO GET THE NUMBER OF PLANS FROM THE JSON AND LOOP THE NEW PLAN CODE
        //THAT MANY NUMBER OF TIMES? -- SEE HARVEY
        public void EnterAllValid(IsaApplication myData)
        {
            EnterISAMangerName(myData.TransferIns[0].ExistingIsaManager);
            clickOnCashISABtn();
            clickOnNoticePeriodServe();
            //Enter Address
            EnterLine1(myData.TransferIns[0].ExistingIsaManagerAddress.Line1);
            EnterLine2(myData.TransferIns[0].ExistingIsaManagerAddress.Line2);
            EnterCity(myData.TransferIns[0].ExistingIsaManagerAddress.City);
            EnterCounty(myData.TransferIns[0].ExistingIsaManagerAddress.County);
            SelectCountry(myData.TransferIns[0].ExistingIsaManagerAddress.Country);
            EnterPostcode(myData.TransferIns[0].ExistingIsaManagerAddress.Postcode);

            EnterPlanReference(myData.TransferIns[0].TransferInPlans[0].IsaPlanReference, planCount);
            if (myData.TransferIns[0].TransferInPlans[0].CurrentTaxYear == true)
            {
                tickCurrentTaxYearBox();
                //Current tax year will be set to 100% automaticlly if current tax year selected
            }
            if (myData.TransferIns[0].TransferInPlans[0].PreviousTaxYear == true)
            {

                if (myData.TransferIns[0].TransferInPlans[0].PreviousTaxYearPrecentage.HasValue == true)
                    //NOTE: Percentage is spelled incorrectly in Json
                {
                    tickPreviousTaxYearBox();
                    EnterPreviousTaxPercent(myData.TransferIns[0].TransferInPlans[0].PreviousTaxYearPrecentage.ToString());
                }
                if (myData.TransferIns[0].TransferInPlans[0].PreviousTaxYearAmount.HasValue == true)
                {
                    tickPreviousTaxYearBox();
                    EnterPreviousTaxAmount(myData.TransferIns[0].TransferInPlans[0].PreviousTaxYearAmount.ToString());
                }
      
              }
            clickOnSavePlanBtn();


        }

        public void clickOnContinueButton()
        {
            Helper.ClickOnButton(ContinueBtn);
        }

    }
   
}

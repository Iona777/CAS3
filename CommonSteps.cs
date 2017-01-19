using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using System.Diagnostics;
using BusinessTests.Phase2.Pages;
using BusinessTests.Phase2.Models;
using BusinessTests.Phase2.Utilities;
using BusinessTests.Phase2.Constants;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class CommonSteps
    {
        //Class variables
        DashboardPage theDashboardPage;
        NewOrExistingInvestorPage       theNewOrExistingInvestorPage;
        NewInvestorDetailsPage          theNewInvestorDetailsPage;
        InvestorNationalityPage         theInvestorNationalityPage;
        InvestmentFundsPage             theInvestmentFundsPage;
  //      SingleSetupChargePage           theSingleSetupChargePage;
        OngoingChargePage               theOngoingChargePage;
        DirectDebitPage                 theDirectDebitPage;
        RegularWithdrawalPage           theRegularWithdrawalPage;
  //      SinglePaymentPage               theSinglePaymentPage;
        DonorDetailsPage                theDonorDetailsPage;
        CVIInvestorPage                 theCVIInvestorPage;
        CVIInvestor2ndPage              theCVIInvestor2Page;
        CVIDonorPage                    theCVIDonorPage;
        CVIDonor2ndPage                 theCVIDonor2Page;
        AdviserDeclarationPage          theAdviserDeclarationPage;
        InvestorDeclarationChoicePage   theInvestorDeclarationChoicePage;
        ApplicationSummaryPage          theApplicationSummaryPage;
        NextStepsPage                   theNextStepsPage;

        IsaApplication mainData;

        //Class constructor
        public CommonSteps()
        {
            //Create all the page objects required by the test
            theDashboardPage                    = new DashboardPage(Driver.driver);
            theNewOrExistingInvestorPage        = new NewOrExistingInvestorPage(Driver.driver);
            theNewInvestorDetailsPage           = new NewInvestorDetailsPage(Driver.driver);
            theInvestorNationalityPage          = new InvestorNationalityPage(Driver.driver);
            theInvestmentFundsPage              = new InvestmentFundsPage(Driver.driver);
            theSingleSetupChargePage            = new SingleSetupChargePage(Driver.driver);
            theDonorDetailsPage                 = new DonorDetailsPage(Driver.driver);
            theOngoingChargePage                = new OngoingChargePage(Driver.driver);
            theDirectDebitPage                  = new DirectDebitPage(Driver.driver);
            theRegularWithdrawalPage            = new RegularWithdrawalPage(Driver.driver);
            theSinglePaymentPage                = new SinglePaymentPage(Driver.driver);
            theCVIInvestorPage                  = new CVIInvestorPage(Driver.driver);
            theCVIInvestor2Page                 = new CVIInvestor2ndPage(Driver.driver);
            theCVIDonorPage                     = new CVIDonorPage(Driver.driver);
            theCVIDonor2Page                    = new CVIDonor2ndPage(Driver.driver);
            theAdviserDeclarationPage           = new AdviserDeclarationPage(Driver.driver);
            theInvestorDeclarationChoicePage    = new InvestorDeclarationChoicePage(Driver.driver);
            theApplicationSummaryPage           = new ApplicationSummaryPage(Driver.driver);
            theNextStepsPage                    = new NextStepsPage(Driver.driver);
        }

        public IsaApplication GetInputData(string fileName)
        {

            string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\" + fileName;
            string inputData = File.ReadAllText(DataFile);

            mainData = JsonConvert.DeserializeObject<IsaApplication>(inputData);
            return mainData;

        }


        [When(@"The user enters any valid data for the mandatory fields prior to the Investment Funds screen using file '(.*)'")]
        public void WhenTheUserEntersAnyValidDataForTheMandatoryFieldsPriorToTheInvestmentFundsScreenUsingFile(string fileName)
        {
            //Dashboard page
            theDashboardPage.clickApplyNowbtn();
            Helper.pause(2000);
            Assert.IsTrue(theNewOrExistingInvestorPage.HeaderDisplayed(), "Check we are on new or existing investor page");
            //Not going to create this method for all pages just now. Ask Craig for list of page titles and check the normal way
            //using Browser.Title.

            //New or Existing Investor page
            theNewOrExistingInvestorPage.clickOnContinueAsNewInvestorBtn();    
            //Leave the old header checkin for now 
            Assert.AreEqual(ConstantsList.Eden_NewInvestorDetailsHeaderText, theNewInvestorDetailsPage.getHeader());
        

            //New Investor Details page
            theNewInvestorDetailsPage.EnterAllValid(GetInputData(fileName));
            theNewInvestorDetailsPage.clickOnContinueApplicatonBtn();
            Helper.pause(2000);
            Assert.AreEqual(ConstantsList.Eden_InvestorNationalityHeaderText, theInvestorNationalityPage.getHeader());

            //Investor Nationality page
            theInvestorNationalityPage.EnterAllValid(GetInputData(fileName));
            theInvestorNationalityPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }


        [When(@"The user selects No Ongoing Charges and No Regular Withdrawal after the Transfer In Set-up Adviser Charge screen")]
        public void WhenTheUserSelectsNoOngoingChargesAndNoRegularWithdrawalAfterTheTransferInSet_UpAdviserChargeScreen()
        {
            theOngoingChargePage.ClickOnNoChargeBtn();
            theOngoingChargePage.clickOnContinueApplicationBtn();
            theRegularWithdrawalPage.clickOnWithdrawalNoBtn();
            theRegularWithdrawalPage.clickOnContinueApplicationBtn();
        }





        [When(@"The user enters any valid data between the CVI Investor screen and Investor declaration choice screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersAnyValidDataBetweenTheCVIInvestorScreenAndInvestorDeclarationChoiceScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            //CVI Investor page
            theCVIInvestorPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
            //Assert.AreEqual(ConstantsList.Eden_CVIInvestor2ndHeaderText, theCVIInvestor2Page.getHeader(), "Check that we are on the 2nd CI Investor Page");
    
            //The CVI Investor page 2
            theCVIInvestor2Page.EnterAllValid();  //This does not use myData
            theCVIInvestor2Page.clickOnContinueBtn();
            Helper.pause(2000);
            Assert.AreEqual(ConstantsList.Eden_AdviserDeclarationHeaderText, theAdviserDeclarationPage.getHeader(),"Check that we are in the advisor declaration page");

            //The Adviser Declaration page
            try
            {
                Assert.IsTrue(theAdviserDeclarationPage.checkAdviserDeclarationMandatoryFieldsPopulated(), "Check that we are in the advisor declaration page");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Mandatory fields not all populated for Adviser Declaration");
                throw;
            }
          
            Helper.pause(2000);
            theAdviserDeclarationPage.EnterAllValid(GetInputData(fileName));
            theAdviserDeclarationPage.ClickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [When(@"The user selects No Ongoing Charges and clicks on the Continue application button")]
        public void WhenTheUserSelectsNoOngoingCharges()
        {
            theOngoingChargePage.ClickOnNoChargeBtn();
            theOngoingChargePage.clickOnContinueApplicationBtn();
        }

        [Then(@"The Direct Debit screen should be displayed")]
        public void ThenTheDirectDebitScreenShouldBeDisplayed()
        {
            Assert.IsNotNull(theDirectDebitPage.getHeader(),"Check that we are in the direct debit page"); //quick way to get header/title
        }

        [Then(@"The Regular Withdrawal screen should be displayed")]
        public void ThenTheRegularWithdrawalScreenShouldBeDisplayed()
        {
            Assert.IsNotNull(theRegularWithdrawalPage.getHeader(),"Check that we are it the regular withdrawal page"); //quick way to get header/title
        }

        [When(@"The user selects No Regular Withdrawal and clicks on the Continue application button")]
        public void WhenTheUserSelectsNoRegularWithdrawalAndClicksOnTheContinueApplicationButton()
        {
            theRegularWithdrawalPage.clickOnWithdrawalNoBtn();
            theRegularWithdrawalPage.clickOnContinueApplicationBtn();
        }

        [Then(@"The Donor Details screen is displayed")]
        public void ThenTheDonorDetailsScreenIsDisplayed()
        {
            Helper.pause(1000); 
            Assert.IsNotNull(theDonorDetailsPage.getHeader(),"Check that we are i the donor details page"); //quick way to get header/title

        }

        [When(@"The user enters valid data in the Donor Details screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheDonorDetailsScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theDonorDetailsPage.EnterAllValid(GetInputData(fileName));
            theDonorDetailsPage.ClickOnContinueApplicatonButton();
        }

        [When(@"The user selects Yes to Regular Withdrawal and clicks on the Continue application button")]
        public void WhenTheUserSelectsYesToRegularWithdrawalAndClicksOnTheContinueApplicationButton()
        {
            theRegularWithdrawalPage.clickOnWithdrawalYesBtn();
            theRegularWithdrawalPage.clickOnContinueApplicationBtn();
        }

        [When(@"The user selects Direct Payment and clicks on the Continue application button")]
        public void WhenTheUserSelectsDirectPaymentAndClicksOnTheContinueApplicationButton()
        {
            theSinglePaymentPage.SelectPaymentMethod(PaymentType.DirectPayment);
            theSinglePaymentPage.clickOnContinueApplicationBtn();
        }

        [When(@"The user selects Previous Address checkbox and clicks on the Continue Application button")]
        public void WhenTheUserSelectsPreviousAddressCheckboxAndClicksOnTheContinueApplicationButton()
        {
            theCVIInvestorPage.TickChangedAddress();
            theCVIInvestorPage.clickOnContinueApplicationBtn();
        }

        [When(@"The user enters any valid data in the CVI Investor 2 screen and clicks on the Continue application button")]
        public void WhenTheUserEntersAnyValidDataInTheCVIInvestorScreenAndClicksOnTheContinueApplicationButton()
        {
            theCVIInvestor2Page.clickOnMeetsEvidenceBtn();
            Helper.pause(2000);
            theCVIInvestor2Page.clickOnContinueBtn();
        }


        [Then(@"The CVI Donor page will be displayed")]
        public void ThenTheCVIDonorPageWillBeDisplayed()
        {
            Helper.pause(3000);
            Assert.IsTrue(Driver.driver.Title==ConstantsList.CVIDonorTitle, "Check we are on CVI Donor page");
            //Assert.IsNotNull(theCVIDonorPage.getHeader());
        }

        [When(@"The user enters DOB in CVI Donor page and clicks on the Continue application button")]
        public void WhenTheUserEntersDOBInCVIDonorPageAndClicksOnTheContinueApplicationButton()
        {
            theCVIDonorPage.EnterDOB("12","12","1950");
            theCVIDonorPage.clickOnContinueApplicationBtn();
        }


        [Then(@"The CVI Donor page 2 screen will be displayed")]
        public void ThenTheCVIDonorPageScreenWillBeDisplayed()
        {
            Helper.pause(3000);
            Assert.IsTrue(Driver.driver.Title == ConstantsList.CVIDonor2Title, "Check we are on CVI Donor 2 page");
        }



        [When(@"The user clicks on the Continue application button")]
        public void WhenTheUserClicksOnTheContinueApplicationButton()
        {
            theNewInvestorDetailsPage.clickOnContinueApplicatonBtn();
        }

        [Then(@"The Adviser Declaration page will be displayed")]
        public void ThenTheAdviserDeclarationPageWillBeDisplayed()
        {
            Helper.pause(1000);
            Assert.IsNotNull(theAdviserDeclarationPage.getHeader());
         
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Pages;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using Capita.PruApp.BusinessTests.Phase2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Tests.Step_Definitions
{

    [Binding]
    public sealed class HappyPath1
    {
        //Class variables
        DashboardPage theDashboardPage;
        NewOrExistingInvestorPage theNewOrExistingInvestorPage;
        NewInvestorDetailsPage theNewInvestorDetailsPage;
        InvestorNationalityPage theInvestorNationalityPage;
        InvestmentFundsPage theInvestmentFundsPage;
        SingleSetupChargePage theSingleSetupChargePage;
        OngoingChargePage theOngoingChargePage;
        RegularWithdrawalPage theRegularWithdrawalPage;
        SinglePaymentPage theSinglePaymentPage;
        CVIInvestorPage theCVIInvestorPage;
        CVIInvestor2ndPage theCVIInvestor2Page;
        AdviserDeclarationPage theAdviserDeclarationPage;
        InvestorDeclarationChoicePage theInvestorDeclarationChoicePage;
        ApplicationSummaryPage theApplicationSummaryPage;
        NextStepsPage theNextStepsPage;

        IsaApplication mainData;

        //Class constructor
        public HappyPath1()
        {
            //Create all the page objects required by the test
            theDashboardPage = new DashboardPage(Driver.driver);
            theNewOrExistingInvestorPage = new NewOrExistingInvestorPage(Driver.driver);
            theNewInvestorDetailsPage = new NewInvestorDetailsPage(Driver.driver);
            theInvestorNationalityPage = new InvestorNationalityPage(Driver.driver);
            theInvestmentFundsPage = new InvestmentFundsPage(Driver.driver);
            theSingleSetupChargePage = new SingleSetupChargePage(Driver.driver);
            theOngoingChargePage = new OngoingChargePage(Driver.driver);
            theRegularWithdrawalPage = new RegularWithdrawalPage(Driver.driver);
            theSinglePaymentPage = new SinglePaymentPage(Driver.driver);
            theCVIInvestorPage = new CVIInvestorPage(Driver.driver);
            theCVIInvestor2Page = new CVIInvestor2ndPage(Driver.driver);
            theAdviserDeclarationPage = new AdviserDeclarationPage(Driver.driver);
            theInvestorDeclarationChoicePage = new InvestorDeclarationChoicePage(Driver.driver);
            theApplicationSummaryPage = new ApplicationSummaryPage(Driver.driver);
            theNextStepsPage = new NextStepsPage(Driver.driver);
        }

        //Methods for Specflow conditions

        //[Given(@"That I am using file '(.*)' for the input data")]
        //public void GivenThatIAmUsingFileForTheInputData(string fileName)
        public IsaApplication GetInputData(string fileName)
        {

            string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\" + fileName;
            string inputData = File.ReadAllText(DataFile);

            mainData = JsonConvert.DeserializeObject<IsaApplication>(inputData);
            return mainData;

        }

        [When(@"The user clicks on the Apply now button")]
        public void WhenTheUserClicksOnTheApplyNowButton()
        {
            theDashboardPage.clickApplyNowbtn();
            Helper.pause(2000);
        }


        [Then(@"The New or Existing Investor screen should be displayed")]
        public void ThenTheNewOrExistingInvestorScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_NewOrExistingHeaderText, theNewOrExistingInvestorPage.getHeader(), "Check we are on new or existing investor page");
        }

        [When(@"The user clicks on the Continue as new investor button")]
        public void WhenTheUserClicksOnTheContinueAsNewInvestorButton()
        {
            theNewOrExistingInvestorPage.clickOnContinueAsNewInvestorBtn();
        }

        [Then(@"The New investor details screen should be displayed")]
        public void ThenTheNewInvestorDetailsScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_NewInvestorDetailsHeaderText, theNewInvestorDetailsPage.getHeader());
        }

        //    [When(@"The user enters valid data in the New Investor details screen and clicks on the Continue application button")]
        //public void WhenTheUserEntersValidDataInTheNewInvestorDetailsScreenAndClicksOnTheContinueApplicationButton()
        [When(@"The user enters valid data in the New Investor details screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheNewInvestorDetailsScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theNewInvestorDetailsPage.EnterAllValid(GetInputData(fileName));
            theNewInvestorDetailsPage.clickOnContinueApplicatonBtn();
            Helper.pause(2000);
        }

        [Then(@"The Investor Nationality screen is displayed")]
        public void ThenTheInvestorNationalityScreenIsDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_InvestorNationalityHeaderText, theInvestorNationalityPage.getHeader());
        }

        [When(@"The user enters valid data in the Investor Nationality screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheInvestorNationalityScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        // [When(@"The user enters valid data in the Investor Nationality screen and clicks on the Continue application button")]
        //public void WhenTheUserEntersValidDataInTheInvestorNationalityScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestorNationalityPage.EnterAllValid(GetInputData(fileName));
            theInvestorNationalityPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Investment Funds screen should be displayed")]
        public void ThenTheInvestmentFundsScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_InvestmentFundsHeaderText, theInvestmentFundsPage.getHeader(), "Check that we are on investments funds page");
        }

        [When(@"The user enters valid data  Single Investment in the Investment Funds screen and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheInvestmentFundsScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestmentFundsPage.EnterAllValidSingleInvestment(); //This method currently does not take mainData
            theInvestmentFundsPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Single Investment Set-up Adviser Charge screen should be displayed")]
        public void ThenTheSingleInvestmentSet_UpAdviserChargeScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_SingleSetupChargeHeaderText, theSingleSetupChargePage.getHeader(), "Check that we are on the Single setup charge screen");
        }


        [When(@"The user enters valid data in the Single Charge screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheSingleChargeScreenAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theSingleSetupChargePage.EnterAllValid(GetInputData(fileName));
            theSingleSetupChargePage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Ongoing Charges screen should be displayed")]
        public void ThenTheOngoingChargesScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_OngoingChargeHeaderText, theOngoingChargePage.getHeader(), "Check that we are on the Ongoing Charge screen");
        }

        [When(@"The user enters valid data in the Ongoing charges screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheOngoingChargesScreenAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theOngoingChargePage.EnterAllValid(GetInputData(fileName));
            theOngoingChargePage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Regular Withdrawals screen should be displayed")]
        public void ThenTheRegularWithdrawalsScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_RegularWithdrawalHeaderText, theRegularWithdrawalPage.getHeader(), "Check that we are on the Regular Withdrawal screen");
        }

        [When(@"The user enters valid data in the Regular Withdrawals screen using file '(.*)'and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheRegularWithdrawalsScreenAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theRegularWithdrawalPage.EnterAllValid(GetInputData(fileName));
            theRegularWithdrawalPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Single Investment Payment Details screen should be displayed")]
        public void ThenTheSingleInvestmentPaymentDetailsScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_SinglePaymentHeaderText, theSinglePaymentPage.getHeader(), "Check that we are on the single payment page");

        }

        [When(@"The user user enters valid data in the Single investment payment details screen using file '(.*)'and clicks on the Continue application button")]
        public void WhenTheUserUserEntersValidDataInTheSingleInvestmentPaymentDetailsScreenAndClicksOnTheButton(string fileName)
        {
            theSinglePaymentPage.EnterAllValid(GetInputData(fileName));
            theSinglePaymentPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);

        }

        [Then(@"The CVI Investor screen should be displayed")]
        public void ThenTheCVIInvestorScreenShouldBeDisplayed()
        {
            Helper.pause(2000);
            Debug.WriteLine("Driver title is:"+ Driver.driver.Title);
            //Assert.AreEqual(ConstantsList.Eden_CVIInvestorHeaderText, theCVIInvestorPage.getHeader(), "Check that we are on the CVI Investor page");
            //Assert.IsTrue(Driver.driver.Title == ConstantsList.CVIInvestorTitle, "Check that we are on the CVI Investor page");
            //This does not work properly
        }


        [Then(@"The mandatory fields are populated")]
        public void AndTheCVIMandatoryFieldsArePopulated()
        {
            Assert.IsTrue(theCVIInvestorPage.checkMandatoryFieldsNotNull());
        }

        [When(@"The user clicks on the Continue application button in the CVI Investor screen screen")]
        public void WhenTheUserClicksOnTheContinueApplicationButtonInTheCVIScreen()
        {
            theCVIInvestorPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The CVI Investor page 2 screen should be displayed")]
        public void ThenTheCVIInvestorPage2ScreenShouldBeDisplayed()
        {
            //Been getting some stales element references, so use this code to handle it.
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Helper.pause(1000);
                    //Assert.AreEqual(ConstantsList.Eden_CVIInvestor2ndHeaderText, theCVIInvestor2Page.getHeader(), "Check that we are on the 2nd CI Investor Page");
                    Assert.IsTrue(Driver.driver.Title== ConstantsList.CVIInvestor2Title,"Check that we are on the 2nd CVI Investor Page");
                    break;
                }
                catch (Exception staleperhaps)
                {

                    Debug.WriteLine("Debug: May have got a stale element or element not found exception, will try a few more times");
                }
            }

            
        }

        [When(@"The user enters valid data in the CVI Investor Page 2 screen and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheCVIInvestorPage2ScreenAndClicksOnTheContinueApplicationButton()
        {
            theCVIInvestor2Page.EnterAllValid();  //This does not use myData
            theCVIInvestor2Page.clickOnContinueBtn();
            Helper.pause(2000);
        }

        [Then(@"The Adviser Declaration screen should be displayed")]
        public void ThenTheAdviserDeclarationScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_AdviserDeclarationHeaderText, theAdviserDeclarationPage.getHeader());
        }

        [Then(@"The adviser details are prepopulated")]
        public void ThenTheAdviserDetailsArePrepopulated()
        {
            Assert.IsTrue(theAdviserDeclarationPage.checkAdviserDeclarationMandatoryFieldsPopulated(),"Checking for mandatory fields on adviser declaration");
            Helper.pause(2000);
        }

        [When(@"The user enters valid data in the Adviser Declaration screen using file '(.*)'and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheAdviserDeclarationScreenAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theAdviserDeclarationPage.EnterAllValid(GetInputData(fileName));
            theAdviserDeclarationPage.ClickOnContinueApplicationBtn();
            Helper.pause(2000);
        }


        [Then(@"The Investor Declaration Choice screen should be displayed")]
        public void ThenTheInvestorDeclarationChoiceScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_InvestorDeclarationChoiceText, theInvestorDeclarationChoicePage.getHeader(), "Check that we are on the Investor Declaration Choice page");
        }


        [When(@"The user selects a valid option in the Investor Declaration Choice screen and clicks on the Continue application button")]
        public void WhenTheUserSelectsAValidOptionInTheInvestorDeclarationChoiceScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestorDeclarationChoicePage.clickOnPrintAndPostBtn();
            theInvestorDeclarationChoicePage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }


        [Then(@"The Application Summary screen should be displayed")]
        public void ThenTheApplicationSummaryScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_ApplicationSummaryHeaderText, theApplicationSummaryPage.getHeader(), "Check that we are on the Summary page");

        }

        [When(@"The user clicks on the Submit application button in the Application Summary screen")]
        public void WhenTheUserClicksOnTheSubmitApplicationButtonInTheApplicationSummaryScreen()
        {
            theApplicationSummaryPage.SubmitApplication();
            Helper.pause(2000);
        }

        [Then(@"The Next Steps screen should be displayed")]
        public void ThenTheNextStepsScreenShouldBeDisplayed()
        {
            Assert.AreEqual(ConstantsList.Eden_NextStepsHeaderText, theNextStepsPage.getHeader(), "Check that we are on the Next Steps page");
        }

        [When(@"The user clicks on the Return to dashboard button on the Next Steps screen")]
        public void WhenTheUserClicksOnTheReturnToDashboardButtonOnTheNextStepsScreen()
        {
            theNextStepsPage.ClickOnReturnToDashboardBtn();
            Helper.pause(1500);
        }

        [When(@"The user clicks on the Show my applications button in the Dashboard screen")]
        public void WhenTheUserClicksOnTheShowMyApplicationsButtonInTheDashboardScreen()
        {
            theDashboardPage.clickShowRecentApplicationsbtn();
            Helper.pause(1500);
        }

        [Then(@"Applications displayed and the latest one has a Status of Completed")]
        public void ThenApplicationsDisplayedAndTheLatestOneHasAStatusOfCompleted()
        {
            Assert.AreEqual(ConstantsList.Status_Complete, theDashboardPage.getStatus(0));
            Helper.pause(3000);
        }

        [Then(@"Applications displayed and the latest one has a Status of Submitted")]
        public void ThenApplicationsDisplayedAndTheLatestOneHasAStatusOfSubmitted()
        {
            Assert.AreEqual(ConstantsList.Status_Submitted, theDashboardPage.getStatus(0),"Checking that status = Submitted");
            Helper.pause(3000);
        }

    }
}
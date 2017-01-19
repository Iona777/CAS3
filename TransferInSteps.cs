using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using BusinessTests.Phase2.Pages;
using BusinessTests.Phase2.Models;
using BusinessTests.Phase2.Utilities;
using BusinessTests.Phase2.Constants;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class TransferInSteps
    {
        //Class variables
        DashboardPage theDashboardPage;
        NewOrExistingInvestorPage theNewOrExistingInvestorPage;
        NewInvestorDetailsPage theNewInvestorDetailsPage;
        InvestorNationalityPage theInvestorNationalityPage;
        InvestmentFundsPage theInvestmentFundsPage;
        TransferInPage theTransferInPage;
        TransferInSetupChargePage theTransferInChargesPage;
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
        public TransferInSteps()
        {
            //Create all the page objects required by the test
            theDashboardPage = new DashboardPage(Driver.driver);
            theNewOrExistingInvestorPage = new NewOrExistingInvestorPage(Driver.driver);
            theNewInvestorDetailsPage = new NewInvestorDetailsPage(Driver.driver);
            theInvestorNationalityPage = new InvestorNationalityPage(Driver.driver);
            theInvestmentFundsPage = new InvestmentFundsPage(Driver.driver);
            theTransferInPage = new TransferInPage(Driver.driver);
            theTransferInChargesPage = new TransferInSetupChargePage(Driver.driver);
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

        public IsaApplication GetInputData(string fileName)
        {

            string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\" + fileName;
            string inputData = File.ReadAllText(DataFile);

            mainData = JsonConvert.DeserializeObject<IsaApplication>(inputData);
            return mainData;

        }

        [When(@"The user enters valid data for a Transfer Investment only in the Investment Funds screen and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataForATransferInvestmentOnlyInTheInvestmentFundsScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestmentFundsPage.EnterAllValidTransferIn(); //This method currently does not take mainData
            theInvestmentFundsPage.clickOnContinueApplicationBtn();
            Helper.pause(2000);
        }

        [Then(@"The Transfer In screen should be displayed")]
        public void ThenTheTransferInScreenShouldBeDisplayed()
        {
            Assert.IsNotNull(theTransferInPage.getHeader());//Quick way to check we are on right page. Can check properly by inspecting page to get titiel then use Browser.GetTitle as normal (we think)
        }

        [When(@"The user enters valid data in the Transfer In screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheTransferInScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theTransferInPage.EnterAllValid(GetInputData(fileName));
            theTransferInPage.clickOnContinueApplicationButton();
            Helper.pause(2000);
        }

        [Then(@"The Transfer In Set-up Adviser Charge screen should be displayed")]
        public void ThenTheTransferInSet_UpAdviserChargeScreenShouldBeDisplayed()
        {
            Assert.IsNotNull(theTransferInChargesPage.getHeader()); //Quick way to check we are on right page. Can check properly by inspecting page to get titiel then use Browser.GetTitle as normal (we think)
        }

        [When(@"The user enters valid data in the Transfer In Set-up Adviser Charge screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheTransferInSet_UpAdviserChargeScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theTransferInChargesPage.EnterAllValid(GetInputData(fileName));
            theTransferInChargesPage.clickOnContinueApplicationButton();
            Helper.pause(2000);
        }


    }
}

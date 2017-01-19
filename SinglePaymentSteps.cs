using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using PruApp.BusinessTests.Phase2.Pages;
using PruApp.BusinessTests.Phase2.Models;
using PruApp.BusinessTests.Phase2.Utilities;
using PruApp.BusinessTests.Phase2.Constants;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class SinglePaymentSteps
    {
        //Class variables
        DashboardPage                   theDashboardPage;
        NewOrExistingInvestorPage       theNewOrExistingInvestorPage;
        NewInvestorDetailsPage          theNewInvestorDetailsPage;
        InvestorNationalityPage         theInvestorNationalityPage;
        InvestmentFundsPage             theInvestmentFundsPage;
        SinglePaymentPage               theSinglePaymentPage;
        SingleSetupChargePage           theSingleChargePage;
        OngoingChargePage               theOngoingChargePage;
        CVIInvestorPage                 theCVIInvestorPage;
        CVIInvestor2ndPage              theCVIInvestor2Page;
        AdviserDeclarationPage          theAdviserDeclarationPage;
        InvestorDeclarationChoicePage   theInvestorDeclarationChoicePage;
        ApplicationSummaryPage          theApplicationSummaryPage;
        NextStepsPage                   theNextStepsPage;

        IsaApplication mainData;

        //Class constructor
        public SinglePaymentSteps()
        {
            //Create all the page objects required by the test
            theDashboardPage                = new DashboardPage(Driver.driver);
            theNewOrExistingInvestorPage    =  new NewOrExistingInvestorPage(Driver.driver);
            theNewInvestorDetailsPage       = new NewInvestorDetailsPage(Driver.driver);
            theInvestorNationalityPage      = new InvestorNationalityPage(Driver.driver);
            theInvestmentFundsPage          = new InvestmentFundsPage(Driver.driver);
            theSingleChargePage             = new SingleSetupChargePage(Driver.driver);
            theSinglePaymentPage            = new SinglePaymentPage(Driver.driver);
            theOngoingChargePage            = new OngoingChargePage(Driver.driver);
            theCVIInvestorPage              = new CVIInvestorPage(Driver.driver);
            theCVIInvestor2Page             = new CVIInvestor2ndPage(Driver.driver);
            theAdviserDeclarationPage       = new AdviserDeclarationPage(Driver.driver);
            theInvestorDeclarationChoicePage = new InvestorDeclarationChoicePage(Driver.driver);
            theApplicationSummaryPage       = new ApplicationSummaryPage(Driver.driver);
            theNextStepsPage                = new NextStepsPage(Driver.driver);
        }

        public IsaApplication GetInputData(string fileName)
        {
            string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\" + fileName;
            string inputData = File.ReadAllText(DataFile);

            mainData = JsonConvert.DeserializeObject<IsaApplication>(inputData);
            return mainData;
        }

        [When(@"The user enters valid data for a Single Investment only in the Investment Funds screen and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataForASingleInvestmentOnlyInTheInvestmentFundsScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestmentFundsPage.EnterAllValidSingleInvestment();
            theInvestmentFundsPage.clickOnContinueApplicationBtn();
        }

        [When(@"The user selects No Single Setup Charges and clicks on the Continue application button")]
        public void WhenTheUserSelectsNoSingleSetupChargesAndClicksOnTheContinueApplicationButton()
        {
            theSingleChargePage.ClickOnChargeNo();
            theSingleChargePage.clickOnContinueApplicationBtn();
        }

        [When(@"The  user enters valid data AND selects a Donor in the Single Investment Payment Details screen using the file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataANDSelectsADonorInTheSingleInvestmentPaymentDetailsScreenUsingTheFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theSinglePaymentPage.EnterAllValid(GetInputData(fileName)); //Note: the selection of donor will be driven by the input file.
            theSinglePaymentPage.clickOnContinueApplicationBtn();
        }

    }
}

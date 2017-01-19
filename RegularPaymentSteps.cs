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
    public sealed class RegularPaymentSteps
    {
        //Class variables
        DashboardPage theDashboardPage;
        NewOrExistingInvestorPage       theNewOrExistingInvestorPage;
        NewInvestorDetailsPage          theNewInvestorDetailsPage;
        InvestorNationalityPage         theInvestorNationalityPage;
        InvestmentFundsPage             theInvestmentFundsPage;
        RegularSetupChargePage          theRegularChargePage;
        DirectDebitPage                 theDirectDebitPage;
        OngoingChargePage               theOngoingChargePage;
        CVIInvestorPage                 theCVIInvestorPage;
        CVIInvestor2ndPage              theCVIInvestor2Page;
        AdviserDeclarationPage          theAdviserDeclarationPage;
        InvestorDeclarationChoicePage   theInvestorDeclarationChoicePage;
        ApplicationSummaryPage          theApplicationSummaryPage;
        NextStepsPage                   theNextStepsPage;

        IsaApplication mainData;

        //Class constructor
        public RegularPaymentSteps()
        {
            //Create all the page objects required by the test
            theDashboardPage                = new DashboardPage(Driver.driver);
            theNewOrExistingInvestorPage    =  new NewOrExistingInvestorPage(Driver.driver);
            theNewInvestorDetailsPage       = new NewInvestorDetailsPage(Driver.driver);
            theInvestorNationalityPage      = new InvestorNationalityPage(Driver.driver);
            theInvestmentFundsPage          = new InvestmentFundsPage(Driver.driver);
            theRegularChargePage            = new RegularSetupChargePage(Driver.driver);
            theDirectDebitPage              = new DirectDebitPage(Driver.driver); 
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

        [When(@"The user enters valid data for a Regular Investment only in the Investment Funds screen and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataForARegularInvestmentOnlyInTheInvestmentFundsScreenAndClicksOnTheContinueApplicationButton()
        {
            theInvestmentFundsPage.EnterAllValidRegularInvestment();
            theInvestmentFundsPage.clickOnContinueApplicationBtn();
        }

        [Then(@"The Regular Investment Set-up Adviser Charge screen should be displayed")]
        public void ThenTheRegularInvestmentSet_UpAdviserChargeScreenShouldBeDisplayed()
        {
            Assert.IsNotNull(theRegularChargePage.getHeader()); //quick way of checking for header/title
        }

        [When(@"The user enters valid data in the Regular Investment Set-up Adviser Charge screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheRegularInvestmentSet_UpAdviserChargeScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theRegularChargePage.EnterAllValid(GetInputData(fileName));
            theRegularChargePage.ClickOnContinueApplicationButton();
        }

        [When(@"The user enters valid data in the Direct Debit screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheDirectDebitScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theDirectDebitPage.EnterAllValid(GetInputData(fileName));
            theDirectDebitPage.ClickOnContinueApplicationButton();
        }

        [When(@"The user enters valid data in the Regular Investment Set-up Adviser Charge with a Split Charge screen using file '(.*)' and clicks on the Continue application button")]
        public void WhenTheUserEntersValidDataInTheRegularInvestmentSet_UpAdviserChargeWithASplitChargeScreenUsingFileAndClicksOnTheContinueApplicationButton(string fileName)
        {
            theRegularChargePage.EnterAllValid(GetInputData(fileName));
            Helper.pause(1500);
            theRegularChargePage.EnterAllValidSplit(GetInputData(fileName));
            Helper.pause(3000);
            theRegularChargePage.ClickOnContinueApplicationButton();
        }



    }
}

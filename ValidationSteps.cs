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
using System.Diagnostics;

namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class ValidationSteps
    {
        //Class variables
        DashboardPage theDashboardPage;
        NewOrExistingInvestorPage       theNewOrExistingInvestorPage;
        NewInvestorDetailsPage          theNewInvestorDetailsPage;
        InvestorNationalityPage         theInvestorNationalityPage;
        InvestmentFundsPage             theInvestmentFundsPage;
        SingleSetupChargePage           theSingleSetupChargePage;
        OngoingChargePage               theOngoingChargePage;
        DirectDebitPage                 theDirectDebitPage;
        RegularWithdrawalPage           theRegularWithdrawalPage;
        SinglePaymentPage               theSinglePaymentPage;
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
        public ValidationSteps()
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

        public string GetScreenshotFilename(string subfolder, string fileName)
        {

            string screenshotFolder = ConstantsList.Screenshot_folder;

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");
            //string fileName = "newInvestorDetailsNoInput";
            string screenshotFileName = screenshotFolder + subfolder +"\\" + fileName + timestamp + ".png";

            return screenshotFileName;



        }

        [Then(@"All the required error messages for no input to the New Investor Details screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheNewInvestorDetailsScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName  = "newInvestorDetailsNoInput";
            
            Helper.pause(2000);
            theNewInvestorDetailsPage.TakeScreenshot(GetScreenshotFilename(subfolder,fileName));
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Forename is required"),"Check for forename blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Surname is required"), "Check for surname blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Date of birth is required"), "Check for DOB blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Address line 1 is required"), "Check for Line 1 blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Town or city is required"), "Check for town or city blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Postcode is required"), "Check for postcode blank");
            Assert.IsTrue(theNewInvestorDetailsPage.body.Text.Contains("Daytime telephone number is required"), "Check for daytime phone blank");    
        }

        [Then(@"All the required error messages for no input to the Investor Nationality screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheInvestorNationalityScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "InvestorNationalityNoInput";

            Helper.pause(2000);
            theInvestorNationalityPage.TakeScreenshot(GetScreenshotFilename(subfolder,fileName));
            Assert.IsTrue(theInvestorNationalityPage.body.Text.Contains("Please provide a place of birth"), "Check for place of birth blank");
            Assert.IsTrue(theInvestorNationalityPage.body.Text.Contains("Please provide a place of residence"), "Check for town of residence blank" );
            Assert.IsTrue(theInvestorNationalityPage.body.Text.Contains("Please provide a valid National Insurance number or click the box to indicate absence."), "Check for NINO blank");
        }

        [Then(@"All the required error messages for no input to the Investment Funds screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheInvestmentFundsScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "InvestmentFundsNoInput";

            Helper.pause(2000);
            theInvestmentFundsPage.TakeScreenshot(GetScreenshotFilename(subfolder,fileName));
            Assert.IsTrue(theInvestorNationalityPage.body.Text.Contains("Please enter at least one investment"), "Check for investments blank");
        }

        [Then(@"All the required error messages for no input to the Single Investment Set-up Adviser Charge screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheSingleInvestmentSet_UpAdviserChargeScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "SingleChargeNoInput";

            Helper.pause(2000);
            theSingleSetupChargePage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theSingleSetupChargePage.body.Text.Contains("Please enter a value"),"Check for single investment blank-percent");
            Assert.IsTrue(theSingleSetupChargePage.body.Text.Contains("Please enter a value"), "Check for single investment blank-amount");
        }

        [Then(@"All the required error messages for no input to the Ongoing Adviser Charges percent screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheOngoingAdviserChargesPercentScreenAreDisplayed()
         {
            string subfolder = "noinput";
            string fileName = "OngoingChargeNoInputPercent";

            Helper.pause(2000);
            theOngoingChargePage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theOngoingChargePage.body.Text.Contains("Please enter an adviser charge percentage greater than 0%"),"Check charge value blank-percent");
        }

        [When(@"The user clicks on the Ongoing Charges Amount button then the Continue application button")]
        public void WhenTheUserClicksOnTheOngoingChargesAmountButtonThenTheContinueApplicationButton()
        {
            theOngoingChargePage.ClickOnAmountBtn();
            theOngoingChargePage.clickOnContinueApplicationBtn();
        }

        [Then(@"All the required error messages for no input to the Ongoing Adviser Charges amount screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheOngoingAdviserChargesAmountScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "OngoingChargeNoInputAmount";

            Helper.pause(2000);
            theOngoingChargePage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theOngoingChargePage.body.Text.Contains("Please enter an adviser charge amount greater than £0"), "Check charge value blank-amount");
        }


        [Then(@"All the required error messages for no input to the Regular Withdrawal Facility screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheRegularWithdrawalFacilityScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "RegularWithdrawalNoInput";

            Helper.pause(2000);
            theRegularWithdrawalPage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please enter 0 if no withdrawal required for this fund"), "Check withdrawal amount blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Start date is required"), "Check start date blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please select a withdrawal frequency"), "Check withdrawal frequency blank");
            //Bank name and address details
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please enter a bank or building society name"), "Check bank name blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Address line 1 is required"), "Check line 1 blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Town or city is required"), "Check town or city blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Town or city is required"), "Check town or city blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Postcode is required"), "Check postcode blank");
            //Bank account details
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please enter the name of the account holder"), "Check account holder blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please enter a sort code, for example: 123456"), "Check sort code blank");
            Assert.IsTrue(theRegularWithdrawalPage.body.Text.Contains("Please enter an account number, for example: 12345678"), "Check account number blank");
        }

        [Then(@"All the required error messages for no input to the Single Investment Payment Detals screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheSingleInvestmentPaymentDetalsScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "SinglePaymentNoInput";

            Helper.pause(2000);
            theSinglePaymentPage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Source of funds is required"),"Check source of funds blank");  //This error mesage is subject to confirmation by John
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Bank or building society name is required"), "Check bank name blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Account holder name is required"), "Check account holder name blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Sort code is required"), "Check sort code blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Please enter an account number, for example: 12345678"), "Check account number blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Postcode is required"), "Check post code blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Address line 1 is required"), "Check Address line 1 blank");
            Assert.IsTrue(theSinglePaymentPage.body.Text.Contains("Town or city is required"), "Check town or city blank");

        }

        [Then(@"All the required error messages for no input to the Donor Detals screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheDonorDetalsScreenAreDisplayed()
        {

            string subfolder = "noinput";
            string fileName = "DonorDetailsNoInput";

            Helper.pause(2000);
            theDonorDetailsPage.TakeScreenshot(GetScreenshotFilename(subfolder,fileName));
            Assert.IsTrue(theDonorDetailsPage.body.Text.Contains("Full name is required"),"Check fullname blank");
            Assert.IsTrue(theDonorDetailsPage.body.Text.Contains("Postcode is required"), "Check postcode blank");
            Assert.IsTrue(theDonorDetailsPage.body.Text.Contains("Address line 1 is required"), "Check address line 1 blank");
            Assert.IsTrue(theDonorDetailsPage.body.Text.Contains("Town or city is required"), "Check town or city blank");
            Assert.IsTrue(theDonorDetailsPage.body.Text.Contains("Relationship to the investor is required"), "Check relationship to investor blank");
        }

        [Then(@"All the required error messages for no input to the CVI Investor screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheCVIInvestorScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "CVIInvestorNoInput";

            Helper.pause(2000);
            theCVIInvestorPage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
          
            Assert.IsTrue(theCVIInvestorPage.body.Text.Contains("Postcode is required"), "Check postcode blank");
            Assert.IsTrue(theCVIInvestorPage.body.Text.Contains("Address line 1 is required"), "Check address line 1 blank");
            Assert.IsTrue(theCVIInvestorPage.body.Text.Contains("Town or city is required"), "Check town or city blank");
        }

        [When(@"The user clicks on the Reason to believe button and then the Continue Application button")]
        public void WhenTheUserClicksOnTheReasonToBelieveButtonAndThenTheContinueApplicationButton()
        {
            Debug.WriteLine("Debug: In Investor CVI 2 screen");
            theCVIInvestor2Page.clickOnReasonBtn();
            theCVIInvestor2Page.clickOnContinueBtn();
        }

        [Then(@"All the required error messages for no input to the CVI Investor Page 2 screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheCVIInvestorPageScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "CVIInvestorPage2NoInput";

            Helper.pause(2000);
            theCVIInvestor2Page.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theCVIInvestor2Page.body.Text.Contains("Please select an option for 'evidence obtained'"),"Check evidence obtained blank");
            Assert.IsTrue(theCVIInvestor2Page.body.Text.Contains("'Please indicate why follow up action is required' should not be empty"), "Check follow up action blank");
        }

        [When(@"The user selects Previous Address checkbox in the Donor CVI screen, clears the name fields and clicks on the Continue Application button")]
        public void WhenTheUserSelectsPreviousAddressCheckboxInTheDonorCVIScreenAndClicksOnTheContinueApplicationButton()
        {
            Helper.pause(2000);
            Debug.WriteLine("Debug: In Donor CVI screen");
            theCVIDonorPage.ClearNameFields();
            theCVIDonorPage.TickChangedAddress();
            theCVIDonorPage.clickOnContinueApplicationBtn();
        }

        [Then(@"All the required error messages for no input to the CVI Donor screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheCVIDonorScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "CVIDonorNoInput";

            Helper.pause(2000);
            theCVIInvestorPage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theCVIDonorPage.body.Text.Contains("Surname is required"), "Check surnname blank");
            Assert.IsTrue(theCVIDonorPage.body.Text.Contains("'Other names' should not be empty"), "Check other names blank");
            Assert.IsTrue(theCVIDonorPage.body.Text.Contains("Postcode is required"), "Check postcode blank");
            Assert.IsTrue(theCVIDonorPage.body.Text.Contains("Address line 1 is required"), "Check address line 1 blank");
            Assert.IsTrue(theCVIDonorPage.body.Text.Contains("Town or city is required"), "Check town or city blank");
        }

        [When(@"The user clicks on the Donor Reason to believe button and then the Continue Application button")]
        public void WhenTheUserClicksOnTheDonorReasonToBelieveButtonAndThenTheContinueApplicationButton()
        {
            theCVIDonor2Page.clickOnReasonBtn();
            theCVIDonor2Page.clickOnContinueBtn();
        }

        [Then(@"All the required error messages for no input to the CVI Donor Page (.*) screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheCVIDonorPageScreenAreDisplayed(int p0)
        {
            string subfolder = "noinput";
            string fileName = "CVIDonorPage2NoInput";

            Helper.pause(2000);
            theCVIDonor2Page.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theCVIDonor2Page.body.Text.Contains("Please select an option for 'evidence obtained'"), "Check evidence obtained blank");
            Assert.IsTrue(theCVIDonor2Page.body.Text.Contains("'Please indicate why follow up action is required' should not be empty"), "Check follow up action blank");                                                      
        }

        [When(@"The user enters any valid data in the CVI Donor 2 screen and clicks on the Continue application button")]
        public void WhenTheUserEntersAnyValidDataInTheCVIDonorScreenAndClicksOnTheContinueApplicationButton()
        {
            theCVIDonor2Page.clickOnMeetsEvidenceBtn();
            Helper.pause(2000);
            theCVIDonor2Page.clickOnContinueBtn();
        }

        [Then(@"All the required error messages for no input to the Adviser Declaration screen are displayed")]
        public void ThenAllTheRequiredErrorMessagesForNoInputToTheAdviserDeclarationScreenAreDisplayed()
        {
            string subfolder = "noinput";
            string fileName = "AdviserDeclarationNoInput";

            Helper.pause(2000);
            theAdviserDeclarationPage.TakeScreenshot(GetScreenshotFilename(subfolder, fileName));
            Assert.IsTrue(theAdviserDeclarationPage.body.Text.Contains("Money laundering checks must be carried out"), "Check money laudering blank");
            Assert.IsTrue(theAdviserDeclarationPage.body.Text.Contains("Confirmation of Identity Verification is required"), "Check CVI blank");
            Assert.IsTrue(theAdviserDeclarationPage.body.Text.Contains("Investor's bank details need to be verified"), "Check bank details blank");
            Assert.IsTrue(theAdviserDeclarationPage.body.Text.Contains("Source of funds needs to be identified"), "Checksource of funds blank");
        }

    }
}

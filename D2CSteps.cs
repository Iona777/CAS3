using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TechTalk.SpecFlow;
using BusinessTests.Phase2.Utilities;
using BusinessTests.Phase2.Constants;
using BusinessTests.Phase2.Pages;
using BusinessTests.Phase2.Pages.D2C_Pages;
using ApplicationManager.ServiceMessages.v2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class D2CSteps
    {
        //Class variables
        D2C_WelcomePage             theD2CWelcomePage;
        D2C_NewInvestorDetailsPage  theD2CNewInvestorDetailsPage;
        D2C_YourDetailsPage         theD2CYourDetailsPage;
        D2C_InvestmentDetailsPage   theD2CInvestmentDetailsPage;
        D2C_RegularWithdrawalPage   theD2CRegularWithdrawalPage;
        D2C_TransferInPage          theD2CTransferInPage;
        D2C_DirectDebitPage         theD2CDirectDebitPage;
        D2C_SummaryPage             theD2CSummaryPage;
        D2C_InvestorDeclarationPage theD2CInvestorDeclarationPage;
        D2C_NextStepsPage           theD2CNextStepsPage;
        D2C_HostedPaymentPage       theD2CHostedPaymentPage;
        D2C_PaymentSuccessfulPage   theD2CPaymentSuccessfulPage;
        
         
        IsaApplication mainData;


        //Class constructor
        public D2CSteps()
        {
           //Create all the page objects required by the test
           theD2CWelcomePage            = new D2C_WelcomePage(Driver.driver);
           theD2CNewInvestorDetailsPage = new D2C_NewInvestorDetailsPage(Driver.driver);
           theD2CYourDetailsPage        = new D2C_YourDetailsPage(Driver.driver);
           theD2CInvestmentDetailsPage  = new D2C_InvestmentDetailsPage(Driver.driver);
           theD2CRegularWithdrawalPage  = new D2C_RegularWithdrawalPage(Driver.driver);
           theD2CTransferInPage         = new D2C_TransferInPage(Driver.driver);
           theD2CDirectDebitPage        = new D2C_DirectDebitPage(Driver.driver);
           theD2CSummaryPage            = new D2C_SummaryPage(Driver.driver);
           theD2CInvestorDeclarationPage = new D2C_InvestorDeclarationPage(Driver.driver);
           theD2CNextStepsPage          = new D2C_NextStepsPage(Driver.driver);
           theD2CHostedPaymentPage     = new D2C_HostedPaymentPage(Driver.driver);
           theD2CPaymentSuccessfulPage = new D2C_PaymentSuccessfulPage(Driver.driver);



        
        }

        public IsaApplication GetInputData(string fileName)
        {

            string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\D2CTestData\\" + fileName;
            
            string inputData = File.ReadAllText(DataFile);

            mainData = JsonConvert.DeserializeObject<IsaApplication>(inputData);
            return mainData;

        }


        //Code that runs the BDD scenarios

        [Given(@"That the investor is on the the D2C Welcome page")]
        public void GivenThatTheInvestorIsOnTheTheDCWelcomePage()
        {
            Driver.NavigateTo(ConstantsList.d2cWelcome);
            Helper.WaitForElement(theD2CWelcomePage.D2C_WelcomeHeader); //Just wait for header and pause so use can see page load
            Helper.pause(2000);
            Assert.IsTrue(Driver.driver.Title == "Prudential ISA applications", "Check that we are on D2C Welcome page");
           
        }

        [When(@"The investor clicks on Continue on the D2C Welcome page")]
        public void WhenTheInvestorClicksOnContinueOnTheDCWelcomePage()
        {
            theD2CWelcomePage.ClickOnContinueBtn();
            Helper.pause(2000);
        }

        [Then(@"The D2C Details page should be displayed")]
        public void ThenTheDCDetailsPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CNewInvestorDetailsPage.NewInvestorDetailsHeader);
            Helper.pause(1000);
        }


        [When(@"The user enters valid data in the D2C Details screen using file '(.*)' and clicks on the Continue button")]
        public void WhenTheUserEntersValidDataInTheDCDetailsScreenUsingFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CNewInvestorDetailsPage.EnterAllValid(GetInputData(fileName));
            theD2CNewInvestorDetailsPage.clickOnContinueBtn();
        }



        [When(@"The investor enters valid hardcoded data on the D2C Details screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataOnTheDCDetailsScreenAndClicksOnTheContinueButton()
        {
            theD2CNewInvestorDetailsPage.EnteHardCodedAllValid();
            theD2CNewInvestorDetailsPage.clickOnContinueBtn();
        }

        [Then(@"The D2C Your Details page should be displayed")]
        public void ThenTheDCYourDetailsPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CYourDetailsPage.YourDetailsHeader);
            Helper.pause(1000);
        }

        [When(@"The user enters valid data in the D2C Your Details screen using the file '(.*)' and clicks on the Continue button")]
        public void WhenTheUserEntersValidDataInTheDCYourDetailsScreenUsingTheFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CYourDetailsPage.EnterAllValid(GetInputData(fileName));
            theD2CYourDetailsPage.clickOnContinueBtn();
        }


        [When(@"The investor enters valid hardcoded data in the D2C Your Details screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataInTheDCYourDetailsScreenAndClicksOnTheContinueButton()
        {
            theD2CYourDetailsPage.EnterHardCodedAllValid();
            theD2CYourDetailsPage.clickOnContinueBtn();
        }

        [Then(@"The D2C Investment Details page should be displayed")]
        public void ThenTheDCInvestmentDetailsPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CInvestmentDetailsPage.InvestmentDetailsHeader);
            Helper.pause(1000);
        }

        [When(@"The investor enters valid data in the D2C Transfer In screen using the file '(.*)' and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidDataInTheDCTransferInScreenUsingTheFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CTransferInPage.EnterAllValid(GetInputData(fileName));
            theD2CTransferInPage.clickOnContinueButton();
        }



        [When(@"The investor enters valid hardcoded data for Single investment on the D2C Investment Details screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataForSingleInvestmentOnTheDCInvestmentDetailsScreenAndClicksOnTheContinueButton()
        {
            theD2CInvestmentDetailsPage.EnterAllValidSingleInvestment();
            Helper.pause(2000);
            theD2CInvestmentDetailsPage.clickOnContinueBtn();
        }

        [When(@"The investor enters valid hardcoded data for Single, Regular and Transfer In investments on the D2C Investment Details screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataForSingleRegularAndTransferInInvestmentsOnTheDCInvestmentDetailsScreenAndClicksOnTheContinueButton()
        {
            
            
            theD2CInvestmentDetailsPage.EnterAllValidSingleInvestment();
            theD2CInvestmentDetailsPage.EnterAllValidRegularInvestment();
            theD2CInvestmentDetailsPage.EnterAllValidTransferIn();
            Helper.pause(2000);
            theD2CInvestmentDetailsPage.clickOnContinueBtn();
        }

        [Then(@"The D2C Regular Withdrawal page should be displayed")]
        public void ThenTheDCRegularWithdrawalPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CRegularWithdrawalPage.RegularWithdrawalHeader);
            Helper.pause(1000);

        }

        [When(@"The investor enters valid hardcoded data in the D2C Regular Withdrawl screen for a single fund and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataInTheDCRegularWithdrawlScreenForASingleFundAndClicksOnTheContinueButton()
        {
            theD2CRegularWithdrawalPage.EnterHardCodedAllValid();
            theD2CRegularWithdrawalPage.clickOnContinueBtn();
        }

        [When(@"The investor enters valid data in the D2C Regular Withdrawal screen for a single fund using the file '(.*)' and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidDataInTheDCRegularWithdrawalScreenForASingleFundUsingTheFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CRegularWithdrawalPage.EnterAllValidSingleFund(GetInputData(fileName));
            theD2CRegularWithdrawalPage.clickOnContinueBtn();
        }

        [Then(@"The D2C Transfer In page should be displayed")]
        public void ThenTheDCTransferInPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CTransferInPage.TransferInHeader);
            Helper.pause(1000);
        }

        [When(@"The investor enters valid hardcoded data in the D2C Transfer In screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataInTheDCTransferInScreenAndClicksOnTheContineButton()
        {
            theD2CTransferInPage.EnterHardCodedAllValid();
            Helper.pause(2000);
            theD2CTransferInPage.clickOnContinueButton();
        }

        [Then(@"The D2C Direct Debit page should be displayed")]
        public void ThenTheDCDirectDebitPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CDirectDebitPage.DirectDebitHeader);
            Helper.pause(1000);
        }


        [When(@"The investor enters valid data in the D2C Direct Debit screen using the file '(.*)' and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidDataInTheDCDirectDebitScreenUsingTheFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CDirectDebitPage.EnterAllValid(GetInputData(fileName));
            theD2CDirectDebitPage.ClickOnContinueBtn();
        }



        [When(@"The investor enters valid hardcoded data in the D2C Direct Debit screen and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidHardcodedDataInTheDCDirectDebitScreenAndClicksOnTheContinueButton()
        {
            theD2CDirectDebitPage.EnterHardCodedAllValid();
            theD2CDirectDebitPage.ClickOnContinueBtn();
            Helper.pause(5000);
        }


        [Then(@"The D2C Summary page should be displayed")]
        public void ThenTheDCSummaryPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CSummaryPage.SummaryHeader);
            Helper.pause(2000);
        }

        [When(@"The investor clicks on the Continue button in the D2C Summary page")]
        public void WhenTheInvestorClicksOnTheContinueButtonInTheDCSummaryPage()
        {
            theD2CSummaryPage.ClickOnContinueBtn();
            Helper.pause(2000);
        }

        [Then(@"The D2C Investor Declaration page should be displayed")]
        public void ThenTheDCInvestorDeclarationPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CInvestorDeclarationPage.InvestorDeclarationHeader);
            Helper.pause(2000);
        }

        [When(@"The investor enters valid data in the D2C Investor Declaration screen using the file '(.*)' and clicks on the Continue button")]
        public void WhenTheInvestorEntersValidDataInTheDCInvestorDeclarationScreenUsingTheFileAndClicksOnTheContinueButton(string fileName)
        {
            theD2CInvestorDeclarationPage.EnterAllValid(GetInputData(fileName));
            theD2CInvestorDeclarationPage.ClickOnContinueBtn();
            Helper.pause(2000);
        }


        [Then(@"The D2C Next Steps page should be displayed")]
        public void ThenTheDCNextStepsPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CNextStepsPage.NextStepsHeader);
            Helper.pause(2000);
        }


        [When(@"The investor clicks on the Continue button in the D2C Next Steps page")]
        public void WhenTheInvestorClicksOnTheContinueButtonInTheDCNextStepsPage()
        {
            theD2CNextStepsPage.clickOnContinueButton();
            Helper.pause(2000);
        }

        [Then(@"The Hosted Payment Page should be displayed")]
        public void ThenTheHostedPaymentPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CHostedPaymentPage.PaymentPageLogo);
            Helper.pause(2000);
        }

        [When(@"The investor enters valid hardcoded data in the D2C Hosted Payment screen and clicks on the Pay Now button")]
        public void WhenTheInvestorEntersValidHardcodedDataInTheDCHostedPaymentScreenAndClicksOnThePayNowButton()
        {
            theD2CHostedPaymentPage.EnterHardcodedAllValid();
            theD2CHostedPaymentPage.ClickOnPayNowBtn();
        }

        [Then(@"The D2C Payment successful page should be displayed")]
        public void ThenTheDCPaymentSuccessfulPageShouldBeDisplayed()
        {
            Helper.WaitForElement(theD2CPaymentSuccessfulPage.SuccessfulHeader);
            Helper.pause(3000);
        }

    }
}

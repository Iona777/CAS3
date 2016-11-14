using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.ApplicationManager.ServiceMessages.v2.Models;

namespace Capita.PruApp.BusinessTests.Phase2.Pages.D2C_Pages
{
    [Binding]
    public sealed class D2C_HostedPaymentPage
    {
        //Class constructor
        public D2C_HostedPaymentPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this); //see it if will work with the driver paramenter rathr than driver in utility

        }


        //Felds
    [FindsBy (How= How.CssSelector, Using = "[class='payment-logo visa-logo'][title='Visa']")]
    public IWebElement PaymentPageLogo;

    [FindsBy(How = How.Id, Using = "cardRegistration-pan-value")]
    private IWebElement CardNumber;

    [FindsBy(How = How.Id, Using = "cardRegistration-cardHolder")]
    private IWebElement CardHolderName;

    [FindsBy(How = How.Id, Using = "cardRegistration-expiryMonth")]
    private IWebElement ExpiryMonth;

    [FindsBy(How = How.Id, Using = "cardRegistration-expiryYear")]
    private IWebElement ExpiryYear;

    [FindsBy(How = How.Id, Using = "cardTransaction-csc")]
    private IWebElement CSCNumber;

    [FindsBy(How = How.XPath, Using = "//*[@class='transactionAmount']/span")]
    private IWebElement AmountReadOnly;



     //Buttons
     [FindsBy(How = How.Name, Using = "registernow")]
     private IWebElement PayNowBtn;

     [FindsBy(How = How.Id, Using = "cancel_btn")]
     private IWebElement CancelBtn;

      //Methods
      public void EnterCardNumber(string cardno)
      {
            Helper.EnterText(cardno, CardNumber);
      }

      public void EnterCardholderName(string name)
      {
            Helper.EnterText(name, CardHolderName);
      }


      public void EnterExpiryDate(string month, string year)
      {
            Helper.EnterText(month, ExpiryMonth);
            Helper.EnterText(year, ExpiryYear);
      }

      public void EnterCSCNo(string number)
      {
            Helper.EnterText(number, CSCNumber);
      }

      public string GetAmount()
       {
            Helper.WaitForElement(AmountReadOnly);
            return AmountReadOnly.Text;
       }

      public void ClickOnCancelBtn() //This will take user to Payment Failure page
      {
          Helper.ClickOnButton(CancelBtn);

      }
      public void ClickOnPayNowBtn() //This will take the user to the Payment Successful screen (via the confirming payment screen)
      {
            Helper.ClickOnButton(PayNowBtn);
      }


      public void EnterHardcodedAllValid()
      {
            EnterCardNumber("9902000000000018");
            EnterCardholderName("Harry Hardcoded");
            EnterExpiryDate("11","19");
            EnterCSCNo("123");
      }
    


}
}

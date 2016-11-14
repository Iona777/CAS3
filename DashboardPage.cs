using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Constants;


namespace Capita.PruApp.BusinessTests.Phase2.Pages
{
    public class DashboardPage : BasePage
    {

        public DashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        //Elements
        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Start a new application')]")]
        private IWebElement dashboardHeader;


        [FindsBy(How = How.CssSelector, Using = "[ng-click='showApplications=true']")]
        private IWebElement showRecentBtn;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Apply now')]")]
        private IWebElement applyNowBtn;
        
        
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/div[1]/main/div[3]/div/div[1]/div[1]/box/div/div/box-body/ul/li[2]/span[2]")]
        public IWebElement ifaCode;

        [FindsBy(How = How.CssSelector, Using = "span[class='ng-binding']")]
        private IList<IWebElement> Status;



        //Methods
        public bool checkIFaCode(string submittedIFACode) 
        {
            Helper.WaitForElement(ifaCode);
            Assert.AreEqual(submittedIFACode,ifaCode.Text, "Check correct IFA Code displayed");
            return true;
        }

        public string getHeader()
        {
            Helper.pause(1000); //Hack to get around intermittent synchronization issue
            Helper.WaitForElement(dashboardHeader);
            return dashboardHeader.Text;
            
        }


        public void clickShowRecentApplicationsbtn()
        {
            Helper.ClickOnButton(showRecentBtn);
            Console.WriteLine("button text is: "+showRecentBtn.Text);
        }


        public string getStatus(int index)
        {
            return Status[index].Text.ToString();
        }

        public void clickApplyNowbtn()
        {
            Helper.ClickOnButton(applyNowBtn);
        }
    }
}

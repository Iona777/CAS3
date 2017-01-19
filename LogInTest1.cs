using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BusinessTests.Phase2.Utilities;
using BusinessTests.Phase2.Constants;
using BusinessTests.Phase2.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BusinessTests.Phase2.Tests.Step_Definitions
{
    [Binding]
    public sealed class LogInTest1
    {

        //Page Objects
        LoginPage theLoginPage;
        DashboardPage theDashboardPage;

        //Class constructor
        public LogInTest1()
        {
            //Create all the page objects required by the test
            theLoginPage = new LoginPage(Driver.driver);
            theDashboardPage = new DashboardPage(Driver.driver);
        }




        [Given(@"That the user is on the the Login page")]
        public void GivenThatTheUserIsOnTheTheLoginPage()
        {
            //Navigate to the initial page
            Driver.NavigateTo(ConstantsList.pruAppLogin);

            // Check LoginPage title to see if we are on the right page
            theLoginPage.checkTitle(ConstantsList.Eden_LoginTitle);
            Thread.Sleep(3000);
        }





        [When(@"They enter valid login credentials and click on the Login button")] //Equivalent to [TestMethod]
        public void LoginTest()
        {
            string userName = ConstantsList.ifaOne;
            string password = ConstantsList.password;

            //Login will enter the username and password and click on the login button
            theLoginPage.Login(userName, password);
        }


        [Then(@"The Dashboard screen should be displayed")]
        public void AssertDashboardScreenDisplayed()
        {
            //Hack to get round inconsistent wait issue
            Helper.pause(1000);
            Assert.AreEqual(ConstantsList.Eden_DashboardHeader, theDashboardPage.getHeader(), "Check we are on dashboard page");
        }


    }
}

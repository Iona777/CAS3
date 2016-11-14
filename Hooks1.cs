using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Capita.PruApp.BusinessTests.Phase2.Pages;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Capita.PruApp.BusinessTests.Phase2.Tests
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        //These replace the [Test Initialize] and [Test Cleanup] that I put tin the BaseTest class
        //Were are not using Microsoft.VisualStudio.TestTools.UnitTesting, so not using [TestClass]
        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.OpenBrowser(ConstantsList.chrome);//CHANGE BROWSWER HERE.
            BasePage theBasePage = new BasePage();
            PageFactory.InitElements(Driver.driver, theBasePage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Driver.Quit();
        }
    }
}

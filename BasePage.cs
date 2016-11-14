using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Capita.PruApp.BusinessTests.Phase2.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Capita.PruApp.BusinessTests.Phase2.Constants;
using Newtonsoft.Json;


namespace Capita.PruApp.BusinessTests.Phase2.Pages 
{
    public class BasePage
    {
        [FindsBy(How = How.Id, Using = "logout-btn")]
        private IWebElement logoutBtn;

        [FindsBy(How = How.CssSelector, Using = "[translate='core.continue-application']")]
        public IWebElement continueAppbtn;

        [FindsBy(How = How.CssSelector, Using = ("[ng-click='saveAndExit()']"))]
        public IWebElement SaveAndExitBtn;

        [FindsBy(How = How.CssSelector, Using = ("button[ui-sref='app.dashboard']"))]
        public IWebElement ReturntoDashboardBtn;


        [FindsBy(How = How.ClassName, Using = "fa fa-arrow-right")]
        private IWebElement viewSummaryBtn;

        public IWebElement body = Driver.driver.FindElement(By.TagName("body")); //used to find error text on pages

        //Class variables
        private string DataFile = AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\Json Data Source Happy 1.json";
        private IsaApplication JsonData;

        //Various useful methods
        public void Logout()
        {
            logoutBtn.Click();
        }
        

        public void checkTitle(String pageTitle)
        {
            Assert.AreEqual(pageTitle, Driver.driver.Title);
        }

       


        public IsaApplication getJsonData()
        {
            //Read from the data file. It is important that that this file is formatted correctly.
            //Free tools such as http://jsonlint.com/ can be used to check this.
            string inputData = File.ReadAllText(DataFile);

            //Take the data that has been read from the data file.
            //Copy the data to the dynamically created Json object, placing the various pieces of data
            //into the approrpriate field within the object (deserialization).
            //Because the Json object (newTarget) is created dynamically rather than declared in the code,
            //the compiler does not know anything about it before runtime.
            //This is why we use generic object for the input data and use Convert.ToString() for
            //elements of newTarget in the var lines.
            //For somethiing this small, it would be better to declare the Json object in the code as
            //that would make it easier to refer to. 
            //However, if you had an object for the whole application, then this would be impractical
            //and a dynamically created object is better. 
            //The exception to this is when a model has been created for use, as in the case below.

            //Here Dynamic and object are replaced by IsaApplication.
            //IsaApplication is the top level class within the model. All the other classes are included within IsaApplication.
            //The method will return an IsaApplication which can them be put into IsaApplication JsonData and then all
            //the data elements can be accessed as JsonData.whatever

            IsaApplication myApp = JsonConvert.DeserializeObject<IsaApplication>(inputData);

            return myApp;
          
        }

        public int getFieldTextLength(IWebElement ele)
        {
            return ele.GetAttribute("value").Length;
        }

        public bool checkFieldNotNull(IWebElement ele)
        {
            if (getFieldTextLength(ele) == 0)
            { return false; }
            else
            { return true; }
        }



        public void TakeScreenshot(string fileName)
        {
            Screenshot camera = ((ITakesScreenshot)Driver.driver).GetScreenshot();
            camera.SaveAsFile(fileName,ImageFormat.Png);
        }

    }
}

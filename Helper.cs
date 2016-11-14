using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using Capita.PruApp.BusinessTests.Phase2.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Capita.PruApp.BusinessTests.Phase2.Utilities
{
    public static class Helper
    {

        //Class variables - need these for the getJsonData() method

        //A better approach would be to pass the DataFile name into getJsonData() as a paramenter.
        static string DataFile = "C:\\Users\\gmacdonald\\Documents\\Visual Studio 2015\\Projects\\Json Data Source 2.json";
        static IsaApplication JsonData;


        // Methods that were previously in BaseTest or BasePage can go here.
        //Since the methods that use the WebDriverWait are here, it needs to be here too.

        private static WebDriverWait _wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(30));

       
        public static void pause(int time)
        {
            Thread.Sleep(time);
        }

        public static void moveToElement(IWebElement element)
        {
            Actions act = new Actions(Driver.driver);
            act.MoveToElement(element);
            Thread.Sleep(500);
        }

        public static void WaitForElement(IWebElement element)
        {
            //Been getting some stales element references, so use this code to handle it.
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    break;
                }
                catch (StaleElementReferenceException stale)
                {

                    Debug.WriteLine("Debug: got a stale element exception, will try a few more times");
                }
            }      
        }

        public static void scrollDown()
        {
            Debug.WriteLine("In scroll down");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Debug.WriteLine("end of scroll down");
            Thread.Sleep(500);
        }

        public static void EnterText(string input, IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).SendKeys(input);
        }

        //The code for selecting a radio button, ticking a checkbox and clicking a button are identical. 
        //Separate methods are just included for readability. Better to say what you are clicking on/selecting.

        public static void SelectRadioBtn(IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void TickCheckBox(IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void ClickOnButton(IWebElement element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void SelectByValue(string input, IWebElement element)
        {
            SelectElement selector = new SelectElement(element);
            
            Helper.pause(250);
            selector.SelectByValue(input);
        }


        public static void SelectByText(string input, IWebElement element)
        {
            SelectElement selector = new SelectElement(element);
            
            Helper.pause(250);
            selector.SelectByText(input);
        }

        public static void SelectByIndex(int index, IWebElement element)
        {
            SelectElement selector = new SelectElement(element);
            
            Helper.pause(1000);
            selector.SelectByIndex(index);
        }

        public static int getIndexOfLastArrayElement<T>(IList<T> list)
        {
            int lastIndex = list.Count - 1;
            return lastIndex;
        }

        public static void EnterTextInArray(string input, IList<IWebElement> elementList, int index )
        {
            elementList[index].SendKeys(input);
        }

        public static IsaApplication getJsonData()
        {
            //Read from the data file. It is important that that this file is formatted correctly.
            //Free tools such as http://jsonlint.com/ can be used to check this.
            //Best way is to put required application through then use postman to view the data then
            //save into a Json file.
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
    }
}

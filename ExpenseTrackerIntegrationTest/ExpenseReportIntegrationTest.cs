
using ExpenseTrackerWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ExpenseTrackerIntegrationTest
{
    [TestClass]
    public class ExpenseReportIntegrationTest
    {

        IWebDriver _driver;


        [TestInitialize]

        public void Startup() {

            //setup

            new DriverManager().SetUpDriver(new ChromeConfig());

            _driver = new ChromeDriver();
        }




        [TestMethod]

        public void TestEmptyEntryIsInvalid() {
           
        }


        [TestMethod]

        public void TesNegativeAmountIsInvalid()
        {

        }


        [TestMethod]

        public void TestInvalidDateEntry()
        {

        }


        [TestMethod]
        public void TestValidExpenseEntryIsAdded()
        {

            _driver.Navigate().GoToUrl("https://localhost:44321");


            int count= _driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            // goto the create page

            _driver.Navigate().GoToUrl("https://localhost:44321/ExpensesReport/Create");

            var expense = _driver.FindElement(By.Id("ItemName"));

            var amount = _driver.FindElement(By.Id("Amount"));

            var date = _driver.FindElement(By.Id("ExpenseDate"));

            var category = _driver.FindElement(By.Id("Category"));

            var form = _driver.FindElement(By.Id("Create"));

            //start interacting eith theUI 

            expense.SendKeys("beer");
            amount.SendKeys("10");
            date.SendKeys("04/06/2021");
            category.SendKeys("drinks");
            form.Submit();


            
            // find the list in the  expense report page

            // _driver.Navigate().GoToUrl("https://localhost:44321/");

            var tablwrows = _driver.FindElements(By.CssSelector("body > div > main > table"));

            IWebElement webElement = tablwrows[0];

            var rows = webElement.FindElements(By.CssSelector("body > div > main > table > tbody > tr"));


            int countNew = rows.Count;

            // count not same means the table has been updated

            Assert.AreNotEqual(count, countNew);
           

        }


        [TestMethod]
        public void TestValidExpenseEntryCanBeEdited()
        {

            _driver.Navigate().GoToUrl("https://localhost:44321/ExpensesReport/Create/1");

            var expense = _driver.FindElement(By.Id("ItemName"));

            var amount = _driver.FindElement(By.Id("Amount"));

            var date = _driver.FindElement(By.Id("ExpenseDate"));

            var category = _driver.FindElement(By.Id("Category"));

            var form = _driver.FindElement(By.Id("Create"));

            //start interacting eith theUI 

            expense.SendKeys("editedItem");
            amount.SendKeys("200");
            date.SendKeys("21/2/2020");
            category.SendKeys("food");
            form.Submit();


            // find the list in the  expense report page

            // _driver.Navigate().GoToUrl("https://localhost:44321/");

            var tablwrows = _driver.FindElements(By.CssSelector("body > div > main > table"));

            IWebElement webElement = tablwrows[0];

            var rows = webElement.FindElements(By.CssSelector("body > div > main > table > tbody > tr"));


            var rowItem = rows[0];

           var items =  rowItem.FindElements(By.CssSelector("body > div > main > table > tbody > tr > td"));

            IWebElement item = items[0];

            // count  same means the table has not been updated
           // string value = item.

            Assert.AreEqual(item, "editedItem");


        }


        [TestMethod]
        public void TestValidExpenseEntryisDeleted()
        {
            _driver.Navigate().GoToUrl("https://localhost:44321");


            int count = _driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            // goto the create page

            _driver.Navigate().GoToUrl("https://localhost:44321/");

            var delButton = _driver.FindElement(By.CssSelector("body > div > main > table > tbody > tr:nth-child(1) > td:nth-child(5) > a:nth-child(3)"));

            delButton.Click();

            var tablwrows = _driver.FindElements(By.CssSelector("body > div > main > table"));

            IWebElement webElement = tablwrows[0];

            var rows = webElement.FindElements(By.CssSelector("body > div > main > table > tbody > tr"));


            int countNew = rows.Count;
            Assert.AreNotEqual(count,countNew);
        }

        [TestMethod]

        public void TestInvalidExpenseEntryCannotBeAdded() {

            _driver.Navigate().GoToUrl("https://localhost:44321");


            int count = _driver.FindElements(By.CssSelector("body > div > main > table > tbody > tr")).Count;
            // goto the create page

            _driver.Navigate().GoToUrl("https://localhost:44321/ExpensesReport/Create");

            var expense = _driver.FindElement(By.Id("ItemName"));

            var amount = _driver.FindElement(By.Id("Amount"));

            var date = _driver.FindElement(By.Id("ExpenseDate"));

            var category = _driver.FindElement(By.Id("Category"));

            var form = _driver.FindElement(By.Id("Create"));

            //start interacting eith theUI 

            expense.SendKeys("");
            amount.SendKeys("");
            date.SendKeys("");
            category.SendKeys("");
            form.Submit();



            // find the list in the  expense report page

            // _driver.Navigate().GoToUrl("https://localhost:44321/");

            var tablwrows = _driver.FindElements(By.CssSelector("body > div > main > table"));

            IWebElement webElement = tablwrows[0];

            var rows = webElement.FindElements(By.CssSelector("body > div > main > table > tbody > tr"));


            int countNew = rows.Count;

            // count  same means the table has not been updated

            Assert.AreEqual(count, countNew);

        }


        [TestCleanup]

        public void ShutDown()
        {

            _driver.Quit();
              
        }
        
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        }


        [TestMethod]
        public void TestValidExpenseEntryCanBeEdited()
        {

            _driver.Navigate().GoToUrl("https://localhost:44321/ExpensesReport/Create");

            var expense = _driver.FindElement(By.CssSelector(""));

            var amount = _driver.FindElement(By.CssSelector(""));

            var date = _driver.FindElement(By.CssSelector(""));

            var category = _driver.FindElement(By.CssSelector(""));

            var form = _driver.FindElement(By.CssSelector("form"));

            //start interacting eith theUI 

            expense.SendKeys("");
            amount.SendKeys("");
            date.SendKeys("");
            category.SendKeys("");
            form.Submit();

        }


        [TestMethod]
        public void TestValidExpenseEntryisDeleted()
        {

            _driver.Navigate().GoToUrl("https://localhost:44321/");

            var expense = _driver.FindElement(By.CssSelector(""));

            var amount = _driver.FindElement(By.CssSelector(""));

            var date = _driver.FindElement(By.CssSelector(""));

            var category = _driver.FindElement(By.CssSelector(""));

            var form = _driver.FindElement(By.CssSelector("form"));

        }


        
    }
}

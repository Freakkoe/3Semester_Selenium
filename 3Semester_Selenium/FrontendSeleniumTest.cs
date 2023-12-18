using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace _3Semester_Selenium
{
    [TestClass]
    public class FrontendSeleniumTest
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;
        
        private static string _baseURL = "URL"; //Indtast url på siden der ønskes (Enten som local fil c:/X/X/X.html eller direkte URL)


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            // _driver = new FirefoxDriver(DriverDirectory);  // slow
            // _driver = new EdgeDriver(DriverDirectory); // times out ... not working
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TitleTest()
        {
            _driver.Navigate().GoToUrl(_baseURL);

            Assert.AreEqual("Zealand Connect", _driver.Title);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void LoginTest()
        {
            _driver.Navigate().GoToUrl(_baseURL);

            IWebElement username = _driver.FindElement(By.Id("usernameInput"));
            username.SendKeys("Test");
            Thread.Sleep(1000);

            IWebElement password = _driver.FindElement(By.Id("passwordInput"));
            password.SendKeys("Test");
            Thread.Sleep(1000);

            IWebElement login = _driver.FindElement(By.Id("loginButton"));
            login.Click();
        }

        [TestMethod]
        public void DateSelectorTest()
        {
            _driver.Navigate().GoToUrl(_baseURL);
            IWebElement dateSelector = _driver.FindElement(By.Id("selectedDate"));
            dateSelector.SendKeys("2023-12-18");
            IWebElement dateButton = _driver.FindElement(By.Id("date-button"));
            dateButton.Click();
            Thread.Sleep(1000);
        }


        [TestMethod]
        public void HereTodayCounterTest()
        {
            _driver.Navigate().GoToUrl(_baseURL);
            IWebElement hereTodayCounter = _driver.FindElement(By.Id("hereTodayCounter"));
            Assert.AreEqual("0", hereTodayCounter.Text);
            Thread.Sleep(1000);
        }


        [TestMethod]
        public void NotHereTodayCounterTest()
        {
            _driver.Navigate().GoToUrl(_baseURL);
            IWebElement notHereTodayCounter = _driver.FindElement(By.Id("notHereTodayCounter"));
            Assert.AreEqual("0", notHereTodayCounter.Text);
            Thread.Sleep(1000);
        }

    }
}
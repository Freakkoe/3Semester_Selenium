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
            _driver.Navigate().GoToUrl("file://C:/Users/madsg/Desktop/3Semester_Frontend/3Semester_Frontend-DevBabz/3Semester_Frontend-DevBabz/index.html");

            Assert.AreEqual("Zealand Connect", _driver.Title);
            Thread.Sleep(1000);
        }


        [TestMethod]
        public void HereTodayCounterTest()
        {
            _driver.Navigate().GoToUrl("file://C:/Users/madsg/Desktop/3Semester_Frontend/3Semester_Frontend-DevBabz/3Semester_Frontend-DevBabz/index.html");

            IWebElement hereTodayCounter = _driver.FindElement(By.Id("hereTodayCounter"));
            Assert.AreEqual("8", hereTodayCounter.Text);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void NotHereTodayCounterTest()
        {
            _driver.Navigate().GoToUrl("file://C:/Users/madsg/Desktop/3Semester_Frontend/3Semester_Frontend-DevBabz/3Semester_Frontend-DevBabz/index.html");

            IWebElement notHereTodayCounter = _driver.FindElement(By.Id("notHereTodayCounter"));
            Assert.AreEqual("6", notHereTodayCounter.Text);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void LoginTest()
        {
            _driver.Navigate().GoToUrl("file://C:/Users/madsg/Desktop/3Semester_Frontend/3Semester_Frontend-DevBabz/3Semester_Frontend-DevBabz/index.html");

            IWebElement username = _driver.FindElement(By.Id("Username"));
            username.SendKeys("Test");
            Thread.Sleep(1000);

            IWebElement password = _driver.FindElement(By.Id("Password"));
            password.SendKeys("Test");
            Thread.Sleep(1000);

            IWebElement login = _driver.FindElement(By.Id("Login"));
            login.Click();
        }
    }
}
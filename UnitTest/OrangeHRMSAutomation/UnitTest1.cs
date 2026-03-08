using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace OrangeHRMSAutomation
{
    public class LoginTest
    {
        IWebDriver? driver;
        ExtentReports? extent;
        ExtentTest? test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            var sparkReporter = new ExtentSparkReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginToOrangeHRMS()
        {
            driver!.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            test = extent!.CreateTest("OrangeHRM Login Test");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement username = wait.Until(
                    ExpectedConditions.ElementIsVisible(By.Name("username")));

                username.SendKeys("Admin");

                driver.FindElement(By.Name("password")).SendKeys("admin123");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                wait.Until(ExpectedConditions.UrlContains("dashboard"));

                Assert.That(driver.Url, Does.Contain("dashboard"));

                test.Pass("OrangeHRM login successful");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                throw;
            }
        }

        [Test]
        public void LoginToSauceDemo()
        {
            driver!.Navigate().GoToUrl("https://www.saucedemo.com/");
            test = extent!.CreateTest("SauceDemo Login Test");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")))
                    .SendKeys("standard_user");

                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                driver.FindElement(By.Id("login-button")).Click();

                wait.Until(ExpectedConditions.UrlContains("inventory"));

                Assert.That(driver.Url, Does.Contain("inventory"));

                test.Pass("SauceDemo login successful");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                throw;
            }
        }

        [Test]
        public void LoginSearchAddToCartTest()
        {
            driver!.Navigate().GoToUrl("https://automationexercise.com");
            test = extent!.CreateTest("AutomationExercise Add To Cart Test");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Signup"))).Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@data-qa='login-email']")))
                    .SendKeys("test123@example.com");

                driver.FindElement(By.XPath("//input[@data-qa='login-password']"))
                      .SendKeys("test123");

                driver.FindElement(By.XPath("//button[@data-qa='login-button']")).Click();

                wait.Until(d =>
                    d.FindElements(By.XPath("//a[contains(normalize-space(), 'Logout')]")).Count > 0 ||
                    d.FindElements(By.XPath("//p[contains(text(),'incorrect')]")).Count > 0);

                driver.Navigate().GoToUrl("https://automationexercise.com/products");

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search_product")))
                    .SendKeys("Tshirt");

                driver.FindElement(By.Id("submit_search")).Click();

                IWebElement product = wait.Until(
                    ExpectedConditions.ElementIsVisible(By.CssSelector(".features_items .product-image-wrapper")));

                Actions actions = new Actions(driver);
                actions.MoveToElement(product).Perform();

                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("(//div[@class='product-overlay']//a[contains(@class,'add-to-cart')])[1]"))).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("View Cart"))).Click();

                Assert.That(driver.Url, Does.Contain("view_cart"));

                test.Pass("Product successfully added to cart");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                throw;
            }
        }

        [TearDown]
        public void EndTest()
        {
            try
            {
                driver?.Dispose();
            }
            finally
            {
                driver = null;
            }
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent?.Flush();
        }
    }
}
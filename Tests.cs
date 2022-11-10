using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;

namespace DemoQA
{
    public class Tests : ConfigPack
    {
        //IWebDriver driver;
      
        [Test]
        public void Test1()
        {
            IWebElement bookStoreApp = driver.FindElement(By.XPath(Locators.bookStoreApp));
            (driver as IJavaScriptExecutor).ExecuteScript(Locators.JsScrollView, bookStoreApp);
            bookStoreApp.Click();
            string expectedBookPage = "Book Store";

            var bookPage = driver.FindElement(By.XPath(Locators.bookPage)).Text;
            Assert.That(expectedBookPage, Is.EqualTo (AssertLocators.bookPageAssert));

            IWebElement login = driver.FindElement(By.Id(Locators.login));login.Click();
            string loginTitle = driver.Url;
            Assert.IsTrue(loginTitle.Equals(AssertLocators.loginTitle));

            IWebElement username = driver.FindElement(By.Id(Locators.username));
            username.SendKeys("Vicmaylee");

            IWebElement password = driver.FindElement(By.Id(Locators.password));
            password.SendKeys("OlamidePro@9802");

            IWebElement userLogin = driver.FindElement(By.CssSelector(Locators.userLogin)); //userLogin.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript(Locators.JsClick, userLogin);
            Thread.Sleep(3000);

            string accountUsername = driver.FindElement(By.CssSelector (Locators.accountUsername)).Text;
            Assert.IsTrue(accountUsername.Equals(AssertLocators.accountUsername));

            var bookStorePage = driver.FindElement(By.XPath(Locators.bookStorePage)).Text;
            Assert.IsTrue(bookStorePage.Equals(AssertLocators.bookStorePage));

            IWebElement logOut = driver.FindElement(By.XPath(Locators.logOut)); logOut.Click();

            var loginWelcomePg = driver.FindElement(By.XPath(Locators.loginWelcomePg)).Text;
            Assert.IsTrue(loginWelcomePg.Equals(AssertLocators.loginWelcomePg));

        }

        [Test]

        public void TaskB()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
            //Thread.Sleep(3000);
            var widget = driver.FindElement(By.XPath("//div[@class='card-body'][.='Widgets']"));
            (driver as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView(true)", widget);
            widget.Click();

            var header = driver.FindElement(By.CssSelector(".main-header"));
            Assert.IsTrue(header.Displayed);
            Assert.AreEqual("Widgets", header.Text);

            var selectMenu = driver.FindElement(By.XPath("//span[contains(text(),'Select Menu')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", selectMenu);
            selectMenu.Click();

           
            Thread.Sleep(5000);
            Actions c = new Actions(driver);
            c.Click(driver.FindElement(By.XPath("//div[@class=' css-1wa3eu0-placeholder'][.='Select Title']"))).Perform();

            Thread.Sleep(5000);
           
            c.SendKeys("Mr.").Perform();
            c.SendKeys(Keys.Enter).Perform();
            
          
            var oldSelect = driver.FindElement(By.Id("oldSelectMenu"));
            SelectElement s = new SelectElement(oldSelect);
            s.SelectByValue("6");

        }

        [Test]

        public void TaskC()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
            var widget = driver.FindElement(By.XPath("//div[@class='card-body'][.='Widgets']"));
            (driver as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView(true)", widget);
            widget.Click();

            var header = driver.FindElement(By.CssSelector(".main-header"));
            Assert.IsTrue(header.Displayed);
            Assert.AreEqual("Widgets", header.Text);
           

            var menu = driver.FindElement(By.XPath("//span[contains(text(),'Menu')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)",menu);
            menu.Click();

            Actions s = new Actions(driver);
            s.Pause(TimeSpan.FromSeconds(2)).Perform();
            s.MoveToElement(driver.FindElement(By.XPath("//a[contains(text(),'Main Item 2')]"))).Perform();
            s.Pause(TimeSpan.FromSeconds(2)).Perform();
            s.MoveToElement(driver.FindElement(By.XPath("//a[contains(text(),'SUB SUB LIST »')]"))).Perform();
            s.Pause(TimeSpan.FromSeconds(2)).Perform();
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Sub Sub Item 1')]")).Text.Equals("Sub Sub Item 1"));
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Sub Sub Item 2')]")).Text.Equals("Sub Sub Item 2"));
        }

    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA
{
    public class ConfigPack
    {
        public enum BrowserType
        {
            Chrome, Edge,Firefox
        }

        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("incognito", "start-maximized");
            //driver = new ChromeDriver(options);
            driver = InitBrowser(BrowserType.Chrome);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(TestContext.Parameters["url"]);
        }

        public IWebDriver InitBrowser(BrowserType browserName) => browserName switch
        {
            BrowserType.Firefox => driver = GetFireFoxConfig(),
            BrowserType.Chrome => driver = GetChromeConfig(),
            BrowserType.Edge => driver = GetEdgeConfig(),
            _ => throw new Exception()
        };

        public IWebDriver GetFireFoxConfig()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            return driver;
        }

        public IWebDriver GetChromeConfig()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);
            return driver;
        }

        public IWebDriver GetEdgeConfig()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        [TearDown]
        public void QuitBrowser()
        {
           // driver.Quit();
        }

    }
}

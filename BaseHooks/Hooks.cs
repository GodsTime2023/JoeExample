using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace Test.BaseHooks;

public class Hooks
{
    public IWebDriver browser;
    [SetUp] //Open a browser
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--start-maximized");
        browser = new ChromeDriver(options);
        browser.Navigate().GoToUrl("https://demoqa.com");
        browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
    }

    [TearDown] //Closes your browser
    public void TearDown()
    {
        Thread.Sleep(2000);
        browser.Quit();
        browser.Dispose();
    }
}



















//Assert.That(driver.Url.Contains("elements"), Is.EqualTo(true));

//xpath //tagname[@attributeName = 'attributeValue'], tagname[attributeName = 'attributeValue']
//css  (//tagname[@attributeName = 'attributeValue'])[]

//07/03/2025
//i will do something else later
//1. I will identify locators the lazy way
//2. I will identify locators using an extension (Chropath etc)
//3. I will identify locators the professional way (Look up how to use different locators)
//4. Globalization

//08/03/2025
//Recap - Globalization, FindElement, FindElements
//5. Inheritance
//6. Page object model - Page structures
//7. Push to git and delete git
//8. End to end complete for unit test
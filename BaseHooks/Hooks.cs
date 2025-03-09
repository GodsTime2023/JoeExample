using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.BaseHooks;

public class Hooks
{
    public IWebDriver browser;

    [SetUp] //Open a browser
    public void Setup()
    {
        browser = InitializeDriver();
    }

    public IWebDriver StartBrowser()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--start-maximized");
        browser = new ChromeDriver(options);
        browser.Navigate().GoToUrl("https://demoqa.com");
        browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        return browser;
    }

    private IWebDriver InitializeDriver() => 
        browser == null ? StartBrowser() : browser;

    public IWebDriver InitDriver => InitializeDriver();


    [TearDown] //Closes your browser
    public void TearDown()
    {
        Thread.Sleep(2000);
        browser.Quit();
        browser.Dispose();
    }
}

//6.1 Waits for elements
//Push to git and delete git

//14/03/2025
//6.2 BDD introduction
//7. Push to git and delete git
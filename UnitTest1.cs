using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test;

public class Tests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demoqa.com");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        driver.FindElement(
            By.XPath("//div[@class='card mt-4 top-card'][.='Elements']")).Click();
        Assert.That(driver.Url.Contains("elements"), Is.EqualTo(true));

        //i will do something else later
    }

    [TearDown]
    public void ShutDownBrowser()
    {
        Thread.Sleep(5000);
        driver.Quit();
    }
}

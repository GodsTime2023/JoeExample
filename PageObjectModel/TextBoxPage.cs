using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test.PageObjectModel
{
    class TextBoxPage
    {
        public IWebDriver Driver;

        public TextBoxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebElement fullName => Driver.FindElement(By.Id("userName"));
        IWebElement email => Driver.FindElement(By.Id("userEmail"));
        IWebElement currentAddress => Driver.FindElement(By.Id("currentAddress"));
        IWebElement parmanentAddress => Driver.FindElement(By.Id("permanentAddress"));
        IWebElement submit => Driver.FindElement(By.Id("submit"));
        IWebElement output => Driver.FindElement(By.Id("output"));
        IReadOnlyCollection<IWebElement> outputValues =>
                        Driver.FindElements(By.XPath("//div[@id='output']//p"));


        public bool IsFullNameDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            var check = wait.Until(x => x.FindElement(By.Id("userName"))).Displayed;
            return check;
        }

        public void FillFormAndSubmit()
        {
            fullName.SendKeys("Joe");
            email.SendKeys("abc@test.com");
            currentAddress.SendKeys("this is my current address");
            parmanentAddress.SendKeys("this is my parmanent address");
            submit.Click();
        }

        public bool IsOutPutDisplayed()=> output.Displayed;

        public IReadOnlyCollection<IWebElement> IsTextMatching() => outputValues;
    }
}

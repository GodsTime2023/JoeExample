using OpenQA.Selenium;

namespace Test.PageObjectModel
{
    class HomePage
    {
        private IWebDriver browser; //object
        public HomePage(IWebDriver driver) //Constructor
        {
            this.browser = driver; 
        }


        //Property
        private IWebElement elements => 
            browser.FindElement(By.XPath("//div[@class='category-cards']/div[1]"));

        //method
        public void ClickElement() => elements.Click();
    }
}

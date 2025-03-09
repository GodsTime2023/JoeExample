using OpenQA.Selenium;

namespace Test.PageObjectModel
{
    class ElementsPage
    {
        private IWebDriver browser; //object
        public ElementsPage(IWebDriver driver) //Constructor
        {
            this.browser = driver;
        }


        //Property
        private IWebElement textBox =>
            browser.FindElement(By.XPath("//li[@id='item-0'][.='Text Box']"));

        //method
        public void ClickTextBox() => textBox.Click();
    }
}

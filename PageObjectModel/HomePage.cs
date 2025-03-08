using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

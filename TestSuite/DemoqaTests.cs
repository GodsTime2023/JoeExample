using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BaseHooks;

namespace Test.TestSuite
{
    class DemoqaTests : Hooks //Inheritance
    {
        [Test]
        public void ElementsTest()
        {
            //camel case = textBox, pascal case = TextBox
            var elements = browser.FindElement(By.XPath("//div[@class='category-cards']/div[1]"));
            elements.Click();

            var textBox = browser.FindElement(By.XPath("//div[@class='element-list collapse show']//li[@id='item-0']"));
            textBox.Click();

            var fullName = browser.FindElement(By.Id("userName"));
            fullName.SendKeys("Joe");

            var email = browser.FindElement(By.Id("userEmail"));
            email.SendKeys("abc@test.com");

            var currentAddress = browser.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys("this is my current address");

            var parmanentAddress = browser.FindElement(By.Id("permanentAddress"));
            parmanentAddress.SendKeys("this is my parmanent address");

            var submit = browser.FindElement(By.Id("submit"));
            submit.Click();

            Thread.Sleep(2000);

            var isOutPutDisplayed = browser.FindElement(By.Id("output")).Displayed;
            //Verification
            Assert.That(isOutPutDisplayed, Is.EqualTo(true));

            //Verify all the test is equal
            var outPutTexts = browser.FindElements(By.XPath("//div[@id='output']//p"));

            string name = outPutTexts[0].Text.Split(":")[1];
            //actual value
            Assert.That(outPutTexts[0].Text.Split(":")[1].Equals("Joe"), Is.True);
            Assert.That(outPutTexts[1].Text.Split(":")[1].Equals("abc@test.com"), Is.True);
            Assert.That(outPutTexts[2].Text.Split(":")[1].Equals("this is my current address"), Is.True);
            Assert.That(outPutTexts[3].Text.Split(":")[1].Equals("this is my parmanent address"), Is.True);
        }

        [Test]
        public void ElementsTestWithPOM()
        {

        }
    }
}
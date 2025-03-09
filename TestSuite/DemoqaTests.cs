using FluentAssertions;
using OpenQA.Selenium;
using Test.BaseHooks;
using Test.PageObjectModel;

namespace Test.TestSuite
{
    class DemoqaTests : Hooks //Inheritance
    {
        HomePage homePage;

        ElementsPage elementsPage;

        TextBoxPage textBoxPage;

        public DemoqaTests()
        {
            homePage = new HomePage(InitDriver);
            elementsPage = new ElementsPage(InitDriver);
            textBoxPage = new TextBoxPage(InitDriver);
        }

        [Test]
        public void ElementsTest()
        {
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

            //Verify all the text is equal
            var outPutTexts = browser.FindElements(By.XPath("//div[@id='output']//p"));
            string name = outPutTexts[0].Text.Split(":")[1];

            //Nunit assertion example
            Assert.That(outPutTexts[0].Text.Split(":")[1].Equals("Joe"), Is.True);
            Assert.That(outPutTexts[1].Text.Split(":")[1].Equals("abc@test.com"), Is.True);
            Assert.That(outPutTexts[2].Text.Split(":")[1].Equals("this is my current address"), Is.True);
            Assert.That(outPutTexts[3].Text.Split(":")[1].Equals("this is my parmanent address"), Is.True);

            //Fluent Assertion example
            outPutTexts[0].Text.Split(":")[1].Should().Be("Joe");
            outPutTexts[1].Text.Split(":")[1].Should().Be("abc@test.com");
            outPutTexts[2].Text.Split(":")[1].Should().Be("this is my current address");
            outPutTexts[3].Text.Split(":")[1].Should().Be("this is my parmanent address");
        }

        [Test]
        public void ElementsTestWithPOM()
        {
            HomePage homePage = new HomePage(browser);
            homePage.ClickElement();

            ElementsPage elementsPage = new ElementsPage(browser);
            elementsPage.ClickTextBox();

            TextBoxPage textBoxPage = new TextBoxPage(browser);
            textBoxPage.FillFormAndSubmit();

            textBoxPage.IsOutPutDisplayed().Should().BeTrue();
            textBoxPage.IsTextMatching().First().Text.Split(":")[1]
                .Should().Be("Joe");
            textBoxPage.IsTextMatching().ElementAt(1).Text.Split(":")[1]
                .Should().Be("abc@test.com");
            textBoxPage.IsTextMatching().ElementAt(2).Text.Split(":")[1]
                .Should().Be("this is my current address");
            textBoxPage.IsTextMatching().Last().Text.Split(":")[1]
                .Should().Be("this is my parmanent address");
        }

        [Test]
        public void ElementsTestWithPOMPart2()
        {
            homePage.ClickElement();
            elementsPage.ClickTextBox();

            if (textBoxPage.IsFullNameDisplayed().Equals(true))
            {
                textBoxPage.FillFormAndSubmit();
            }
            else
            {
                throw new Exception("Condition is not satisfied");
            }

            textBoxPage.IsOutPutDisplayed().Should().BeTrue();

            textBoxPage.IsTextMatching().First().Text.Split(":")[1]
                .Should().Be("Joe");
            textBoxPage.IsTextMatching().ElementAt(1).Text.Split(":")[1]
                .Should().Be("abc@test.com");
            textBoxPage.IsTextMatching().ElementAt(2).Text.Split(":")[1]
                .Should().Be("this is my current address");

            //Actions action = new Actions(browser);
            //action.ScrollToElement(textBoxPage.IsTextMatching().First())
            //    .Perform();

            //WebDriverWait, DefaultWait => Element
            textBoxPage.IsTextMatching().Last().Text.Split(":")[1]
                .Should().Be("this is my parmanent address");
        }
    }
}
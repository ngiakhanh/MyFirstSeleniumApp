using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MyFirstSeleniumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Users\NHK81HC\AppData\Local\Google\Chrome SxS\Application\chrome.exe"
            };
            using (var driver = new ChromeDriver(@"./", option))
            {
                driver.Navigate().GoToUrl("http://demo.guru99.com/V1/index.php");
                var createUser = driver.FindElementByXPath("//div[ol[li[a]]]//a").GetAttribute("href");
                driver.Navigate().GoToUrl(createUser);

                driver.FindElementByXPath("//input[@name='emailid']").SendKeys("admin@admin.com");
                driver.FindElementByXPath("//input[@name='btnLogin']").Click();

                var userId = driver.FindElementByXPath("//tr[contains(.,'User ID')]//td[2]").Text;
                var password = driver.FindElementByXPath("//tr[contains(.,'Password')]//td[2]").Text;
                driver.Navigate().GoToUrl("http://demo.guru99.com/V1/index.php");

                driver.FindElementByXPath("//input[contains(@onkeyup,'validateuserid')]").SendKeys(userId);
                driver.FindElementByXPath("//input[contains(@onkeyup,'validatepassword')]").SendKeys(password);
                driver.FindElementByXPath("//input[contains(@name,'Login')]").Click();

                driver.FindElementByXPath("//li[a[contains(text(),'Log out')]]").Click();
                IAlert alert = driver.SwitchTo().Alert();
                String goodBye = alert.Text;
                alert.Accept();
                driver.Close();

                Console.WriteLine(goodBye);
            }
        }
    }
}

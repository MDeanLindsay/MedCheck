using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        using (IWebDriver driver = new ChromeDriver("C:\\"))
        {
            driver.Navigate().GoToUrl("https://www.caremc.com/caremcwebmvc/account/login");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string parentWindowHandle = driver.CurrentWindowHandle;
            
            // Still not necessarily sure why I "have" to reassign links twice to get this to run.

            var links = driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/a"));

            for (int i = 0; i < links.Count; i++)   {
                links = driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/a"));
                links[i].Click();
                if (driver.CurrentWindowHandle == driver.WindowHandles.Last()) {
                    driver.Navigate().Back();
                }
                else {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Close();
                    driver.SwitchTo().Window(parentWindowHandle);
                }
            }
            
            var links2 = driver.FindElements(By.XPath("/html/body/div[2]/header/div[2]/div/ul/li/a"));

            for (int i = 0; i < links2.Count; i++)  {
                links2 = driver.FindElements(By.XPath("/html/body/div[2]/header/div[2]/div/ul/li/a"));
                links2[i].Click();
                driver.Navigate().Back();
            }

            // Thrown off iterating by button/input.
            // Is there an easier to go about looping through without ids, similar tags, etc?
           
            driver.FindElement(By.XPath("//button[@class=\"SubmitBlue\"]")).Click();
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//input[@class=\"SubmitOrange\"]")).Click();
            driver.Navigate().Back();
           
            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).Click();
            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).SendKeys("test");

            Console.WriteLine("It worked!!!");
            driver.Quit();
        }    
    }
}
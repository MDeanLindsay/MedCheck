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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            /* 
            //TO DO: Handle new window switching from PPO.
            string BaseWindow = driver.CurrentWindowHandle;
            foreach (string handle in driver.WindowHandles) {
                if (handle != BaseWindow)   {
                    driver.SwitchTo().Window(driver.WindowHandles.First());
                }
            }
            */
           
            var links = driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/a"));
            
            for (int i = 0; i < links.Count; i++)   {
                links = driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/a"));
                driver.Navigate().GoToUrl(links[i].GetAttribute("href"));
                driver.Navigate().Back();
            }


            var links2 = driver.FindElements(By.XPath("/html/body/div[2]/header/div[2]/div/ul/li/a"));

            for (int i = 0; i < links2.Count; i++)  {
                links2 = driver.FindElements(By.XPath("/html/body/div[2]/header/div[2]/div/ul/li/a"));
                driver.Navigate().GoToUrl(links2[i].GetAttribute("href"));
                driver.Navigate().Back();
            }
            
            /* 
            // TODO: Figure out better way to deal with buttons.
            var links3 = driver.FindElements(By.XPath("//button[contains(@class,'Submit')"));
            */

            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).Click();
            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).SendKeys("test");

            Console.WriteLine("'It looks relatively easy and straight forward,' he said. Several hours online, he spent.");
            driver.Quit();
        }    
    }
}
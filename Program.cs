﻿using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        using (IWebDriver driver = new ChromeDriver("."))
        {
            driver.Navigate().GoToUrl("https://www.caremc.com/caremcwebmvc/account/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            string parentWindowHandle = driver.CurrentWindowHandle;
            
            for (int i = 0; i < 3; i++)   {
                driver.FindElements(By.XPath("/html/body/div[2]/header/div[1]/div/div/a"))[i].Click();
                if (driver.CurrentWindowHandle == driver.WindowHandles.Last()) {
                    driver.Navigate().Back();
                }
                else {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Close();
                    driver.SwitchTo().Window(parentWindowHandle);
                }
            }
            
            for (int i = 0; i < 3; i++)  {
                driver.FindElements(By.XPath("/html/body/div[2]/header/div[2]/div/ul/li/a"))[i].Click();
                driver.Navigate().Back();
            }
           
            driver.FindElement(By.XPath("//button[@class=\"SubmitBlue\"]")).Click();
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//input[@class=\"SubmitOrange\"]")).Click();
            driver.Navigate().Back();
           
            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).Click();
            driver.FindElement(By.XPath("//input[@id=\"UserName\"]")).SendKeys("test");

            Console.WriteLine("It compiled?");
            driver.Quit();
        }    
    }
}

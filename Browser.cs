using OpenQA.Selenium; 
using OpenQA.Selenium.Firefox; 
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.IE; 
using OpenQA.Selenium.Support.UI; 
using System;

namespace Scenarios
{
    public static class Browser
    {
        public static IWebDriver webDriver;
        public static void LaunchChrome()
        {
            //used chrome version 56.0.2624          
            webDriver = new ChromeDriver();
            //webDriver = new InternetExplorerDriver();
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }


        public static void CloseBrowser()
        {
            webDriver.Quit();
        }

    }

}
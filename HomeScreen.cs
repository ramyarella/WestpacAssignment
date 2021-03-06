﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Scenarios
{ 
     public class HomeScreen
     { 
         WebDriverWait wait; 
          
         public void NavigateToKiwiCalculator()
         { 
            
             Browser.webDriver.FindElement(By.XPath("//article[@id='tile-pane-Links-2-ps']/div/ul/li[5]/a/span")).Click();
            
            wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10)); 
             var articleElement = wait.Until(d =>
             {
                return Browser.webDriver.FindElement(By.Id("content-ps"));
             });
             var btnKiwicalculator = articleElement.FindElements(By.ClassName("btn"))[1];

             btnKiwicalculator.Click();
         } 
         public void Goto(string url)
         { 
             Browser.LaunchChrome(); 
             Browser.Goto(url);             
         } 
 
 
 
 
 

     } 
} 


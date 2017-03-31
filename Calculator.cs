using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Scenarios
 {     
     public class Calculator
     { 
         WebDriverWait wait; 
 /// Accessing information icon for the Current Age of the user. 
         
         public void ClickingInformationIcon()
         { 
             wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10)); 
             var btnCurrentAge = wait.Until(d =>
             { 
                return Browser.webDriver.FindElement(By.XPath("//div//label[contains(text(),'Current age')]/ancestor::div[@class='field-row']//i"
)); 
             }); 
             btnCurrentAge.Click(); 
         } 
         
///verify if the Retirement Projects are enabled or not.          
         public bool ButtonEnabled()
         { 
             var btn = Browser.webDriver.FindElement(By.CssSelector("button[ng-click='ctrl.showResultsPanel()']")); 
             if (btn.Enabled) 
            { 
             return true; 
             } 
             return false; 
         } 
 
 /// To fill in risk profile details for a particular user. 
            public void FillRiskProfile(string prfileOption)
         { 
var divRiskProfile = Browser.webDriver.FindElement(By.ClassName("wpnib-field-risk-profile")); 
             var profileOption = divRiskProfile.FindElement(By.CssSelector("input[ng-click='select()'][value='" + prfileOption + "']")); 
             var executor = (IJavaScriptExecutor)Browser.webDriver; 
             executor.ExecuteScript("arguments[0].click();", profileOption); 
         } 
 

 /// Voluntary contribution and the frequency of it. 
 
        public void VolContribution(string volContribution, string frequency)
         { 
var divVoluntaryContributions = Browser.webDriver.FindElement(By.ClassName("wpnib-field-voluntary-contributions")); 
             var txtVoluntaryContributions = divVoluntaryContributions.FindElement(By.CssSelector("input[ng-model='displayModel']")); 
             txtVoluntaryContributions.Clear(); 
             txtVoluntaryContributions.SendKeys(volContribution); 
             txtVoluntaryContributions.SendKeys(Keys.Enter); 
             var freSelect = divVoluntaryContributions.FindElement(By.CssSelector("div[ng-click='toggle()']")); 
            var executor = (IJavaScriptExecutor)Browser.webDriver; 
             executor.ExecuteScript("arguments[0].click();", freSelect); 
             var frequencySelect = divVoluntaryContributions.FindElement(By.CssSelector("li[ng-click='select()'][value='" + frequency + "'")); 
             executor.ExecuteScript("arguments[0].click();", frequencySelect); 
         } 
 
 
 
/// Savings expected post retirement. 
         
         public void SavingsOnRetirement(string savingsPostRetd)
         { 
             var divSavingsPostRetd = Browser.webDriver.FindElement(By.ClassName("wpnib-field-savings-goal")); 
             var txtSavingsPostRetd = divSavingsPostRetd.FindElement(By.CssSelector("input[ng-model='displayModel']")); 
             txtSavingsPostRetd.Clear(); 
             txtSavingsPostRetd.SendKeys(savingsPostRetd); 
             txtSavingsPostRetd.SendKeys(Keys.Enter); 
         } 

 

 /// Current Balance for the current user. 
          
         public void EnterCurrentBalance(string balance)
         { 
            var divCurrentBalance = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwi-saver-balance")); 
             var txtCurrentBalance = divCurrentBalance.FindElement(By.CssSelector("input[ng-model='displayModel']")); 
             txtCurrentBalance.Clear(); 
             txtCurrentBalance.SendKeys(balance); 
             txtCurrentBalance.SendKeys(Keys.Enter); 
         } 
 
 

/// Prescribed investor rate. 
  
         public void PrescribedInvestorRate(string investorRate)
         { 
             var divPrescribedIntRate = Browser.webDriver.FindElement(By.ClassName("wpnib-field-pir-rate")); 
             var pirSelect = divPrescribedIntRate.FindElement(By.CssSelector("div[ng-click='toggle()']")); 
             var executor = (IJavaScriptExecutor)Browser.webDriver; 
             executor.ExecuteScript("arguments[0].click();", pirSelect); 
             var investorrateselect = divPrescribedIntRate.FindElement(By.CssSelector("li[ng-click='select()'][value='" + investorRate + "'")); 
             executor.ExecuteScript("arguments[0].click();", investorrateselect); 
         } 

 /// Methods to populate the Kiwi save contribution. 

         public void SetKiwiSaverContribution(string kiwiPercentage)
         { 
             var divKiwiSavePercentage = Browser.webDriver.FindElement(By.ClassName("wpnib-field-kiwisaver-member-contribution")); 
             var inputOption = divKiwiSavePercentage.FindElement(By.CssSelector("input[ng-click='select()'][value='" + kiwiPercentage + "']")); 
             inputOption.Click(); 
         } 
 
/// Fetch information for the div of the Current Age. 
  
         public string GetHelpInformationText()
         { 
             wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10)); 
             var embeddedCalculator = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.Id("calculator-embed")); 
 

             }); 
             var frameSource = wait.Until(d =>
             { 
                 return embeddedCalculator.FindElement(By.TagName("iframe")); 
 

             }); 
             var divCurrentAge = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.ClassName("wpnib-field-current-age")); 
             }); 
             var divHelpInformation = divCurrentAge.FindElement(By.ClassName("message-row")); 
             var textelement = divHelpInformation.FindElement(By.TagName("p")); 
             return textelement.Text; 
         } 
 
         /// Method to store in details of the Age 
   
         public void EnterAgeDetails(string age)
         { 
             wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10)); 
             var embeddedCalculator = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.ClassName("calculator-embed")); 
 

             }); 
             var frameSource = wait.Until(d =>
             { 
                 return embeddedCalculator.FindElement(By.TagName("iframe")); 
 

            }); 
 

             Browser.webDriver.SwitchTo().Frame(frameSource); 
             var divCurrentAge = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.ClassName("wpnib-field-current-age")); 
             }); 
             var ageText = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.CssSelector("input[ng-model='displayModel']")); 
             }); 
 
 
 
             ageText.Clear(); 
             ageText.SendKeys(age); 
             ageText.SendKeys(Keys.Enter);
    } 
 
/// Method to set the employment status. 
  
         public void SelectEmploymentStatus(string employeeStatus)
         { 
             wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(10)); 
             var selectControl = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.CssSelector("div[ng-click='toggle()']")); 
             }); 
             Browser.webDriver.SwitchTo().ActiveElement(); 
             var executor = (IJavaScriptExecutor)Browser.webDriver;
executor.ExecuteScript("arguments[0].click();", selectControl); 
             var liEmployed = wait.Until(d =>
             { 
                 return Browser.webDriver.FindElement(By.CssSelector("li[ng-click='select()'][value='" + employeeStatus + "'")); 
             }); 
             executor.ExecuteScript("arguments[0].click();", liEmployed); 
         } 

/// To set annual income for the user.
 
         public void SetAnnualIncome(string income)
         { 
             var divIncomeControl = Browser.webDriver.FindElement(By.ClassName("wpnib-field-annual-income")); 
             var incomeControl = divIncomeControl.FindElement(By.CssSelector("input[ng-model='displayModel']")); 
             incomeControl.Clear(); 
             incomeControl.SendKeys(income); 
             incomeControl.SendKeys(Keys.Enter); 
         } 
    } 
 } 



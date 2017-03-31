using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Scenarios;
using System.Xml;
using System.Configuration;

namespace Scenarios
{
    [TestClass]
    public class KiwiCalculator
    {
        public static string url;
        public static string xmlPath;

        [TestInitialize]
        public void TestInitialize()
        {
            url = ConfigurationManager.AppSettings["portalurl"].ToString();
            xmlPath = ConfigurationManager.AppSettings["testdataxml"].ToString();

        }
        //Clicking on the information icon of th user
        [TestMethod]
     public void Validate_information_Age()
     { 
     NewScreen.HomeScreen.Goto(url); 
     NewScreen.HomeScreen.NavigateToKiwiCalculator(); 
     NewScreen.Calculator.ClickingInformationIcon(); 
     Assert.AreEqual("This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.", NewScreen.Calculator.GetHelpInformationText()); 
     }
       //Employed User is able to calculate the projected balances at retirement
    [TestMethod]
    public void Validate_RetirementProjections_Employed()
        { 
             NewScreen.HomeScreen.Goto(url); 
             NewScreen.HomeScreen.NavigateToKiwiCalculator(); 
             NewScreen.Calculator.EnterAgeDetails(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/age")); 
             NewScreen.Calculator.SelectEmploymentStatus(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/employeestatus")); 
             NewScreen.Calculator.SetAnnualIncome(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/annualincome")); 
             NewScreen.Calculator.SetKiwiSaverContribution(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/kiwisavercontribution")); 
             NewScreen.Calculator.PrescribedInvestorRate(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/PrescribedInvestorRate")); 
             NewScreen.Calculator.FillRiskProfile(DocuPath.GetDataFromXML(xmlPath, "Testdata/employed/RiskProfile")); 
             Assert.IsTrue(NewScreen.Calculator.ButtonEnabled()); 
         } 

    //SelfEmployed User is able to calculate the projected balances at retirement
         [TestMethod] 
         public void Validate_RetirementProjections_SelfEmployed()
         { 
             NewScreen.HomeScreen.Goto(url); 
             NewScreen.HomeScreen.NavigateToKiwiCalculator(); 
             NewScreen.Calculator.EnterAgeDetails(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/age")); 
             NewScreen.Calculator.SelectEmploymentStatus(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/employeestatus")); 
             NewScreen.Calculator.PrescribedInvestorRate(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/PrescribedInvestorRate")); 
             NewScreen.Calculator.EnterCurrentBalance(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/currentBalance")); 
             NewScreen.Calculator.VolContribution(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/voluntaryfund"), DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/frequency")); 
             NewScreen.Calculator.FillRiskProfile(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/RiskProfile")); 
             NewScreen.Calculator.SavingsOnRetirement(DocuPath.GetDataFromXML(xmlPath, "Testdata/selfemployed/SavingsPostRetd")); 
             Assert.IsTrue(NewScreen.Calculator.ButtonEnabled()); 
         }
        //unemployed user is able to calculate the projected balancs at retirement
[TestMethod]
         public void Validate_RetirementProjects_NotEmployed()
         { 
             NewScreen.HomeScreen.Goto(url); 
             NewScreen.HomeScreen.NavigateToKiwiCalculator(); 
             NewScreen.Calculator.EnterAgeDetails(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/age")); 
             NewScreen.Calculator.SelectEmploymentStatus(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/employeestatus")); 
             NewScreen.Calculator.PrescribedInvestorRate(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/PrescribedInvestorRate")); 
             NewScreen.Calculator.EnterCurrentBalance(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/currentBalance")); 
             NewScreen.Calculator.VolContribution(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/voluntaryfund"), DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/frequency")); 
             NewScreen.Calculator.FillRiskProfile(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/RiskProfile")); 
             NewScreen.Calculator.SavingsOnRetirement(DocuPath.GetDataFromXML(xmlPath, "Testdata/notemployed/SavingsPostRetd")); 
             Assert.IsTrue(NewScreen.Calculator.ButtonEnabled()); 
         } 


[TestCleanup] 
        public void CloseBrowser()
      { 
         Browser.CloseBrowser(); 
         }

}
}

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Test_Procedure
{
    //[TestClass]
    //public class UnitTest1
    //{
    //    FirefoxDriver firefox;

    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //        firefox = new FirefoxDriver();
    //        firefox.Navigate().GoToUrl("https://careers.veeam.com/");
    //        firefox.Manage().Window.Maximize();
    //        firefox.FindElement(By.XPath("//div[2]/dd/div/span")).Click();
    //        firefox.FindElement(By.XPath("//div/div[2]/span[17]")).Click();
    //        firefox.FindElement(By.XPath("//div/div[5]/div/span")).Click();
    //        firefox.FindElement(By.XPath("//fieldset/label[5]")).Click();
    //        //firefox.FindElement(By.XPath("//div[2]/div/div/a")).Click(); -закрытие окна выбора языка
    //    firefox.FindElement(By.XPath("//section[3]/div/div[2]/div/a")).Click();
    //        Thread.Sleep(6000);
    //        int i = firefox.FindElements(By.XPath("//div/a/h4")).Count;
    //        Assert.AreEqual(28, i);
    //    }
    //    [TestCleanup]
    //    public void TearDown()
    //    {
    //        firefox.Quit();
    //    }
    //}
    [TestClass]
    public class UnitTest1
    {
        FirefoxDriver firefox;   
        public void SearchElements(string[] paths, string firstLink, string pathElements, int rightAmount)
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl(firstLink);
            firefox.Manage().Window.Maximize();
            foreach (string path in paths)
            {
                firefox.FindElement(By.XPath(path)).Click();
            }
            Thread.Sleep(6000);
            int testAmount = firefox.FindElements(By.XPath(pathElements)).Count;
            Assert.AreEqual(rightAmount, testAmount);
        }
        [TestMethod]
        public void StartSearch()
        {
            string[] paths = { "//div[2]/dd/div/span", "//div/div[2]/span[17]", "//div/div[5]/div/span", "//fieldset/label[5]", "//div[2]/div/div/a", "//section[3]/div/div[2]/div/a"};
            var firstLink = "https://careers.veeam.com/";
            var pathElements = "//div/a/h4";
            var rightAmount = 28;
            SearchElements(paths, firstLink, pathElements, rightAmount);
        }
        [TestCleanup]
        public void TearDown()
        {
            firefox.Quit();
        }
    }
}

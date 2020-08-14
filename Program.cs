using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace TurnUp_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //init driver
            IWebDriver driver = new ChromeDriver();

            //Open the turnup portal
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Find username textbox
            IWebElement username = driver.FindElement(By.Id("UserName"));
            Thread.Sleep(2000);

            //Enter username
            username.SendKeys("hari");

            //Find password textbox
            IWebElement password = driver.FindElement(By.Id("Password"));
            Thread.Sleep(2000);

            //Enter password
            password.SendKeys("123123");

            //Find Login button
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));

            //Click on Login Button
            LoginButton.Click();
            Thread.Sleep(2000);

            //Find Logout button
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            Thread.Sleep(2000);

            //Cheak the login name is correct or not

            if (hellohari.Text == "Hello hari!")
            {
                    Console.WriteLine("Logged in succesfully, test passed");
            }
            else
            {
                    Console.WriteLine("Logged in not succefully, test failed");
            }

            //Navigate time and Material Page
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            Thread.Sleep(2000);

            //Click new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            Thread.Sleep(2000);

            //select type  code form the drodown list
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();


            //input code value
            driver.FindElement(By.Id("Code")).SendKeys("August2020");

            //input a description
            driver.FindElement(By.Id("Description")).SendKeys("this is automation testing");

            //input price per unit

            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.Id("Price")).SendKeys("550");

            //click save button
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(1000);

            //goto last page
            driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[4]//a[4]//span")).Click();
            Thread.Sleep(1000);

            //cheak if the created time material is present

            IWebElement actualcode = driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualcode.Text == "August2020")
            {
                Console.WriteLine("Time record create succefully, test passed");
            }
            else
            {
                Console.WriteLine("Time record not create succefully, test failed");
            }


            Console.WriteLine("Check if the user is able to edit an existing time/ material record successfully with valid details");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[5]/a[1]")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("Code")).Click();
            //code.Click();
            driver.FindElement(By.Id("Code")).Clear();
            //code.Clear();
            driver.FindElement(By.Id("Code")).SendKeys("Hello world");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(3000);

            Console.WriteLine("Edit Successfully into the record");


            //Delete the Record
            Console.WriteLine("Cheak the user is Delete the record or not");
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[9]/td[5]/a[2]")).Click();
            Console.WriteLine("Record Deleted Succesfully");
        }
    }
}

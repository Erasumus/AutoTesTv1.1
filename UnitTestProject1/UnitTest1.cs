using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class MainTest1 : TestBase
    {

        [Test]
        public void TheUntitledTest()
        {
            Site();
            Account userdata = new Account("erasumus@mail.ru", "bn1bn1bb2");
            Login(userdata);
            Forum();
            AboutMe();
            Email();
            Save();
            MyOffice();
            Exit();
        }
    }


}
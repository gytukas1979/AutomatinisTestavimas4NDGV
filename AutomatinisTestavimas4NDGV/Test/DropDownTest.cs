using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatinisTestavimas4NDGV.Page;

namespace AutomatinisTestavimas4NDGV.Test
{
    public class DropDownTest
    {
        private static DropDownPage _page;
        public List<string> states = new List<string>() { "Ohio", "New York" };
        public string tekstas = "labas rytas";
        
        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Order(1)]
        [Test]
        public void TestDropDown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        [Order(2)]
        [Test]
        public void TestMultiDropDown()
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();
        }

        [Order(3)]
        [TestCase("Ohio", "Florida")]
        public void TestTwoStatesSelectedReturnFirstSelected(string firstState, string secondState)
        {
            _page.SelectFromMultipleDropdownByValueClickFirstSelected(_page.ListOfTwoStates(firstState, secondState));
            _page.CheckFirstValue(_page.ListOfTwoStates(firstState, secondState));
        }

        [Order(4)]
        [TestCase("Washington", "Texas")]
        public void TestTwoStatesSelectedReturnGetAllSelected(string firstState, string secondState)
        {
            _page.SelectFromMultipleDropdownByValueClickGetAllSelected(_page.ListOfTwoStates(firstState, secondState));
            _page.CheckAllSelectedValues(_page.ListOfTwoStates(firstState, secondState));
        }

        [Order(5)]
        [TestCase("Texas", "Washington", "Ohio")]
        public void TestThreeStatesSelectedReturnFirstSelected(string firstState, string secondState, string thirdState)
        {
            _page.SelectFromMultipleDropdownByValueClickFirstSelected(_page.ListOfThreeStates(firstState, secondState, thirdState));
            _page.CheckFirstValue(_page.ListOfThreeStates(firstState, secondState, thirdState));
        }

        [Order(6)]
        [TestCase("Washington", "New York", "Florida", "Ohio")]
        public void TestFourStatesSelectedReturnGetAllSelected(string firstState, string secondState, string thirdState, string fourthState)
        {
            _page.SelectFromMultipleDropdownByValueClickGetAllSelected(_page.ListOfFourStates(firstState, secondState, thirdState, fourthState));
            _page.CheckAllSelectedValues(_page.ListOfFourStates(firstState, secondState, thirdState, fourthState));
        }

        //private static readonly object[] _2states =
        //{
        //    new object[] {new List<string> {"California", "Florida"}},   
        //};

        //[Order(7)]
        //[Test, TestCaseSource(nameof(_2states))]
        //public void TestTwoStatesFirstSelected(List<string> list)
        //{
        //    _page.SelectFromMultipleDropdownByValueClickFirstSelected(list);
        //    _page.CheckFirstValue(list);
        //}

        //private static readonly object[] _3states =
        //{
        //    new object[] {new List<string> {"Ohio", "Florida", "California"}},
        //};

        //[Order(8)]
        //[Test, TestCaseSource(nameof(_3states))]
        //public void TestThreeStatesFirstSelected(List<string> list)
        //{
        //    _page.SelectFromMultipleDropdownByValueClickFirstSelected(list);
        //    _page.CheckFirstValue(list);
        //}

        //private static readonly object[] _2statesForMultipleSelect =
        //{
        //    new object[] {new List<string> {"Florida", "California"}},
        //};

        //[Order(9)]
        //[Test, TestCaseSource(nameof(_2statesForMultipleSelect))]
        //public void TestTwoStatesGetAllSelected(List<string> list)
        //{
        //    _page.SelectFromMultipleDropdownByValueClickGetAllSelected(list);
        //    _page.CheckAllSelectedValues(list);
        //}

        //private static readonly object[] _4statesForMultipleSelect =
        //{
        //    new object[] {new List<string> {"Florida", "California", "Texas", "Ohio"}},
        //};

        //[Order(10)]
        //[Test, TestCaseSource(nameof(_4statesForMultipleSelect))]
        //public void TestFourStatesGetAllSelected(List<string> list)
        //{
        //    _page.SelectFromMultipleDropdownByValueClickGetAllSelected(list);
        //    _page.CheckAllSelectedValues(list);
        //}
    }
}
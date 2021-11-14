using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas4NDGV.Page
{
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private const string FirstSelectedResultText = "First selected option is : ";
        private const string OptionsSelectedResultText = "Options selected are : ";
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement ResultOfSelectedClick => Driver.FindElement(By.ClassName("getall-selected"));
        
        public DropDownPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropDownPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropDownPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropDownPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropDownPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }
       
        public List<string> ListOfTwoStates(string firstState, string secondState)
        {
            List<string> listOfStates = new List<string>();
            listOfStates.Add(firstState);
            listOfStates.Add(secondState);
            return listOfStates;
        }

        public List<string> ListOfThreeStates(string firstState, string secondState, string thirdState)
        {
            List<string> listOfStates = new List<string>();
            listOfStates.Add(firstState);
            listOfStates.Add(secondState);
            listOfStates.Add(thirdState);
            return listOfStates;
        }

        public List<string> ListOfFourStates(string firstState, string secondState, string thirdState, string fourthState)
        {
            List<string> listOfStates = new List<string>();
            listOfStates.Add(firstState);
            listOfStates.Add(secondState);
            listOfStates.Add(thirdState);
            listOfStates.Add(fourthState);
            return listOfStates;
        }

        public DropDownPage SelectFromMultipleDropdownByValueClickFirstSelected(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            //action.Build().Perform();
            action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public DropDownPage SelectFromMultipleDropdownByValueClickGetAllSelected(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            //action.Build().Perform();
            action.Click(GetAllSelectedButton);
            action.Build().Perform();
            return this;
        }

        private String ReturnStringOfList(List<string> listOfStates)
        {
            string expectedResult = string.Join(",", listOfStates.ToArray());
            return expectedResult;
        }

        public DropDownPage CheckFirstValue(List<string> listOfStates)
        {
            //Console.WriteLine("Rezultatas turi buti: " + ResultOfSelectedClick.Text + " --- o turi buti " + listOfStates[0]);
            Assert.IsTrue(ResultOfSelectedClick.Text.Equals(FirstSelectedResultText + listOfStates[0]), $"Result is wrong, not {listOfStates[0]}");
            return this;
        }
        public DropDownPage CheckAllSelectedValues(List<string> listOfStates)
        {
            //Console.WriteLine("Rezultatas turi buti: " + ResultOfSelectedClick.Text + " --- o turi buti " + ReturnStringOfList(listOfStates));
            Assert.IsTrue(ResultOfSelectedClick.Text.Contains(ReturnStringOfList(listOfStates)), "The result is incorrect");
            Assert.IsTrue(ResultOfSelectedClick.Text.Equals(OptionsSelectedResultText + ReturnStringOfList(listOfStates)), $"Result is wrong, not {ReturnStringOfList(listOfStates)}");
            return this;
        }
    }
}
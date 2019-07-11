using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace seleniumTest
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var browser = new ChromeDriver())
			{
				browser.Manage().Window.Maximize();
				browser.Navigate().GoToUrl("https://pegast.ru/agency/pegasys/flights");

				int delay = 1000;
				FillSelectElement(browser, "departureCity", "Москва");
				Thread.Sleep(delay * 3);
				FillSelectElement(browser, "departureAirport", "Домодедово (DME)");
				Thread.Sleep(delay * 2);
				FillSelectElement(browser, "destinationCountry", "Испания");
				Thread.Sleep(delay * 3);
				FillSelectElement(browser, "destinationCity", "Барселона");

				FillDateElement(browser, "departureDateFrom", "22.07.2019"); //нужна проверка доступных дат из календаря
				FillDateElement(browser, "departureDateTo", "22.08.2019");
				FillDateElement(browser, "returnDateFrom", "22.08.2019");
				FillDateElement(browser, "returnDateTo", "22.09.2019");


				Thread.Sleep(delay * 3);
				IWebElement mainButton = browser.FindElementByClassName("main-button");
				mainButton.Click();
				Thread.Sleep(100000);
				//IWebElement 
				//browser.FindElementByXPath()
			}

		}


		static void FillDateElement(ChromeDriver browser, string elementName, string value)
		{
			IWebElement dateElement = browser.FindElementByName(elementName);
			if (String.IsNullOrEmpty(dateElement.Text))
			{
				dateElement.Clear();
			}
			dateElement.SendKeys(value + Keys.Enter + Keys.Escape);
		}
		static void FillSelectElement(ChromeDriver browser, string elementName, string value)
		{
			var selectElement = new SelectElement(browser.FindElementByName(elementName));
			selectElement.SelectByText(value);
		}
	}
}

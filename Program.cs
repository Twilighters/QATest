using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Task2_QATest
{
    class Program
    {
        static void Main(string[] args)
        {
//Инициализируем драйвер для управления браузером, 
//переходим по ссылке на wiki выполняя 1 пункт задания
//Находим элемент поиска, отправляем значение quality assurance и выполняем 2 пункт задания
//получаем значение того что было введено пользователем
//находим кнопку поиска 
//делаем по ней клик выполняя 3 пункт задания

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ru.wikipedia.org");
            driver.FindElement(By.Name("search")).SendKeys("quality assurance");
            string searchText = driver.FindElement(By.XPath("(//input[@name='search'])[1]")).GetAttribute("value");
            IWebElement searchButton = driver.FindElement(By.Id("searchButton"));
            searchButton.Click();

//условия на прохождение тестов и выполнения 4 и 6 пункты
//проверяем значение searchText на пустое поле
            if (searchText == "")
            {
                Console.WriteLine("Поле ввода для поиска пустое.");
                searchText = "false";
                bool boolsearchText = Convert.ToBoolean(searchText);
                Assert.IsTrue(boolsearchText, "Поле ввода для поиска пустое.");
            }
//проверка на введение не того значения, которое указано в задании
            else if (searchText != "quality assurance")
            {
                IWebElement actualPageResultList = driver.FindElement(By.XPath("//*[contains(@class,'mw-search-nonefound')]"));
                string actualResultList = actualPageResultList.Text;
                Console.WriteLine("Соответствий запросу не найдено.");
                actualResultList = "false";
                bool boolactualResultList = Convert.ToBoolean(actualResultList);
                Assert.IsTrue(boolactualResultList, "Соответствий запросу не найдено.");
            }
            else 
            {
//выполняем 5 пункт задания
//Проверка на соотвествие ввода того значения, которое хранится в переменной resultTitle указанное в задании.
                driver.FindElement(By.LinkText("Обеспечение качества")).Click();
                IWebElement pageTitle = driver.FindElement(By.Id("firstHeading"));
                string resultTitle = "Обеспечение качества";
                string actualTitle = pageTitle.Text;
                Assert.AreEqual(resultTitle, actualTitle, "Поле поиска не соответствует заданию 'Обеспечение качества'");
            }
        }
    } 
}

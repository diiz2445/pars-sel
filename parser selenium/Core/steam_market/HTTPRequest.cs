using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V138.Network;
using System;
using System.Collections.Generic;

namespace parser_selenium.Core.steam_market
{
    internal class HTTPRequest : IDisposable
    {
        private readonly IWebDriver driver;

        public HTTPRequest()
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-gpu", "--no-sandbox",
                "--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36");
            driver = new ChromeDriver(options);
        }

        public string GetRequestUrl(string url, string urlPattern)
        {
            try
            {
                // JavaScript для перехвата запросов
                string script = @"
                    window.xhrUrls = [];
                    const originalOpen = XMLHttpRequest.prototype.open;
                    XMLHttpRequest.prototype.open = function(method, url) {
                        window.xhrUrls.push(url.toString());
                        originalOpen.apply(this, arguments);
                    };
                    const originalFetch = window.fetch;
                    window.fetch = function(input, init) {
                        window.xhrUrls.push(input.toString());
                        return originalFetch.apply(this, arguments);
                    };
                    return true;
                ";

                // Переход на страницу и ожидание загрузки
                driver.Navigate().GoToUrl(url);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                // Выполнение скрипта перехвата
                ((IJavaScriptExecutor)driver).ExecuteScript(script);

                // Прокрутка страницы
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                // Попытка клика по элементу активности
                var xpath = "//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'activity') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'graph') or contains(@class, 'market_tab_well_tab') or contains(@id, 'market_activity')]";
                var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(d => d.FindElement(By.XPath(xpath)));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

                // Ожидание перехвата URL
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return window.xhrUrls && window.xhrUrls.length > 0;") is true);

                // Получение и обработка URL
                var urls = ((IJavaScriptExecutor)driver).ExecuteScript("return window.xhrUrls;") as IList<object>;
                if (urls != null)
                {
                    foreach (var requestUrl in urls)
                    {
                        string urlString = requestUrl?.ToString();
                        if (!string.IsNullOrEmpty(urlString) && urlString.Contains(urlPattern, StringComparison.OrdinalIgnoreCase))
                        {
                            return urlString;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
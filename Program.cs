using Microsoft.Playwright;
using System.Collections.Concurrent;
using System.Net;

namespace playwrightTest
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            _ = testAsync();
            Console.ReadKey();
        }
        public static async Task testAsync() {
            try
            {
                var playwright = await Playwright.CreateAsync();
                BrowserTypeLaunchPersistentContextOptions options = new BrowserTypeLaunchPersistentContextOptions();
                options.ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
                options.Headless = false;
                var browser = await playwright.Chromium.LaunchPersistentContextAsync("D:\\opt\\1", options);
                 var page = await browser.NewPageAsync();
                await page.AddInitScriptAsync("setInterval(function() {window.location.reload(true);}, 1000); ");
  
                _= page.GotoAsync(Directory.GetCurrentDirectory()+"\\test.js");
            }
            catch (Exception ee) {
                Console.WriteLine(ee);
            }
             
        }
    }
}

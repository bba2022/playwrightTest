using Microsoft.Playwright;
using System.Collections.Concurrent;
using System.Net;

namespace playwrightTest
{
    internal class Program
    {
        public static ConcurrentDictionary<string, WebsiteUser> websiteUsers = new ConcurrentDictionary<string, WebsiteUser>();
        static void Main(string[] args)
        {
            _ = testAsync();
            Console.ReadKey();
        }
        public static async Task testAsync() {
            try
            {
                websiteUsers["1"] = new WebsiteUser();
                var playwright = await Playwright.CreateAsync();
                BrowserTypeLaunchPersistentContextOptions options = new BrowserTypeLaunchPersistentContextOptions();
                options.ExecutablePath = "C:\\Users\\Administrator\\AppData\\Local\\Google\\Chrome\\Application\\chrome.exe";
                options.Headless = false;
                var browser = await playwright.Chromium.LaunchPersistentContextAsync("D:\\opt\\1", options);
                await new PlaywrightFilter(websiteUsers["1"]).filterAsync(browser);
                 var page = await browser.NewPageAsync();
                await page.AddInitScriptAsync("setInterval(function() {window.location.reload(true);}, 1000); ");
                await page.GotoAsync("D:\\opt\\mobilewebdriver.js");
            }
            catch (Exception ee) {
                Console.WriteLine(ee);
            }
             
        }
    }
}

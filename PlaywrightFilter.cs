using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace playwrightTest
{
    public class PlaywrightFilter
    {
        WebsiteUser websiteUser = null;

        public PlaywrightFilter(WebsiteUser websiteUser)
        {
            this.websiteUser = websiteUser;
        }
        public async Task filterAsync(IBrowserContext context) { 
        
        
        context.Page += async (sender, e) =>
        {
            // 处理新页面创建逻辑
            try
            {
                

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        };
        context.Close += async (sender, e) =>
        {
        };
        context.Request += async (_, request) =>
        {
            string url = request.Url;
            Uri uri = new Uri(url);
            
            try
            {

                Console.WriteLine(url);
               
            }
            catch (Exception ee)
            {

            }
        };
        context.Response += async (_, response) =>
        {
            try
            {
                string url = response.Url;
                Uri uri = new Uri(url);
                if (url.Contains("mobile"))
                {
                    string text =await response.TextAsync();
                }
            }
            catch (Exception ee)
            {

            }
        };
        
            await context.RouteAsync(new Regex(@"mobilewebdriver.js", RegexOptions.IgnoreCase), async route =>
            {
                string url = route.Request.Url;
                IRequest request = route.Request;
                if(null == websiteUser.playwright_page) {
                    websiteUser.playwright_page = request.Frame.Page;
                }
                
                Dictionary<string, string> headers = await request.AllHeadersAsync();
                if (null != websiteUser.headers)
                {
                    foreach (var i in headers)
                    {
                        if (!string.IsNullOrEmpty(i.Value))
                        {
                            websiteUser.headers[i.Key] = i.Value;
                        }
                        else if (!websiteUser.headers.ContainsKey(i.Key))
                        {
                            websiteUser.headers[i.Key] = i.Value;
                        }
                    }
                }
                _ = route.ContinueAsync();
            });


        }
    } }



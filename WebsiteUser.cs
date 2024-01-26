using Microsoft.Playwright;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace playwrightTest
{
    public class WebsiteUser
    {
        [JsonIgnore]
        public IPage playwright_page { get; set; }
        [JsonIgnore]
        public ConcurrentDictionary<string, string> headers = new ConcurrentDictionary<string, string>();
    }
}

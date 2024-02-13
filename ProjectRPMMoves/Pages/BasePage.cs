using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectRPMMoves
{
    public class BasePage
    {
        public IPage Page;

        public async Task SetupPage(string pageUrl)
        {
            var playwright = await Playwright.CreateAsync();

            BrowserTypeLaunchOptions launchOption = new BrowserTypeLaunchOptions();
            launchOption.Headless = false;
            launchOption.SlowMo = 300;
            var browser = await playwright.Chromium.LaunchAsync(launchOption);
            BrowserNewContextOptions contextOptions = new BrowserNewContextOptions();
            contextOptions.IgnoreHTTPSErrors = true;
            var context = await browser.NewContextAsync(new()
            {
                RecordVideoDir = "..record/",
                RecordVideoSize = new RecordVideoSize() { Width = 640, Height = 480 }
            });
            Page = await context.NewPageAsync();

            var url = await Page.GotoAsync(pageUrl);
            await Page.SetViewportSizeAsync(1620, 1020);
        }
        public async Task TakeScreenshot(IPage Page, string name)
        {
            DateTime currentTime = DateTime.Now;
            long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeMilliseconds();

            Random rnd = new Random();
            int imageSerial = rnd.Next(100, 999);

            string imageSerialString = imageSerial + "_";
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "C:/Users/AnharuzZaman/AutomatedProjects/RPMMovesAutomatedTest/ScreenShots/" + name + imageSerialString + unixTime + ".png",
                FullPage = true,
            });
        }
    }
}

using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectRPMMoves.Pages.RPMMovesPages
{
    public class TrackMyShipmentPage
    {
        private readonly IPage _page;
        private readonly ILocator _OrderID;
        private readonly ILocator _EmailID;
        private readonly ILocator _SubmitBtn;
        private readonly ILocator _ErrorMessage;
        private readonly ILocator _ShipmentStatus;
        private readonly ILocator _Title;

        public TrackMyShipmentPage(IPage page)
        {
            _OrderID = page.Locator("//div//input[@id=':r7:']");
            _EmailID = page.Locator("//div//input[@id=':r8:']");
            _SubmitBtn = page.Locator("//div[@class='text-left']//button");
            _ErrorMessage = page.Locator("//p[@class='error-message']");
            _ShipmentStatus = page.GetByRole(AriaRole.Paragraph).Filter(new() { HasText = "Current Status: Booked" });



        }
        public async Task EnterOrderID(string OrderID)
        {
            await _OrderID.FillAsync(OrderID);
        }
        public async Task EnterEmailID(string EmailID)
        {
            await _EmailID.FillAsync(EmailID);
        }
        public async Task ClickSubmitBtn()
        {
            await _SubmitBtn.ClickAsync();
        }
        public async Task GetErrorMessage()
        {
            /*var Actual = await _Title.TextContentAsync();
            var Expected = "Unable to retrieve your shipment data. Please reach out to your RPM Moves representative for updates & assistance. +1 (888) 444-2612";
            if (Actual !=Expected) { Console.WriteLine("Fail"); }
            else { Console.WriteLine("pass"); }*/
           
        }
       
        //Assertions
        public async Task IsUrlMatching(IPage Page) => await Assertions.Expect(Page).ToHaveURLAsync("https://s-www.rpmmoves.com/individual/track-my-shipment");
        public async Task IsTitleMatching(IPage Page) => await Assertions.Expect(Page).ToHaveTitleAsync("RPM Moves | Track My Shipment");
        public async Task <bool> IsSubmitButtonEnable() => await _SubmitBtn.IsVisibleAsync();
        public async Task IsCurrentStatusBooked() => await Assertions.Expect(_ShipmentStatus).ToContainTextAsync("Booked");
        public async Task IsErrorMessageVisible()=>await Assertions.Expect(_ErrorMessage).ToContainTextAsync("Unable to retrieve your shipment data. Please reach out to your RPM Moves representative for updates & assistance. +1 (888) 444-2612");
      
    }
}

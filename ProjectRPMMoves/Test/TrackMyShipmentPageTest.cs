using Microsoft.Playwright;
using NUnit.Framework;
using ProjectRPMMoves.Pages.RPMMovesPages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectRPMMoves.Test
{
    public class TrackMyShipmentPageTest:BasePage
    {
        private TrackMyShipmentPage? _trackMyShipmentpage;
       
        [SetUp]
        public async Task Setup()
        {
            await SetupPage("https://s-www.rpmmoves.com/individual/track-my-shipment");
        }
        [Test]
        public async Task VerifyUrl()
        {
            _trackMyShipmentpage = new TrackMyShipmentPage(Page);
            await _trackMyShipmentpage.IsUrlMatching(Page);
        }
        [Test]
        public async Task VerifyTrackMyShipmentTitle()
        {
            _trackMyShipmentpage = new TrackMyShipmentPage(Page);
            Thread.Sleep(1000);
            await _trackMyShipmentpage.IsTitleMatching(Page);
        }
        [Test]
        public async Task ShipmentTrackingSubmitBtn()
        {
            _trackMyShipmentpage = new TrackMyShipmentPage(Page);
            await _trackMyShipmentpage.EnterOrderID("31451-74745");
            await _trackMyShipmentpage.EnterEmailID("abc@d.com");
            await _trackMyShipmentpage.ClickSubmitBtn();
            await _trackMyShipmentpage.IsSubmitButtonEnable();
            
        }
        [Test]
        public async Task VerifyErrorMessage()
        {

            _trackMyShipmentpage = new TrackMyShipmentPage(Page);
            await _trackMyShipmentpage.EnterOrderID("31451-74045");
            await _trackMyShipmentpage.EnterEmailID("abc@d.com");
            await _trackMyShipmentpage.ClickSubmitBtn();
            await _trackMyShipmentpage.GetErrorMessage();
            await _trackMyShipmentpage.IsErrorMessageVisible();
            
        }
        [Test]
        public async Task CheckShipmentStatus()
        {
            _trackMyShipmentpage = new TrackMyShipmentPage(Page);
            await _trackMyShipmentpage.EnterOrderID("31438-26364");
            await _trackMyShipmentpage.EnterEmailID("abc@d.com");
            await _trackMyShipmentpage.ClickSubmitBtn();
            await _trackMyShipmentpage.IsCurrentStatusBooked();
            
        }
        [TearDown]
        public async Task CloseBrowser()
        {
           await Page.CloseAsync();
        }
    }
}

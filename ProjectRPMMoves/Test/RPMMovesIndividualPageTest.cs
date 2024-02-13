using NUnit.Framework;
using ProjectRPMMoves.Pages.RPMMovesPages;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace ProjectRPMMoves.Test
{

    public class RPMMovesIndividualPageTest : BasePage
    {
        private RPMMovesIndividualPage? _individualPage;
        private QuotePreviewPage? _quotePreviewPage;


        [SetUp]
        public async Task SetUp()
        {
            await SetupPage("https://s-www.rpmmoves.com/individual");

        }
        [Test]
        public async Task VerifyIndividualTitle()
        {
            _individualPage = new RPMMovesIndividualPage(Page);
           await _individualPage.IsTitleMatching(Page);
        }
        [Test]
        public async Task GetQuoteEstimate()
        {
            _individualPage = new RPMMovesIndividualPage(Page);
            
            await _individualPage.EnterVehicleYear("2012");
            await _individualPage.EnterPickupLocation("Austin, TX");
            await _individualPage.EnterVehicleMake("Toyota");
            await _individualPage.EnterDeliveryLocation("Seattle, WA");
            await _individualPage.EnterVehicleModel("Camry");
            await _individualPage.ClickPickupDateRange();
            await _individualPage.SelectPickupDate();
            await _individualPage.ClickGetYourEstimate();
            Thread.Sleep(19000);
            await _individualPage.CostEstimateExist();
            Thread.Sleep(1000);    
        }
        [Test]
        public async Task GetExactQuote()
        {
            _individualPage = new RPMMovesIndividualPage(Page);
            _quotePreviewPage = new QuotePreviewPage(Page);
            await _individualPage.EnterVehicleYear("2012");
            await _individualPage.EnterPickupLocation("Austin, TX");
            await _individualPage.EnterVehicleMake("Toyota");
            await _individualPage.EnterDeliveryLocation("Seattle, WA");
            await _individualPage.EnterVehicleModel("Camry");
            await _individualPage.ClickPickupDateRange();
            await _individualPage.SelectPickupDate();
            await _individualPage.ClickGetYourEstimate();
            Thread.Sleep(1500);
            await _individualPage.CostEstimateExist();
            await _individualPage.ClickReadyForExactQoute();
            Thread.Sleep(1000);
            await _individualPage.EnterFullName("John Smith");
            await _individualPage.EnterEmailAddress("test@test.com");
            await _individualPage.EnterPhoneNumber("0101010101");
            await _individualPage.SelectReasonForTransport();
            await _individualPage.ClickSubmit();
            await _quotePreviewPage.GetQuoteID();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
        }
        [Test]
        public async Task MakeBooking()
        {
            _individualPage = new RPMMovesIndividualPage(Page);
            _quotePreviewPage = new QuotePreviewPage(Page);
            await _individualPage.EnterVehicleYear("2012");
            await _individualPage.EnterPickupLocation("Austin, TX");
            await _individualPage.EnterVehicleMake("Toyota");
            await _individualPage.EnterDeliveryLocation("Seattle, WA");
            await _individualPage.EnterVehicleModel("Camry");
            await _individualPage.SelectPickupDate();
            await _individualPage.ClickPickupDateRange();
            await _individualPage.ClickGetYourEstimate();
            Thread.Sleep(15000);
            await _individualPage.CostEstimateExist();
            await _individualPage.ClickReadyForExactQoute();
            Thread.Sleep(1000);
            await _individualPage.EnterFullName("John Smith");
            await _individualPage.EnterEmailAddress("test@test.com");
            await _individualPage.EnterPhoneNumber("0101010101");
            await _individualPage.SelectReasonForTransport();
            await _individualPage.ClickSubmit();
            Thread.Sleep(1000);
            await _quotePreviewPage.EnterVin("4T1BF1FK3CU564899");
            await _quotePreviewPage.ClickStartBooking();


        }
      
    }
}

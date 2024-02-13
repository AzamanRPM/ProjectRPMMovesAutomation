using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPMMoves.Pages.RPMMovesPages
{
    public class QuotePreviewPage
    {
        private readonly IPage _page;
        private readonly ILocator _QuoteID;
        private readonly ILocator _QuoteMessage;
        private readonly ILocator _VinEnterField;
        private readonly ILocator _StartYourBookingBtn;
        private readonly ILocator _RequoteWithNewVinBtn;
        private readonly ILocator _ReEnterVinBtn;

        public QuotePreviewPage(IPage page)
        {
            _page = page;
            var Url = page.Url;
            
         
            _QuoteID = page.GetByText("QUOTE ID: ");

            _QuoteMessage = page.Locator("//div[@class='quote-preview-info']//div[@class='display-flex justify-center']");
            _VinEnterField = page.GetByPlaceholder("XXXXXXXXXXXXXXXXX");
            _StartYourBookingBtn = page.GetByText("Start Your Booking");
            _RequoteWithNewVinBtn = page.GetByPlaceholder("Requote with this VIN");
            _ReEnterVinBtn = page.GetByText("Re-enter VIN");
        }
        public async Task EnterVin(string VIN)
        {
            await _VinEnterField.FillAsync(VIN);
        }
        public async Task ClickStartBooking() 
        {
            await _StartYourBookingBtn.ClickAsync();
        }
        public async Task ClickReQuoteWithNewVin()
        {
            await _RequoteWithNewVinBtn.ClickAsync();
        }
        public async Task FillWithNewVin()
        {
            await _ReEnterVinBtn.ClickAsync();
        }
        public async Task  GetQuoteID()
        {
           var quote= await _QuoteID.AllTextContentsAsync();
            if (quote == null) 
            {
                Console.WriteLine("Missisng");
            }
            else { Console.WriteLine("is there");
            }
            
        }
        

        //Assertions
        public async Task IsQuoteIdVisible() => await Assertions.Expect(_QuoteID).ToBeVisibleAsync();
       
    }
    
}

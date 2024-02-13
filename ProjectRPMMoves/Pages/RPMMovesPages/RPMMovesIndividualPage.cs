using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectRPMMoves.Pages.RPMMovesPages
{
    public class RPMMovesIndividualPage
    {
        private readonly IPage _page;
        private readonly ILocator _VehicleYear;
        private readonly ILocator _PickupLocation;
        private readonly ILocator _VehicleMake;
        private readonly ILocator _DeliveryLocation;
        private readonly ILocator _VehicleModel;
        private readonly ILocator _PickupDateRange;
        private readonly ILocator _DatePicker;
        private readonly ILocator _IsVehicleOperational;
        private readonly ILocator _AtleastOneSetofKeys;
        private readonly ILocator _HasVehicleModified;
        private readonly ILocator _GetYourQuoteEstimate;
        private readonly ILocator _CostEstimate;
        private readonly ILocator _ReadyForExactQuote;
        private readonly ILocator _FullName;
        private readonly ILocator _EmailAddress;
        private readonly ILocator _PhoneNumber;
        private readonly ILocator _ReasonForTransport;
        private readonly ILocator _SelectReasonFromDropDown;
        private readonly ILocator _Submit;

        public RPMMovesIndividualPage(IPage page)
        {
            _page = page;
            //var CurrentDate = DateTime.Today;
           // string SelectDate= CurrentDate.AddDays(11).ToString("dd");
            DateTime currentDate = DateTime.Today.AddDays(10);
           long unixTime = ((DateTimeOffset)currentDate).ToUnixTimeSeconds();
            string date = unixTime.ToString() + "000";
           
            
          


            _VehicleYear = page.GetByPlaceholder("Vehicle Year");
            _PickupLocation = page.GetByPlaceholder("Austin, TX");
            _VehicleMake = page.GetByPlaceholder("Vehicle Make");
            _DeliveryLocation = page.GetByPlaceholder("Seattle, WA");
            _VehicleModel = page.GetByPlaceholder("Vehicle Model");
            _PickupDateRange = page.GetByPlaceholder("MM/DD/YYYY");
            _DatePicker = page.Locator("//div//span//button[@role='gridcell' and @data-timestamp="+date+"]");
            _IsVehicleOperational = page.GetByLabel("Is the vehicle operational?");
            _AtleastOneSetofKeys = page.GetByLabel("Do you have at least one set of keys?");
            _HasVehicleModified = page.GetByLabel("Has the vehicle been modified?");
            _GetYourQuoteEstimate = page.GetByRole(AriaRole.Button, new() { Name = "Get Your Quote Estimate" });
            _CostEstimate = page.Locator("//div[@class='quick-quote-container']");
            _ReadyForExactQuote = page.GetByText("Ready for an EXACT Quote?");
            _FullName = page.GetByPlaceholder("Jane Smith");
            _EmailAddress = page.GetByPlaceholder("username@example.com");
            _PhoneNumber = page.Locator("//input[@name='phoneNumber']");
            _ReasonForTransport = page.Locator("div#mui-component-select-reasonForTransport");
            _SelectReasonFromDropDown = page.GetByRole(AriaRole.Option, new() { Name = "Relocation" });
            _Submit = page.GetByText("Submit for Exact Quote");
        }
        public async Task EnterVehicleYear(string VehicleYear)
        {
           await _VehicleYear.FillAsync(VehicleYear);
           await _VehicleYear.PressAsync("ArrowDown");
           await _VehicleYear.PressAsync("Enter");
           
        }
        public async Task EnterPickupLocation(string PickupLocation)
        {
            await _PickupLocation.FillAsync(PickupLocation);
            await _PickupLocation.PressAsync("ArrowDown");
            await _PickupLocation.PressAsync("Enter");
        }
        public async Task EnterVehicleMake(string VehicleMake)
        {
            await _VehicleMake.FillAsync(VehicleMake);
            await _VehicleMake.PressAsync("ArrowDown");
            await _VehicleMake.PressAsync("Enter");
        }
        public async Task EnterDeliveryLocation(string DelivryLocation)
        {
            await _DeliveryLocation.FillAsync(DelivryLocation);
            await _DeliveryLocation.PressAsync("ArrowDown");
            await _DeliveryLocation.PressAsync("Enter");
        }
        public async Task EnterVehicleModel(string VehicleModel)
        {
            await _VehicleModel.FillAsync(VehicleModel);
            await _VehicleModel.PressAsync("ArrowDown");
            await _VehicleModel.PressAsync("Enter");
        }
        public async Task ClickPickupDateRange()
        {
            await _PickupDateRange.ClickAsync();
        } 
        public async Task SelectPickupDate()
        {
            await _DatePicker.ClickAsync();
        }
        public async Task ClickGetYourEstimate()
        {
            await _GetYourQuoteEstimate.ClickAsync();
        }
        public async Task ClickReadyForExactQoute()
        {
            await _ReadyForExactQuote.ClickAsync();
        }
        public async Task EnterFullName(string name)
        {
            await _FullName.FillAsync(name);
        }
        public async Task EnterEmailAddress(string email)
        {
            await _EmailAddress.FillAsync(email);
        }
        public async Task EnterPhoneNumber(string phoneNumber)
        {
            await _PhoneNumber.FillAsync(phoneNumber);
        }
        public async Task SelectReasonForTransport()
        {
            await _ReasonForTransport.ClickAsync();
            await _SelectReasonFromDropDown.ClickAsync();
         
        }
        public async Task ClickSubmit()
        {
            await _Submit.ClickAsync(); 
        }
        //Assertions
        public async Task IsTitleMatching(IPage Page) => await Assertions.Expect(Page).ToHaveTitleAsync("RPM Moves | 3 Simple Steps to Move Your Car");
        public async Task <bool> CostEstimateExist() => await _CostEstimate.IsVisibleAsync();
        public async Task IsUrlMatching(IPage Page) => await Assertions.Expect(Page).ToHaveURLAsync("https://s-www.rpmmoves.com/individua");


    }
}

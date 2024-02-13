using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPMMoves
{
    public class RPMHomePage
    {
        private readonly IPage _page;
        private readonly ILocator _Shipper;
        private readonly ILocator _Carriers;
        private readonly ILocator _IndividualBtn;
        // below 3 elements comes under Individual 
        private readonly ILocator _RPMMoves;
        private readonly ILocator _TrackMyShipment;
        private readonly ILocator _FAQs;
        // ***
        private readonly ILocator _About;
        private readonly ILocator _Resources;
        private readonly ILocator _Technology;
        private readonly ILocator _LetsTalk;
        private readonly ILocator _Login;    

        public RPMHomePage(IPage page)
        {
            _Shipper = page.Locator("//div[@class='MuiBox-root css-khmnau']//div//a[@href='/shippers']");
            _Carriers = page.Locator("//div[@class='MuiBox-root css-khmnau']//div//a[@href='/carriers']");
            _IndividualBtn = page.GetByText("Individual");
            // below 3 elements comes under Individual
            _RPMMoves = page.Locator("(//div//a[@href='/individual']//p)[3]");
            _TrackMyShipment = page.Locator("//div//a[@href='/individual/track-my-shipment']");
            _FAQs = page.Locator("//div//a[@href='/individual/faq']");
            // ***
            _About = page.Locator("//div[@class='MuiBox-root css-khmnau']//div//a[@href='/about-us']");
            _Resources = page.GetByText("Resources");
            _Technology = page.Locator("//div[@class='MuiBox-root css-khmnau']//div//a[@href='/technology']");
            _LetsTalk = page.GetByText("Let's Talk");
            _Login = page.GetByText("Login");

        }
        
        public async Task ClickShipperBtn()
        {
            await _Shipper.ClickAsync();
        }
        public async Task ClickCarriersBtn()
        {
            await _Carriers.ClickAsync();
        }
        public async Task HoverOverIndividual()
        {
            await _IndividualBtn.HoverAsync();
        }
        public async Task ClickIndividualBtn()
        {    
            await _IndividualBtn.ClickAsync();   
        }
        // below 3 elements comes under Individual
        public async Task ClickRPMMoves()
        {
            await _RPMMoves.ClickAsync();
        }
        public async Task ClickTrackMyShipment()
        {
            await _TrackMyShipment.ClickAsync();
        }
        public async Task ClickFAQs()
        {
            await _FAQs.ClickAsync();
        }

        public async Task ClickAboutBtn()
        {
            await _About.ClickAsync();
        }
        public async Task ClickResourcesBtn()
        {
            await _Resources.ClickAsync();
        }
        public async Task ClickTechnologyBtn()
        {
            await _Technology.ClickAsync();
        }
        public async Task ClickLetsTalkBtn()
        {
            await _LetsTalk.ClickAsync();
        }
        public async Task ClickLoginBtn()
        {
            await _Login.ClickAsync();
        }
        //Assertions
        public async Task IsTitleMatching(IPage Page) => await Assertions.Expect(Page).ToHaveTitleAsync("RPM | Professional Vehicle Transport | The Driving Force in Logistics™");

        public async Task IsUrlMatching(IPage Page) => await Assertions.Expect(Page).ToHaveURLAsync("https://s-www.rpmmoves.com/");
    }
}





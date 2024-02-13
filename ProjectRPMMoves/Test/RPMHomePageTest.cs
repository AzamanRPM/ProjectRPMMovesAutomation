using NUnit.Framework;
using ProjectRPMMoves.Pages.RPMMovesPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPMMoves
{
    public class RPMHomePageTest : BasePage
    {
        private RPMHomePage? _homePage;
       

        [SetUp]
        public async Task Setup()
        {
            await SetupPage("https://s-www.rpmmoves.com");
        }
        [Test]
        public async Task VerifyUrl()
        {
            _homePage = new RPMHomePage(Page);
          await _homePage.IsUrlMatching(Page);
        }
        [Test]
        public async Task VerifyRPMHomePageTitle()
        {
            _homePage = new RPMHomePage(Page);
          await _homePage.IsTitleMatching(Page);
        }
      
    }
}

using GalantisPlaywright.Elements;
using GalantisPlaywright.Interfaces;
using GalantisPlaywright.RoutePages;
using GalantisPlaywright.Settings;
using GalantisPlaywright.UIActions;
using Microsoft.Playwright;

namespace GalantisPlaywright.Tests
{
    public class MainPageTests
    {
        private IPage page;
        private BrowserSetup _browserSestup;
        private IMainPageActions _mpActions;
        private IMainPageElements _mpElements;
        private EnvironmentRouteProvider _routeProvider;

        [SetUp]
        public async Task Setup()
        {            
            _browserSestup = new BrowserSetup();
            _browserSestup.SetupBrowser(Browsers.Chrome);
            _routeProvider = new EnvironmentRouteProvider();
            _routeProvider.Get(SetRoutePages.Home);
            _mpActions = new MainPageActions(page);
            _mpElements = new MainPageElements(_mpActions, _routeProvider);
        }

        [Test]
        public void GoToMainPage()
        {
            _mpElements.GoToMainWebSite();
        }

    }
}

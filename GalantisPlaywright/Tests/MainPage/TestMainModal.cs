using GalantisPlaywright.Elements;
using GalantisPlaywright.Elements.MainPage;
using GalantisPlaywright.Interfaces;
using GalantisPlaywright.RoutePages;
using GalantisPlaywright.Settings;
using GalantisPlaywright.UIActions;
using Microsoft.Playwright;

namespace GalantisPlaywright.Tests.MainPage
{
    public class TestMainModal : PageTest
    {
        private IBrowser _browser;
        private BrowserSetup _browserSestup;
        private IPage _page;
        private IBrowserContext _context;
        private EnvironmentRouteProvider _routeProvider;
        private IMainPageActions _mpActions;
        private IMainPageElements _mpElements;        

        [SetUp]
        public async Task Setup()
        {            
            _browserSestup = new BrowserSetup();            
            _browser = await _browserSestup.SetupBrowser(Browsers.Chrome);
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            _routeProvider = new EnvironmentRouteProvider();            
            _mpActions = new MainPageActions(_page);
            _mpElements = new MainPageElements(_mpActions, _routeProvider);            
        }

        [Test]
        public async Task GoToMainPage()
        {
            await _mpElements.GoToMainWebSite();
        }

        [Test]
        public async Task GoToMainPageAndCloseModal()
        {
            await _mpElements.GoToMainWebSite();
            await _mpElements.CloseMainPageModalIfVisible();
        }

        [Test]
        public async Task ClickInitialModalSubscribeButton()
        {
            await _mpElements.GoToMainWebSite();
            await _mpElements.ClickMainModalSubscribeButton();
        }
    }
}

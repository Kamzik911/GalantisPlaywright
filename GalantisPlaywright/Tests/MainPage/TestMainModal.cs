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
        private IPlaywright? _playwright;
        private IBrowser _browser;
        private BrowserSetup _browserSestup;
        private IPage _page;
        private IBrowserContext _context;
        private EnvironmentRouteProvider _routeProvider;
        private IMainActions _mpActions;
        private IMainPageElements _mpElements;        

        [SetUp]
        public async Task Setup()
        {   
            _browserSestup = new BrowserSetup();            
            _browser = await _browserSestup.SetupBrowser(Browsers.Chrome);
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            _routeProvider = new EnvironmentRouteProvider();            
            _mpActions = new MainActions(_page);
            _mpElements = new MainPageElements(_mpActions, _routeProvider);            
        }       
                
        [Test]
        public async Task GoToMainPage()
        {
            await _mpElements.GoToMainWebSite();
        }

        //Modal window tests
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

        [Test]
        public async Task ImputTextToInitialModalEmailField()
        {
            await _mpElements.GoToMainWebSite();
            await _mpElements.InputTextInitialModalEmailField();
            await _mpElements.CheckInputedTextToModalEmailField();
        }

        [Test]
        public async Task InitialEmailAddressWarnMessage()
        {
            await _mpElements.GoToMainWebSite();
            await _mpElements.ClickMainModalSubscribeButton();
            await _mpElements.EmailAddressWarningText();
        }

        [Test]
        public async Task AllCountriesArePresent()
        {
            await _mpElements.GoToMainWebSite();
            await _mpElements.GetCountries();
            await _mpElements.ExpectedCoutries();            
        }        

        [Test]
        public async Task AllCountriesAreSelectable()
        {
            await _mpElements.GoToMainWebSite();            
            await _mpElements.AllCountriesAreSelectable();
        }

        //Category bar tests
        [Test]
        public async Task ViewAllButtonClick_ShouldPass()
        {
            await _mpElements.GoToMainWebSiteAndCloseModal();
            await _mpElements.ClickViewAllCategoryBar();
        }

        [Test]
        public async Task AccessoriesButtonClick_ShouldPass()
        {
            await _mpElements.GoToMainWebSiteAndCloseModal();
            await _mpElements.ClickAccessoriesCategoryBar();
        }

        [Test]
        public async Task ApparelButtonClick_ShouldPass()
        {
            await _mpElements.GoToMainWebSiteAndCloseModal();
            await _mpElements.ClickApparelCategoryBar();
        }

        [Test]
        public async Task ClickBundlesCategoryBar_ShouldPass()
        {
            await _mpElements.GoToMainWebSiteAndCloseModal();
            await _mpElements.ClickBundlesCategoryBar();
        }

        [Test]
        public async Task ClickMusicCategoryBar_ShouldPass() 
        {
            await _mpElements.GoToMainWebSiteAndCloseModal();
            await _mpElements.ClickMusicCategoryBar();
        }


        [TearDown]
        public async Task CleanAfterTest()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
            _playwright?.Dispose();
        }
    }
}

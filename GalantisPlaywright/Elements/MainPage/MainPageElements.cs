using GalantisPlaywright.Interfaces;
using GalantisPlaywright.RoutePages;
using GalantisPlaywright.Settings;
using NUnit.Framework.Legacy;

namespace GalantisPlaywright.Elements.MainPage
{    
    public class MainPageElements : IMainPageElements
    {
        private EnvironmentRouteProvider _environmentRoute;
        private MainPageElementsDef mpElementsDef;

        private IMainPageActions _mpActions;        

        public MainPageElements(IMainPageActions mpActions, EnvironmentRouteProvider environmentRoute)
        {
            _mpActions = mpActions;
            _environmentRoute = environmentRoute;
            mpElementsDef = new MainPageElementsDef();
        }

        public async Task GoToMainWebSite()
        {
            await _mpActions.GoToWebSite(_environmentRoute.Get(SetRoutePages.Home));
        }

        public async Task CloseMainPageModalIfVisible()
        {
            await _mpActions.ClickOnButtonByName(mpElementsDef.MainPageCloseButtonModal);
        }

        //Go to main website and close initial modal
        public async Task GoToMainWebSiteAndCloseModal()
        {
            await GoToMainWebSite();
            await CloseMainPageModalIfVisible();
        }

        //Initial modal window elements
        public async Task ClickMainModalSubscribeButton()
        {
            await _mpActions.ClickInFrameButton(mpElementsDef.InitialModalIframe, mpElementsDef.MainModalWindowSubscribeButton);
        }

        public async Task InputTextInitialModalEmailField()
        {
            await _mpActions.InputTextToField(mpElementsDef.InitialModalIframe, mpElementsDef.EmailAddressField, mpElementsDef.TestEmailAddress);
        }

        public async Task CheckInputedTextToModalEmailField()
        {
            await _mpActions.CheckInputedTextVisibility(mpElementsDef.InitialModalIframe, mpElementsDef.EmailAddressField, mpElementsDef.TestEmailAddress);
        }

        public async Task EmailAddressWarningText()
        {
            await _mpActions.CheckIframeTextVisibility(mpElementsDef.InitialModalIframe, mpElementsDef.EmailCountryWarningMessage, 2);
        }
                
        public async Task<List<string>> LoadCountries()
        {
            var countries = await _mpActions.GetValuesFromSuggestionBoxByOption(mpElementsDef.InitialModalIframe, mpElementsDef.CountrySuggestionBox);
            return countries;
        }        

        public async Task GetCountries()
        {
            TestDataCache.Countries = await LoadCountries();            
        }

        public async Task ExpectedCoutries()
        {
            var actual = await LoadCountries();
            var expected = TestDataCache.Countries;
            
            CollectionAssert.AreEquivalent(actual, expected);
        }
    }
}

using GalantisPlaywright.Interfaces;
using GalantisPlaywright.RoutePages;

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

        //Click on subscribe button on initial modal window
        public async Task ClickMainModalSubscribeButton()
        {
            await _mpActions.ClickInFrameButton(mpElementsDef.MainModalIframe, mpElementsDef.MainModalWindowSubscribeButton);
        }
    }
}

using GalantisPlaywright.Interfaces;
using GalantisPlaywright.RoutePages;

namespace GalantisPlaywright.Elements
{    
    public class MainPageElements : IMainPageElements
    {
        private EnvironmentRouteProvider _environmentRoute;

        private IMainPageActions _mpActions; 

        public MainPageElements(IMainPageActions mpActions, EnvironmentRouteProvider environmentRoute)
        {
            _mpActions = mpActions;
            _environmentRoute = environmentRoute;
        }

        public async Task GoToMainWebSite()
        {
            await _mpActions.GoToWebSite(_environmentRoute.Get(SetRoutePages.Home));
        }
    }
}

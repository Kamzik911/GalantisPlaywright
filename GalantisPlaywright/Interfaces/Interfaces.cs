using GalantisPlaywright.RoutePages;

namespace GalantisPlaywright.Interfaces
{
    public interface ISetRoutePages
    {
        string Get(SetRoutePages pages);

        public interface MainPageActions
        {

        }
    }

    public interface IMainPageActions
    {
        Task GoToWebSite(string url);

        Task ClickOn(string selector);
    }

    public interface IMainPageElements
    {
        Task GoToMainWebSite();
    }
}

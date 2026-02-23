using GalantisPlaywright.RoutePages;
using Microsoft.Playwright;

namespace GalantisPlaywright.Interfaces
{
    public interface ISetRoutePages
    {
        string Get(SetRoutePages pages);        
    }

    public interface IMainPageActions
    {
        IFrameLocator GetIFrame(string iframe);
        Task GoToWebSite(string url);                
        Task ClickOnButtonByName(string name);        
        Task ClickButtonByLocator(string locator);
        Task ClickInFrameButton(string iframe, string locator);
    }

    public interface IMainPageElements
    {
        Task GoToMainWebSite();
        Task CloseMainPageModalIfVisible();
        Task GoToMainWebSiteAndCloseModal();
        Task ClickMainModalSubscribeButton();
    }
}

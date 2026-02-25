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
        Task AssertLocatorVisibility(ILocator locator);
        Task AssertLocatorCount(ILocator locator, int count);
        Task CheckInputedTextVisibility(string iframe, string locator, string text);
        Task CheckIframeTextVisibility(string iframe, string text, int count);
        Task ClickOnButtonByName(string name);        
        Task ClickButtonByLocator(string locator);
        Task ClickInFrameButton(string iframe, string locator);
        Task InputTextToField(string ifram, string locator, string text);
    }

    public interface IMainPageElements
    {
        Task GoToMainWebSite();
        Task CloseMainPageModalIfVisible();
        Task GoToMainWebSiteAndCloseModal();
        Task ClickMainModalSubscribeButton();
        Task InputTextInitialModalEmailField();
        Task CheckInputedTextToModalEmailField();
        Task EmailAddressWarningText();
    }
}

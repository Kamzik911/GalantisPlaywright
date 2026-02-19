using GalantisPlaywright.Interfaces;
using Microsoft.Playwright;

namespace GalantisPlaywright.UIActions
{
    public class MainPageActions : IMainPageActions
    {
        private IPage _page;

        public MainPageActions(IPage page)
        {
            _page = page;
        }

        public Task GoToWebSite(string url)
        {
            return _page.GotoAsync(url);
        }

        public Task ClickOn(string selector)
        {
            var locator = _page.Locator(selector);
            return locator.ClickAsync();
        }
    }
}

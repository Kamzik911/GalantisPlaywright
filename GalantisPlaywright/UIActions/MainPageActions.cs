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

        public IFrameLocator GetIFrame(string iframe)
        {
            return _page.FrameLocator(iframe);            
        }

        public async Task GoToWebSite(string url)
        {
            await _page.GotoAsync(url);
        }        

        public async Task ClickOnButtonByName(string name)
        {
            var button = _page.GetByRole(AriaRole.Button, new()
            {
                Name = name
            });
            await Assertions.Expect(button).ToHaveCountAsync(1);
            await Assertions.Expect(button).ToBeVisibleAsync();
            await button.ClickAsync();
        }

        public async Task ClickButtonByLocator(string locator)
        {
            var button = _page.Locator(locator);            
            await Assertions.Expect(button).ToHaveCountAsync(1);
            await Assertions.Expect(button).ToBeVisibleAsync();
            await button.ClickAsync();
        }
        
        public async Task ClickInFrameButton(string iframe, string locator)
        {
            var iframeLocator = GetIFrame(iframe);
            var locatorDef = iframeLocator.Locator(locator);
            await Assertions.Expect(locatorDef).ToHaveCountAsync(1);
            await Assertions.Expect(locatorDef).ToBeVisibleAsync();
            await locatorDef.ClickAsync();
        }
    }
}


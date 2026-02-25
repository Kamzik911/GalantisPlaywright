using GalantisPlaywright.Interfaces;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;

namespace GalantisPlaywright.UIActions
{
    public class MainPageActions : IMainPageActions
    {
        private IPage _page;        

        public MainPageActions(IPage page)
        {
            _page = page;
        }
        public async Task GoToWebSite(string url)
        {
            await _page.GotoAsync(url);
        }

        public IFrameLocator GetIFrame(string iframe)
        {
            return _page.FrameLocator(iframe);            
        }       

        public async Task AssertLocatorVisibility(ILocator locator)
        {            
            await Assertions.Expect(locator).ToBeVisibleAsync();
        }

        public async Task AssertLocatorCount(ILocator locator, int count = 1)
        {
            await Assertions.Expect(locator).ToHaveCountAsync(count);         
        }

        public async Task CheckInputedTextVisibility(string iframe, string locator, string text)
        {
            var iframeLocator = GetIFrame(iframe);
            var locatorDef = iframeLocator.Locator(locator);
            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            await Assertions.Expect(locatorDef).ToHaveValueAsync(text);
        }

        public async Task CheckIframeTextVisibility(string iframe, string text, int count)
        {
            var iframeLocator = GetIFrame(iframe);
            var textDef = iframeLocator.GetByText(text);
            await AssertLocatorCount(textDef, count);            
        }

        public async Task ClickOnButtonByName(string name)
        {
            var locatorDef = _page.GetByRole(AriaRole.Button, new()
            {
                Name = name
            });
            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            await locatorDef.ClickAsync();
        }

        public async Task ClickButtonByLocator(string locator)
        {
            var button = _page.Locator(locator);
            await AssertLocatorCount(button);
            await AssertLocatorVisibility(button);
            await button.ClickAsync();
        }
        
        public async Task ClickInFrameButton(string iframe, string locator)
        {
            var iframeLocator = GetIFrame(iframe);
            var locatorDef = iframeLocator.Locator(locator);
            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            await locatorDef.ClickAsync();
        }

        public async Task InputTextToField(string iframe, string locator, string text)
        {
            var iframeLocator = GetIFrame(iframe);
            var locatorDef = iframeLocator.Locator(locator);
            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            await locatorDef.FillAsync(text);
        }
    }
}


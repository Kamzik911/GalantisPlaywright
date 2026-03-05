using GalantisPlaywright.Interfaces;
using Microsoft.Playwright;

namespace GalantisPlaywright.UIActions
{
    public class MainActions : IMainActions
    {
        private IPage _page;        

        public MainActions(IPage page)
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
        
        public ILocator GetLocator(string locator)
        {
            return _page.Locator(locator);
        }

        public async Task LocatorClick(ILocator locator)
        {
            await locator.ClickAsync();
        }

        public async Task AssertLocatorVisibility(ILocator locator)
        {            
            await Assertions.Expect(locator).ToBeVisibleAsync();
        }

        public async Task AssertLocatorCount(ILocator locator, int count = 1)
        {
            await Assertions.Expect(locator).ToHaveCountAsync(count);         
        }       

        public async Task AssertSelectedValue(ILocator locator, string expectedValue)
        {
            await Assertions.Expect(locator).ToHaveValueAsync(expectedValue);
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

        public async Task ButtonClickAriaButton(string ariaButton)
        {
            var locatorDef = _page.GetByRole(AriaRole.Button, new()
            {
                Name = ariaButton
            });
            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            await LocatorClick(locatorDef);
        }

        public async Task ButtonClickAriaLink(string ariaLink)
        {
            var button = _page.GetByRole(AriaRole.Link, new()
            {
                Name = ariaLink
            });
            await AssertLocatorCount(button);
            await AssertLocatorVisibility(button);
            await button.ClickAsync();

        }

        public async Task ClickLocator(string locator)
        {
            var button = _page.Locator(locator);
            await AssertLocatorCount(button);
            await AssertLocatorVisibility(button);
            await LocatorClick(button);
        }        

        public async Task ButtonClickIFrame(string iframe, string locator)
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

        public async Task<List<string>> GetValuesFromSuggestionBoxByOption(string iframe, string locator)
        {
            var iframeLocator = _page.FrameLocator(iframe);
            var locatorDef = iframeLocator.Locator(locator);
            var suggBoxElements = await locatorDef.Locator("select > option").AllTextContentsAsync();            

            await AssertLocatorCount(locatorDef);
            await AssertLocatorVisibility(locatorDef);
            
            return suggBoxElements
                .Select(o => o.Trim())
                .Where(o => !string.IsNullOrWhiteSpace(o))
                .ToList();
        }        

        public async Task AssertAllOptionsSelectableAsync(string iframe, string locator)
        {
            var frame = GetIFrame(iframe);
            var select = GetLocator(locator);

            var options = await GetValuesFromSuggestionBoxByOption(iframe, locator);

            foreach (var option in options)
            { 
                await select.SelectOptionAsync(option);
                await Assertions.Expect(select).ToHaveValueAsync(option);
            }
        }   
    }
}


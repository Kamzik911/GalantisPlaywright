using Microsoft.Playwright;

namespace GalantisPlaywright.Settings
{
    public class BrowserSetup
    {
        private IPlaywright? _playwright;
        private IBrowser? _browser;     

        public async Task<IBrowser> SetupBrowser(Browsers browser)
        {
            _playwright ??= await Playwright.CreateAsync();

            var browserType = browser switch
            {
                Browsers.Chrome => _playwright.Chromium,
                Browsers.Firefox => _playwright.Firefox,
                Browsers.Webkit => _playwright.Webkit,
                _ => throw new ArgumentNullException(nameof(browser))
            };

            return _browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                //SlowMo = 500
            });
        }
    }
}

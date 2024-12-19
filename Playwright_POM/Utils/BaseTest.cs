using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Utils
{
    public class BaseTest
    {
        protected IBrowser _browser;
        protected IPage _page;
        protected IPlaywright _playwright;

        public BaseTest(IPage page)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}

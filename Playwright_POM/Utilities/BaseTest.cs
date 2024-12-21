using Microsoft.Playwright;

namespace Utilities
{
    public class BaseTest
    {
        protected IBrowser _browser;
        protected IBrowserContext _context;
        protected IPage _page;



        [SetUp]
        public async Task SetUp()
        {
            // Playwright nesnesini başlat ve tarayıcıyı başlat
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Tarayıcıyı görünür modda başlat
                SlowMo = 100      // Test adımları arasında yavaşlatma (isteğe bağlı)
            });

            // Yeni bir tarayıcı context'i ve sayfa oluştur
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            // Test tamamlandıktan sonra tarayıcı kaynaklarını temizle
            if (_page != null) await _page.CloseAsync();
            if (_context != null) await _context.CloseAsync();
            if (_browser != null) await _browser.CloseAsync();
        }
    }
}

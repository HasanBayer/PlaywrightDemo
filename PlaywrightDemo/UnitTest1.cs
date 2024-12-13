using Microsoft.Playwright;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PlaywrightDemo
{
    [TestFixture]
    public class AutomationExerciseTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            _context = await _browser.NewContextAsync();
            _playwright.Selectors.SetTestIdAttribute("data-qa"); // Test ID tanımı burada yapılıyor.
        }

        [TearDown]
        public async Task Teardown()
        {
            await _context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        public async Task<IPage> LoginAsync()
        {
            var page = await _context.NewPageAsync();
            await page.GotoAsync("https://www.automationexercise.com/");
            await page.ClickAsync(".fa-lock");

            // Login formunu doldur ve giriş yap
            await page.GetByTestId("login-email").FillAsync("abc123@hotmail.com");
            await page.GetByTestId("login-password").FillAsync("123456789");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            return page;
        }

        [Test]
        public async Task VerifyLogin()
        {
            var page = await LoginAsync();

            // Login doğrulaması
            await Assertions.Expect(page.Locator(".fa-user").First).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("ul > li")).ToContainTextAsync(new[] { "Logged in as" });

            await page.CloseAsync();
        }

        [Test]
        public async Task LogoutAfterLogin()
        {
            var page = await LoginAsync();

            // Logout işlemini gerçekleştir
            await page.ClickAsync("a[href='/logout']");
            await Assertions.Expect(page.Locator(".fa-lock")).ToBeVisibleAsync();

            await page.CloseAsync();
        }

        [Test]
        public async Task AddItemToCart()
        {           
            var page = await LoginAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = " Products" }).ClickAsync();
            await page.Locator(".productinfo > .btn").First.ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "View Cart" }).ClickAsync();
        }




        
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, Timeout = 80000 }
            );
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(url: "https://www.automationexercise.com/");
            await page.ClickAsync(".fa-lock");
            playwright.Selectors.SetTestIdAttribute("data-qa");
            await page.GetByTestId("login-email").FillAsync("abc123@hotmail.com");
            await page.GetByTestId("login-password").FillAsync("123456789");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            //Login control
            var locator = page.Locator(".fa-user").First;
            await Assertions.Expect(page.Locator("ul > li")).ToContainTextAsync(new string[] { "Logged in as" });
            await page.CloseAsync();




        }

        [Test]
        public async Task Test2()
        {
            // Create Playwright instance
            using var playwright = await Playwright.CreateAsync();

            // Launch browser with specified options
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
                Timeout = 80000
            });

            // Create a new browser context
            var context = await browser.NewContextAsync();

            // Create a new page
            var page = await context.NewPageAsync();

            // Navigate to the URL
            const string url = "https://www.automationexercise.com/";
            await page.GotoAsync(url);

            // Click on the login button
            await page.ClickAsync(".fa-lock");

            // Set the attribute for locating test elements
            playwright.Selectors.SetTestIdAttribute("data-qa");

            // Fill in the login form
            const string email = "abc123@hotmail.com";
            const string password = "123456789";
            await page.GetByTestId("login-email").FillAsync(email);
            await page.GetByTestId("login-password").FillAsync(password);

            // Click the login button
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            // Verify login success
            var loggedInUserLocator = page.Locator(".fa-user").First;
            await Assertions.Expect(loggedInUserLocator).ToBeVisibleAsync();

            // Ensure the "Logged in as" text is present
            var menuItemsLocator = page.Locator("ul > li");
            await Assertions.Expect(menuItemsLocator).ToContainTextAsync(new[] { "Logged in as" });

            // Close the page
            await page.CloseAsync();
        }

        [Test]
        public async Task Test3()
        {
            // List of browsers to test
            var browserTypes = new[] { "chromium", "firefox", "webkit" };

            foreach (var browserType in browserTypes)
            {
                // Create Playwright instance
                using var playwright = await Playwright.CreateAsync();

                // Launch the appropriate browser
                IBrowser browser = browserType switch
                {
                    "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 50,
                        Timeout = 80000
                    }),
                    "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 50,
                        Timeout = 80000
                    }),
                    "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 50,
                        Timeout = 80000
                    }),
                    _ => throw new NotSupportedException($"Browser type {browserType} is not supported")
                };

                // Create a new browser context
                var context = await browser.NewContextAsync();

                // Create a new page
                var page = await context.NewPageAsync();

                // Navigate to the URL
                const string url = "https://www.automationexercise.com/";
                await page.GotoAsync(url);

                // Click on the login button
                await page.ClickAsync(".fa-lock");

                // Set the attribute for locating test elements
                playwright.Selectors.SetTestIdAttribute("data-qa");

                // Fill in the login form
                const string email = "abc123@hotmail.com";
                const string password = "123456789";
                await page.GetByTestId("login-email").FillAsync(email);
                await page.GetByTestId("login-password").FillAsync(password);

                // Click the login button
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                // Verify login success
                var loggedInUserLocator = page.Locator(".fa-user").First;
                await Assertions.Expect(loggedInUserLocator).ToBeVisibleAsync();

                // Ensure the "Logged in as" text is present
                var menuItemsLocator = page.Locator("ul > li");
                await Assertions.Expect(menuItemsLocator).ToContainTextAsync(new[] { "Logged in as" });

                // Close the page
                await page.CloseAsync();

                // Close the browser
                await browser.CloseAsync();
            }
        }








    }

}

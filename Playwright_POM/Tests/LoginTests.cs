using Microsoft.Playwright;
using Pages;

[TestFixture]
public class LoginTests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    [SetUp]
    public async Task Setup()
    {
        // Playwright ve tarayıcı başlatma
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50
        });

        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [TearDown]
    public async Task Teardown()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    public async Task LoginTest()
    {
        var loginPage = new LoginPage(_page);

        await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
        await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");

        // Doğrulama
        //Assert.IsTrue(await _page.Locator(".fa-user").IsVisibleAsync(), "Login işlemi başarısız.");
    }
}

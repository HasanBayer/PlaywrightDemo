using Microsoft.Playwright;

namespace Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private ILocator ProductsButton => _page.Locator("a[href='/products']");
        private ILocator SignupLoginButton => _page.Locator("a[href='/login']");

        private ILocator DeleteAccountButton => _page.GetByRole(AriaRole.Link, new() { Name = " Delete Account" });

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToHomePageAsync()
        {
            await _page.GotoAsync("https://www.automationexercise.com");
        }

        public async Task<bool> IsHomePageVisibleAsync()
        {
            return await _page.Locator(".carousel-inner").Nth(0).IsVisibleAsync();
        }
        public async Task ClickSignupLoginButtonAsync()
        {
            await SignupLoginButton.ClickAsync();
        }

        public async Task ClickProductsButtonAsync()
        {
            await ProductsButton.ClickAsync();
        }
        public async Task ClickDeleteAccountButtonAsync()
        {
            await DeleteAccountButton.ClickAsync();
        }
    }
}
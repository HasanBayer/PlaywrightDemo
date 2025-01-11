using Microsoft.Playwright;
using Utilities;

namespace Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator LoginButton => _page.Locator(".fa-lock");
        private ILocator EmailInput => _page.Locator("[data-qa='login-email']");
        private ILocator PasswordInput => _page.Locator("[data-qa='login-password']");
        private ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator LoggedInText => _page.Locator("ul > li:has-text('Logged in as')");
        private ILocator LoggedIcon => _page.Locator(".fa-user");
        private ILocator LogoutButton => _page.Locator("a[href='/logout']");
        private ILocator LogoutIcon => _page.Locator(".fa-lock");
        private ILocator LogoutText => _page.Locator("ul > li:has-text('Logout')");


        // Actions
        public async Task NavigateToLoginPageAsync(string url)
        {
            await _page.GotoAsync(url);
            await LoginButton.ClickAsync();
        }
        public async Task PerformLoginAsync(string email, string password)
        {
            await EmailInput.FillAsync(email);
            await PasswordInput.FillAsync(password);
            await SubmitButton.ClickAsync();
        }
        public async Task<bool> IsLoggedInAsync()
        {
            await LoggedIcon.First.IsVisibleAsync();
            return await LoggedInText.IsVisibleAsync();
        }
        public async Task<bool> IsLogoutAsync()
        {
            await LogoutIcon.First.IsVisibleAsync();
            await LogoutText.IsVisibleAsync();
            await LogoutButton.ClickAsync();
            return true;
            
        }


    }
}

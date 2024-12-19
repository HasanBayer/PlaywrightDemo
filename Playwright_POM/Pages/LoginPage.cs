using Microsoft.Playwright;
using System.Threading.Tasks;
using Utils;

namespace Pages
{
    public class LoginPage:PageTest
    {
        private readonly IPage _page;

        // Constructor
        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Selectors
        private ILocator LoginButton => _page.Locator(".fa-lock");
        private ILocator EmailInput => _page.Locator("[data-qa='login-email']");
        private ILocator PasswordInput => _page.Locator("[data-qa='login-password']");
        private ILocator SubmitButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator LoggedInText => _page.Locator("ul > li:has-text('Logged in as')");

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
            return await LoggedInText.IsVisibleAsync();
        }


    }
}

using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POM.Pages
{
    public class AccountPage
    {
        private readonly IPage _page;
        private ILocator LoggedInAsUsername => _page.Locator("#header li:has-text('Logged in as')");
        private ILocator DeleteAccountButton => _page.Locator("a[href='/delete_account']");
        private ILocator AccountDeletedMessage => _page.Locator("h2:has-text('ACCOUNT DELETED!')");

        public AccountPage(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsLoggedInAsUsernameVisibleAsync()
        {
            return await LoggedInAsUsername.IsVisibleAsync();
        }

        public async Task ClickDeleteAccountButtonAsync()
        {
            await DeleteAccountButton.ClickAsync();
        }

        public async Task<bool> IsAccountDeletedAsync()
        {
            return await AccountDeletedMessage.IsVisibleAsync();
        }
    }
}

using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POM.Pages
{
    public class AccountCreatedPage
    {
        private readonly IPage _page;
        private const string AccountCreatedText = "//b[contains(text(),'Account Created!')]";
        private const string ContinueButton = "a:has-text('Continue')";

        public AccountCreatedPage(IPage page)
        {
            _page = page;
        }

        public async Task VerifyAccountCreatedVisibleAsync()
        {
            var isVisible = await _page.Locator(AccountCreatedText).IsVisibleAsync();
            if (!isVisible)
            {
                throw new Exception("Account Created text is not visible.");
            }
        }

        public async Task ClickContinueButtonAsync()
        {
            await _page.ClickAsync(ContinueButton);
        }
    }
}

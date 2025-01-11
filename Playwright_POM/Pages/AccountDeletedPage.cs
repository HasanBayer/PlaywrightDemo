using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POM.Pages
{
    public class AccountDeletedPage
    {

        private readonly IPage _page;
        public AccountDeletedPage(IPage page)
        {
            _page = page;
        }

        //Locators
        private const string AccountDeletedText = "//b[contains(text(),'Account Deleted!')]";
        private const string ContinueButton = "a:has-text('Continue')";        


        //Actions
        public async Task VerifyAccountDeletedVisibleAsync()
        {
            var isVisible = await _page.Locator(AccountDeletedText).IsVisibleAsync();
            if (!isVisible)
            {
                throw new Exception("Account Deleted text is not visible.");
            }
        }

        public async Task ClickContinueButtonAsync()
        {
            await _page.ClickAsync(ContinueButton);
        }
    }
}

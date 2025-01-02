using Microsoft.Playwright;
using Pages;
using Utilities;

namespace Playwright_POM.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {

        [Test]
        public async Task LoginTest()
        {
            var loginPage = new LoginPage(_page);

            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");
        }
        [Test]
        public async Task VerifyLogin()
        {
            var loginPage = new LoginPage(_page);

            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True);
        }
        [Test]
        public async Task LogoutAfterLogin()
        {
            var loginPage = new LoginPage(_page);

            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");
            await Assertions.Expect(_page.Locator(".fa-lock")).ToBeVisibleAsync();                        
        }
    }

}

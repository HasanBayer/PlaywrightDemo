using Microsoft.Playwright;
using Pages;
using Utilities;

namespace Tests
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
    }

}

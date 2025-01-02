using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Pages;
using Playwright_POM.Pages;
using Utilities;

namespace Playwright_POM.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        [Test]
        public async Task AddOneProductToCartTest()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");
            var cartPage = new CartPage(_page);
            // Add a product to the cart
            string productId = "1"; // Example product ID
            await cartPage.AddOneProductToCartAsync(productId);
            // Navigate to the cart page
            await cartPage.NavigateToCartAsync();
            // Assert that the product is visible in the cart
            Assert.That(await cartPage.IsProductInCartAsync(productId), Is.True);
        }

        [Test]
        public async Task RegisterUserAsync()
        {
            var homePage = new HomePage(_page);
            var signupPage = new SignupPage(_page);
            var accountInfoPage = new AccountInformationPage(_page);
            var accountCreatedPage = new AccountCreatedPage(_page);
            var accountDeletedPage = new AccountDeletedPage(_page);

            // Step 1-2: Launch browser and navigate to the URL
            await homePage.NavigateToHomePageAsync();

            // Step 3: Verify that the home page is visible
            //await homePage.VerifyHomePageVisibleAsync();

            // Step 4: Click on 'Signup / Login' button
            await homePage.ClickSignupLoginButtonAsync();

            // Step 5: Verify 'New User Signup!' is visible
            await signupPage.VerifyNewUserSignupVisibleAsync();

            // Step 6: Enter name and email address
            await signupPage.EnterNameAndEmailAsync("TestUserX", "testuserX@example.com");

            // Step 7: Click 'Signup' button
            await signupPage.ClickSignupButtonAsync();

            // Step 8: Verify that 'ENTER ACCOUNT INFORMATION' is visible
            await accountInfoPage.VerifyEnterAccountInformationVisibleAsync();

            // Step 9-12: Fill account details and preferences
            await accountInfoPage.FillAccountDetailsAsync(
                password: "password123",
                day: "1",
                month: "1",
                year: "2000",
                subscribeNewsletter: true,
                receiveOffers: true,
                firstName: "Test",
                lastName: "User",
                company: "TestCompany",
                address1: "123 Test St",
                country: "United States",
                state: "TestState",
                city: "TestCity",
                zipcode: "12345",
                mobileNumber: "+1234567890"
            );

            // Step 13: Click 'Create Account' button
            await accountInfoPage.ClickCreateAccountButtonAsync();

            // Step 14: Verify that 'ACCOUNT CREATED!' is visible
            await accountCreatedPage.VerifyAccountCreatedVisibleAsync();

            // Step 15: Click 'Continue' button
            await accountCreatedPage.ClickContinueButtonAsync();

            // Step 16: Verify that 'Logged in as username' is visible
            // You can add verification here if needed.

            // Step 17: Click 'Delete Account' button
            await homePage.ClickDeleteAccountButtonAsync();
            await accountDeletedPage.VerifyAccountDeletedVisibleAsync();

            // Step 18: Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
            await accountDeletedPage.ClickContinueButtonAsync();
        }
    }

}
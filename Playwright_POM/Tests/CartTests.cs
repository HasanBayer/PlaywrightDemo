using Pages;
using Utilities;

namespace Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        [Test]
        public async Task AddItemToCartTest()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");

            var cartPage = new CartPage(_page);

            // Add a product to the cart
            string productId = "1"; // Example product ID
            await cartPage.AddItemToCartAsync(productId);

            // Navigate to the cart page
            await cartPage.NavigateToCartAsync("https://www.automationexercise.com/view_cart");

            // Assert that the product is visible in the cart
            Assert.That(await cartPage.IsProductInCartAsync(productId), Is.True);
        }
    }
}

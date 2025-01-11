using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Playwright_POM.Tests
{
    [TestFixture]
    public class VerifyAllProductsTests : BaseTest
    {
        [Test]
        public async Task VerifyAllProductsAndProductDetailPageTest() //Test Case 8: Verify All Products and product detail page
        {            
            // Initialize pages
            var productsPage = new ProductsPage(_page);
            var loginPage = new LoginPage(_page);
            var homePage = new HomePage(_page);

            // Step 1: Navigate to Home Page
            await loginPage.NavigateToLoginPageAsync("https://www.automationexercise.com/");
            await loginPage.PerformLoginAsync("abc123@hotmail.com", "123456789");
            // Step 2: Verify Home Page is visible
            Assert.That(await loginPage.IsLoggedInAsync(), Is.True, "Loggin is unsuccesfull");
            //Assert.IsTrue(await homePage.IsHomePageVisibleAsync(), "Home page is not visible.");

            // Step 3: Click on 'Products' button
            await homePage.ClickProductsButtonAsync();

            // Step 4: Verify user is navigated to ALL PRODUCTS page
            Assert.That(await productsPage.IsAllProductsPageVisibleAsync(), Is.True, "All Products page is not visible.");

            // Step 5: Verify the products list is visible
            Assert.That(await productsPage.IsProductListVisibleAsync(), Is.True, "Product list is not visible.");

            // Step 6: Click on 'View Product' of first product
            string productId = "1"; // Example product ID
            await productsPage.ClickFirstProductViewButtonAsync(productId);

            // Step 7: Verify product detail page is visible with correct details
            Assert.That(await productsPage.IsProductDetailVisibleAsync(),Is.True, "Product details are not visible.");
        }
    }
}

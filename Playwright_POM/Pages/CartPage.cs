using Microsoft.Playwright;

namespace Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        // Locators
        private ILocator AddToCartButton => _page.Locator("button[class='btn btn-default cart']");
        private ILocator ProductLink(string productId) => _page.Locator($"a[href='/product_details/{productId}']");

        public CartPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToCartAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task<bool> IsProductInCartAsync(string productId)
        {
            return await _page.Locator($"tr[id='product-{productId}']").IsVisibleAsync();
        }

        public async Task AddItemToCartAsync(string productId)
        {
            // Click on the product link to navigate to the product details page
            await ProductLink(productId).ClickAsync();

            // Click the Add to Cart button
            await AddToCartButton.ClickAsync();
        }
    }
}

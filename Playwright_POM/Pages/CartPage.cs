using Microsoft.Playwright;

namespace Pages
{
    public class CartPage
    {
        private readonly IPage _page;       

        public CartPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator AddToCartButton => _page.Locator("button[class='btn btn-default cart']");
        private ILocator ViewCartButton => _page.Locator("a[href='/view_cart']").Nth(1);
        private ILocator ProceedToCheckoutButton => _page.Locator("a[href='/checkout']");
        private ILocator DeliveryAddress => _page.Locator(".address_delivery");
        private ILocator BillingAddress => _page.Locator(".address_invoice");
        private ILocator ProductLink(string productId) => _page.Locator($"a[href='/product_details/{productId}']");

        //Actions
        public async Task NavigateToCartAsync()
        {
            await ViewCartButton.ClickAsync();
        }      
        public async Task<bool> IsProductInCartAsync(string productId)
        {
            return await _page.Locator($"tr[id='product-{productId}']").IsVisibleAsync();
        }
        public async Task AddOneProductToCartAsync(string productId)
        {
            // Click on the product link to navigate to the product details page
            await ProductLink(productId).ClickAsync();

            await AddToCartButton.ClickAsync();
        }
        public async Task AddProductToCartAsync()
        {
            await AddToCartButton.ClickAsync();
        }
        public async Task ClickProceedToCheckoutAsync()
        {
            await ProceedToCheckoutButton.ClickAsync();
        }
        public async Task<bool> IsDeliveryAddressCorrectAsync(string expectedAddress)
        {
            var address = await DeliveryAddress.TextContentAsync();
            return address.Contains(expectedAddress);
        }
        public async Task<bool> IsBillingAddressCorrectAsync(string expectedAddress)
        {
            var address = await BillingAddress.TextContentAsync();
            return address.Contains(expectedAddress);
        }
    }
}

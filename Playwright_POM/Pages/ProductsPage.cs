using Microsoft.Playwright;

public class ProductsPage
{
    private readonly IPage _page;
    private ILocator ProductList => _page.Locator(".features_items");
    private ILocator FirstProductViewButton(string productId) => _page.Locator($"a[href='/product_details/{productId}']");
    private ILocator ProductName => _page.Locator(".product-information > h2");
    private ILocator Category => _page.Locator("//p[contains(text(), 'Category')]");
    private ILocator Price => _page.Locator("//span[contains(text(),'Rs')]");
    private ILocator Availability => _page.Locator("//b[contains(text(),'Availability')]");
    private ILocator Condition => _page.Locator("//b[contains(text(),'Condition')]");
    private ILocator Brand => _page.Locator("//b[contains(text(),'Brand')]");

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public async Task<bool> IsAllProductsPageVisibleAsync()
    {
        return await _page.Locator("h2.title:has-text('All Products')").IsVisibleAsync();
    }

    public async Task<bool> IsProductListVisibleAsync()
    {
        return await ProductList.IsVisibleAsync();
    }

    public async Task ClickFirstProductViewButtonAsync(string productId)
    {
        await FirstProductViewButton(productId).ClickAsync();
       
    }
    public async Task<bool> IsProductDetailVisibleAsync()
    {
        return await ProductName.IsVisibleAsync() &&
               await Category.IsVisibleAsync() &&
               await Price.IsVisibleAsync() &&
               await Availability.IsVisibleAsync() &&
               await Condition.IsVisibleAsync() &&
               await Brand.IsVisibleAsync();
    }
}
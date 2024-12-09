using Microsoft.Playwright;
using System.Net;
using System.Text.RegularExpressions;

namespace PlaywrightDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions { Headless=false, SlowMo=50, Timeout=80000} 
            );
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(url: "https://www.automationexercise.com/");            
            await page.ClickAsync(".fa-lock");
            playwright.Selectors.SetTestIdAttribute("data-qa");
            await page.GetByTestId("login-email").FillAsync("abc123@hotmail.com");
            await page.GetByTestId("login-password").FillAsync("123456789");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();




        }
    }
}
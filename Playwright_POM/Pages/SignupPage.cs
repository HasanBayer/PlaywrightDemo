using Microsoft.Playwright;

public class SignupPage
{
    private readonly IPage _page;
    private const string NewUserSignupText = "//h2[contains(text(),'New User Signup!')]";
    private const string NameInput = "input[placeholder='Name']";
    private const string EmailInput = "form:has-text('Signup') input[placeholder='Email Address']";
    private const string SignupButton = "button:has-text('Signup')";

    public SignupPage(IPage page)
    {
        _page = page;
    }

    public async Task VerifyNewUserSignupVisibleAsync()
    {
        var isVisible = await _page.Locator(NewUserSignupText).IsVisibleAsync();
        if (!isVisible)
        {
            throw new Exception("New User Signup! text is not visible.");
        }
    }

    public async Task EnterNameAndEmailAsync(string name, string email)
    {
        await _page.FillAsync(NameInput, name);
        await _page.FillAsync(EmailInput, email);
    }

    public async Task ClickSignupButtonAsync()
    {
        await _page.ClickAsync(SignupButton);
    }
}
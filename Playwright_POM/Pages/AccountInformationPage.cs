using Microsoft.Playwright;

namespace Playwright_POM.Pages
{
    public class AccountInformationPage 
    {
        private readonly IPage _page;
        public AccountInformationPage(IPage page)
        {
            _page = page;
        }

        //Locators
        private const string EnterAccountInformationText = "//b[contains(text(),'Enter Account Information')]";
        private const string TitleRadioButton = "#id_gender1";
        private const string PasswordInput = "//*[@id=\'password\']";
        private const string DayDropdown = "#days";
        private const string MonthDropdown = "#months";
        private const string YearDropdown = "#years";
        private const string NewsletterCheckbox = "#newsletter";
        private const string SpecialOffersCheckbox = "#optin";
        private const string FirstNameInput = "//*[@id='first_name']";
        private const string LastNameInput = "//*[@id='last_name']";
        private const string CompanyInput = "//*[@id='company']";
        private const string Address1Input = "//*[@id='address1']";
        private const string CountryDropdown = "select#country";
        private const string StateInput = "//*[@id='state']";
        private const string CityInput = "//*[@id='city']";
        private const string ZipcodeInput = "//*[@id='zipcode']";
        private const string MobileNumberInput = "//*[@id='mobile_number']";
        private const string CreateAccountButton = "button:has-text('Create Account')";

        
        //Actions
        public async Task VerifyEnterAccountInformationVisibleAsync()
        {
            var isVisible = await _page.Locator(EnterAccountInformationText).IsVisibleAsync();
            if (!isVisible)
            {
                throw new Exception("Enter Account Information text is not visible.");
            }
        }

        public async Task FillAccountDetailsAsync(string password, string day, string month, string year, bool subscribeNewsletter, bool receiveOffers, string firstName, string lastName, string company, string address1, string country, string state, string city, string zipcode, string mobileNumber)
        {
            await _page.CheckAsync(TitleRadioButton);
            await _page.FillAsync(PasswordInput, password);
            await _page.SelectOptionAsync(DayDropdown, day);
            await _page.SelectOptionAsync(MonthDropdown, month);
            await _page.SelectOptionAsync(YearDropdown, year);

            if (subscribeNewsletter)
            {
                await _page.CheckAsync(NewsletterCheckbox);
            }

            if (receiveOffers)
            {
                await _page.CheckAsync(SpecialOffersCheckbox);
            }

            await _page.FillAsync(FirstNameInput, firstName);
            await _page.FillAsync(LastNameInput, lastName);
            await _page.FillAsync(CompanyInput, company);
            await _page.FillAsync(Address1Input, address1);
            await _page.SelectOptionAsync(CountryDropdown, country);
            await _page.FillAsync(StateInput, state);
            await _page.FillAsync(CityInput, city);
            await _page.FillAsync(ZipcodeInput, zipcode);
            await _page.FillAsync(MobileNumberInput, mobileNumber);
        }

        public async Task ClickCreateAccountButtonAsync()
        {
            await _page.ClickAsync(CreateAccountButton);
        }
    }
}

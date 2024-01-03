namespace MauiApp1;

public partial class OtpPage : ContentPage
{
    private MongoDbContext dbContext;
    private string mobileNumber;

    public OtpPage(string mobileNumber, MongoDbContext dbContext)
	{
		InitializeComponent();
        this.mobileNumber = mobileNumber;
        this.dbContext = dbContext;
	}

    private void OnEnterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage(mobileNumber, dbContext));
    }

    private void OnResendOtpTapped(object sender, EventArgs e)
    {
        // Call your function for resend OTP logic here
        ResendOtp();
    }

    private void ResendOtp()
    {
        // Implement the logic for resending OTP here
        // For example, you might send a new OTP to the user's phone number
        // or trigger the resend OTP process
    }
    private void OnDigitEntered(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        // Move focus to the next Entry when a digit is entered
        switch (entry)
        {
            case Entry _ when entry == entry1 && e.NewTextValue.Length > 0:
                entry2.Focus();
                break;

            case Entry _ when entry == entry2 && e.NewTextValue.Length > 0:
                entry3.Focus();
                break;

            case Entry _ when entry == entry3 && e.NewTextValue.Length > 0:
                entry4.Focus();
                break;
        }
    }
}
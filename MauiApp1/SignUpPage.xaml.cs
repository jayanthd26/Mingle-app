using System.Security.Cryptography;
using System.Text;

namespace MauiApp1;

public partial class SignUpPage : ContentPage
{
    private readonly MongoDbContext _dbContext;
    private readonly Random random = new Random();
    //private EmailService emailService;
    
    public SignUpPage(MongoDbContext dbContext)
	{
		InitializeComponent();
        //string connectionString = "mongodb://rakshithazrati:w8mSxGhX4sbnOID5@ac-annsyke-shard-00-02.7qncxbg.mongodb.net:27017,ac-annsyke-shard-00-01.7qncxbg.mongodb.net:27017,ac-annsyke-shard-00-00.7qncxbg.mongodb.net:27017/MingleApp?authSource=admin&ssl=true";
        ////string connectionString = "mongodb+srv://rakshithazrati:w8mSxGhX4sbnOID5@mingleapp.7qncxbg.mongodb.net/?retryWrites=true&w=majority&appName=MingleApp";
        //string databaseName = "MingleApp";
        //dbContext = new MongoDbContext(connectionString, databaseName);
        _dbContext = dbContext;
    }

    private void SwichToSignIn(object sender, EventArgs e)
    {
        var LoginPage = Handler.MauiContext.Services.GetService<LogIn>();
        Navigation.PushAsync(LoginPage);
    }

    public string GenerateOTP()
    {
        return random.Next(100000,999999).ToString();
    }
    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        var emailService = new EmailService();
        var otp = GenerateOTP();

        emailService.SendOTPMail("rakshit@yugsha.com", otp); //change to entered email 
        await _dbContext.SaveSignUpDetails(enteredUsername.Text, enteredEmail.Text, enteredPhoneNumber.Text, enteredPassword.Text); //add verified = false and make it true when otp verification done

        var otpPage = Handler.MauiContext.Services.GetService<OtpPage>();
        await Navigation.PushAsync(otpPage);
    }
}
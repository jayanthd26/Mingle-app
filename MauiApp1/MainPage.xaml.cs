namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private MongoDbContext dbContext;
        private string mobileNumber;

        public MainPage()
        {
            InitializeComponent();

            string connectionString = "";
            string databaseName = "MingleApp";
            dbContext = new MongoDbContext(connectionString, databaseName);
        }

        private void OnSignUpClicked(object sender, EventArgs e)
        {
            mobileNumber = enteredPhoneNumber.Text;
            Navigation.PushAsync(new OtpPage(mobileNumber, dbContext));
        }
    }

}

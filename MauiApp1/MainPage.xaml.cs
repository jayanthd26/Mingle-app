namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        //private MongoDbContext dbContext;
        //private string mobileNumber;

        public MainPage()
        {
            InitializeComponent();

            //string connectionString = "mongodb+srv://rakshithazrati:w8mSxGhX4sbnOID5@mingleapp.7qncxbg.mongodb.net/?retryWrites=true&w=majority";
            //string databaseName = "MingleApp";
            //dbContext = new MongoDbContext(connectionString, databaseName);
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            var LoginPage = Handler.MauiContext.Services.GetService<LogIn>();
            //mobileNumber = enteredPhoneNumber.Text;
            Navigation.PushAsync(LoginPage);
        }
    }

}

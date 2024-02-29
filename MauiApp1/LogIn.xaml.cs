using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace MauiApp1
{
    public partial class LogIn : ContentPage
    {
        private readonly MongoDbContext _dbContext;
        public LogIn(MongoDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        public void SwichToSignUp(object sender, EventArgs e)
        {
            var signUpPage = Handler.MauiContext.Services.GetService<SignUpPage>();
            Navigation.PushAsync(signUpPage);
        }

        private void LogInClicked(object sender, EventArgs e)
        {
            //check login and send to next page 
        }
    }

}
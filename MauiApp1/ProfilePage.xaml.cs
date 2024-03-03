using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace MauiApp1;

public partial class ProfilePage : ContentPage
{
    private List<Image> uploadedImages = new List<Image>();
    private MongoDbContext dbContext;
    private string mobileNumber;

    public ProfilePage(string mobileNumber, MongoDbContext dbContext)
	{
		InitializeComponent();
        this.dbContext = dbContext;
        this.mobileNumber = mobileNumber;
	}

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select a Photo"
        });

        if (result != null)
        {
            // Create an Image element and display the uploaded image
            Image image = new Image
            {
                Source = result.FullPath,
                WidthRequest = 50,
                HeightRequest = 50,
            };

            uploadedImages.Add(image);

            UpdateImageDisplay();
        }
    }

    private void UpdateImageDisplay()
    {
        // Display up to 4 uploaded images
        for (int i = 0; i < uploadedImages.Count && i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    image1.Source = uploadedImages[i].Source;
                    break;
                case 1:
                    image2.Source = uploadedImages[i].Source;
                    break;
                case 2:
                    image3.Source = uploadedImages[i].Source;
                    break;
                case 3:
                    image4.Source = uploadedImages[i].Source;
                    break;
            }
        }
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        // Calculate age based on the selected date of birth
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - dobPicker.Date.Year - (currentDate.DayOfYear < dobPicker.Date.DayOfYear ? 1 : 0);

        // Update the age label
        ageLabel.Text = $"Age: {age}";
    }

    private void OnSaveProfileClicked(object sender, EventArgs e)
    {
        var userProfile = new UserProfile
        {
            MobileNumber = mobileNumber, 
            FullName = enteredFullName.Text,
            Description = enteredDescription.Text,
            City = enteredCity.Text,
            State = enteredState.Text,
            Country = enteredCountry.Text,
            ZipCode = enteredZipCode.Text,
            DateOfBirth = dobPicker.Date,
        };

        userProfile.Friends.Add("Friend1");
        userProfile.Friends.Add("Friend2");

        //dbContext.UserProfiles.InsertOne(userProfile);
    }
}
using System;
using Xamarin.Forms;	
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			await User.LoginAsync(usernameEntry.Text, passwordEntry.Text);
			Navigation.InsertPageBefore(new MainPage(), this);
			await Navigation.PopAsync();
			//else {
			//	messageLabel.Text = "Login failed";
			//	passwordEntry.Text = string.Empty;
			//}
		}
	}
}


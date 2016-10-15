using System;
using Xamarin.Forms;
using KinveyXamarin;
using System.Diagnostics;
using System.Threading.Tasks;

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
			Application.Current.MainPage = new MainPage();
		}

		async void OnMICLoginButtonClicked(object sender, EventArgs e)
		{
			await User.LoginWithAuthorizationCodeAPIAsync(usernameEntry.Text, passwordEntry.Text, "training://");
			Application.Current.MainPage = new MainPage();
		}
	}
}


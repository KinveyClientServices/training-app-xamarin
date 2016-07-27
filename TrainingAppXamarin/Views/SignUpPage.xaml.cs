using System;
using System.Linq;
using Xamarin.Forms;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage()
		{
			InitializeComponent();
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			String username = usernameEntry.Text;
			String password = passwordEntry.Text;

			// Sign up logic goes here

			var valid = AreDetailsValid(username, password);
			if(valid) {
				User user = await Client.SharedClient.CurrentUser.CreateAsync(username, password);
				var rootPage = Navigation.NavigationStack.FirstOrDefault();
				if (rootPage != null)
				{
					Navigation.InsertPageBefore(new MainPageCS(), Navigation.NavigationStack.First());
					await Navigation.PopToRootAsync();
				}
			}
			else {
				messageLabel.Text = "Sign up failed";
			}
		}

		bool AreDetailsValid(String username, String password)
		{
			return (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password));
		}
	}
}
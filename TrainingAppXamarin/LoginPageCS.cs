using System;
using Xamarin.Forms;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public class LoginPageCS : ContentPage
	{
		Entry usernameEntry, passwordEntry;
		Label messageLabel;

		public LoginPageCS()
		{
			var toolbarItem = new ToolbarItem
			{
				Text = "Sign Up"
			};
			toolbarItem.Clicked += OnSignUpButtonClicked;
			ToolbarItems.Add(toolbarItem);

			messageLabel = new Label();
			usernameEntry = new Entry
			{
				Placeholder = "username"
			};
			passwordEntry = new Entry
			{
				IsPassword = true
			};
			var loginButton = new Button
			{
				Text = "Login"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			Title = "Login";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
				new Label { Text = "Username" },
				usernameEntry,
				new Label { Text = "Password" },
				passwordEntry,
				loginButton,
				messageLabel
			}
			};
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			//await Navigation.PushAsync(new SignUpPageCS());
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			if (!Client.SharedClient.CurrentUser.isUserLoggedIn())
			{
				User u = await Client.SharedClient.CurrentUser.LoginAsync(usernameEntry.Text, passwordEntry.Text);
			}
			Navigation.InsertPageBefore(new MainPageCS(), this);
			await Navigation.PopAsync();
			//else {
			//	messageLabel.Text = "Login failed";
			//	passwordEntry.Text = string.Empty;
			//}
		}
	}
}


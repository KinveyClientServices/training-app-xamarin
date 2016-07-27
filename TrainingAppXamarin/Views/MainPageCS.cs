using System;
using Xamarin.Forms;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public class MainPageCS : ContentPage
	{
		public MainPageCS()
		{
			var toolbarItem = new ToolbarItem
			{
				Text = "Logout"
			};
			toolbarItem.Clicked += OnLogoutButtonClicked;
			ToolbarItems.Add(toolbarItem);

			Title = "Main Page";
			Content = new StackLayout
			{
				Children = {
					new Label {
						Text = "Main app content goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}

		async void OnLogoutButtonClicked(object sender, EventArgs e)
		{
			Client.SharedClient.CurrentUser.Logout();
			Navigation.InsertPageBefore(new LoginPageCS(), this);
			await Navigation.PopAsync();
		}
	}
}


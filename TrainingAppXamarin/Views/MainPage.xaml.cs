using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public partial class MainPage : ContentPage
	{
		private MainPageViewModel viewModel = new MainPageViewModel();

		public MainPage()
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

		async protected override void OnAppearing()
		{
			base.OnAppearing();
			DataStore<Product> dataStore = DataStore<Product>.Collection("Products", DataStoreType.CACHE);
			viewModel.Products = await dataStore.PullAsync();
		}


		async void OnPullClicked(object sender, EventArgs args)
		{
			try
			{
				DataStore<Product> dataStore = DataStore<Product>.Collection("Products", DataStoreType.CACHE);
				viewModel.Products = await dataStore.PullAsync();
				await DisplayAlert("Local Data Pulled",
									viewModel.Products.Count + " product(s) has/have been pulled from Kinvey.",
									"OK");
			}
			catch (KinveyException ke)
			{
				await DisplayAlert("Kinvey Exception",
								   ke.ErrorCode + " | " + ke.Error + " | " + ke.Description + " | " + ke.Debug,
								   "OK");
			}
		}

		async void OnLogoutButtonClicked(object sender, EventArgs e)
		{
			Client.SharedClient.ActiveUser.Logout();
			Navigation.InsertPageBefore(new LoginPage(), this);
			await Navigation.PopAsync();
		}
	}

	public interface ISQLite
	{
		SQLite.Net.Interop.ISQLitePlatform GetConnection();
		string GetPath();
	}
}


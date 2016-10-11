using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class ProductPage : ContentPage
	{
		private MainPageViewModel viewModel = new MainPageViewModel();

		public ProductPage()
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
	}
}

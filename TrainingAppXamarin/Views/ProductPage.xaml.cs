using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class ProductPage : ContentPage
	{
		private ProductPageViewModel viewModel = new ProductPageViewModel();
		private DataStore<Product> dataStore = (DataStore<Product>)Application.Current.Properties["productDataStore"];

		public ProductPage()
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

		async protected override void OnAppearing()
		{
			base.OnAppearing();
			try
			{	
				viewModel.Products = await dataStore.FindAsync();
			}
			catch (KinveyException e)
			{
				Debug.WriteLine(@"Failed to pull: {0}", e.Message);
			}
		}

		async void OnPullClicked(object sender, EventArgs args)
		{
			try
			{
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

		async void OnCreateClicked(object sender, EventArgs args)
		{
			Navigation.InsertPageBefore(new CreateProductPage(viewModel), this);
			await Navigation.PopAsync(true);
		}

		async void OnPushClicked(object sender, EventArgs args)
		{
			try
			{
				await dataStore.PushAsync();
			}
			catch (KinveyException ke)
			{
				await DisplayAlert("Kinvey Exception",
								   ke.ErrorCode + " | " + ke.Error + " | " + ke.Description + " | " + ke.Debug,
								   "OK");
			}
		}

		async void OnSyncClicked(object sender, EventArgs args)
		{
			try
			{
				DataStoreResponse response = await dataStore.SyncAsync();
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

		async void OnFindClicked(object sender, EventArgs args)
		{
			var query = from product in dataStore
						where product.Name == "iPhone"
						select product;

			KinveyDelegate<List<Product>> cacheDelegate = new KinveyDelegate<List<Product>>()
			{
				onSuccess = (List<Product> results) => viewModel.Products.AddRange(results),
				onError = (Exception e) => Debug.WriteLine("Failed to query local cache: {0}", e.Message)
			};

			try
			{
				viewModel.Products = await dataStore.FindAsync(query);
				Debug.WriteLine("Find completed: {0} products(s) has/have been pulled from Kinvey.", viewModel.Products.Count);
			}
			catch (KinveyException ke)
			{
				await DisplayAlert("Kinvey Exception",
								   ke.ErrorCode + " | " + ke.Error + " | " + ke.Description + " | " + ke.Debug,
								   "OK");
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

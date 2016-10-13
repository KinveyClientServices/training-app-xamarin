using System;
using System.Diagnostics;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class PartnerPage : ContentPage
	{
		private PartnerPageViewModel viewModel = new PartnerPageViewModel();
		private DataStore<Partner> dataStore = (DataStore<Partner>)Application.Current.Properties["partnerDataStore"];

		public PartnerPage()
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

		async protected override void OnAppearing()
		{
			base.OnAppearing();
			try
			{
				viewModel.Partners = await dataStore.FindAsync();
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
				viewModel.Partners = await dataStore.PullAsync();
				Debug.WriteLine("Local Data Pulled",
									viewModel.Partners.Count + " partner(s) has/have been pulled from Kinvey.",
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
			Navigation.InsertPageBefore(new CreatePartnerPage(viewModel), this);
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

using System;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class PartnerPage : ContentPage
	{
		private PartnerPageViewModel viewModel = new PartnerPageViewModel();

		public PartnerPage()
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

		async protected override void OnAppearing()
		{
			base.OnAppearing();
			DataStore<Partner> dataStore = DataStore<Partner>.Collection("Partner", DataStoreType.SYNC);
			viewModel.Partners = await dataStore.PullAsync();
		}

		async void OnPullClicked(object sender, EventArgs args)
		{
			try
			{
				DataStore<Partner> dataStore = DataStore<Partner>.Collection("Partner", DataStoreType.CACHE);
				viewModel.Partners = await dataStore.PullAsync();
				await DisplayAlert("Local Data Pulled",
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
		}

		async void OnPushClicked(object sender, EventArgs args)
		{
		}

		async void OnSyncClicked(object sender, EventArgs args)
		{
		}
	}
}

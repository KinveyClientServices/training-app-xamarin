using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class CreatePartnerPage : ContentPage
	{
		public CreatePartnerPage()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs args)
		{
			DataStore<Partner> datastore = DataStore<Partner>.Collection("Partner", DataStoreType.SYNC);
			Partner newPartner = new Partner(nameEntry.Text, companyEntry.Text, emailEntry.Text);
			await datastore.SaveAsync(newPartner);
			await returnToView();
		}

		async void OnCancelClicked(object sender, EventArgs args)
		{
			await returnToView();
		}

		private async Task<Page> returnToView()
		{
			Navigation.InsertPageBefore(new PartnerPage(), this);
			return await Navigation.PopAsync();
		}
	}
}

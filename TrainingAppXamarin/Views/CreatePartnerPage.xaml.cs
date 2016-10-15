using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class CreatePartnerPage : ContentPage
	{
		private PartnerPageViewModel viewModel;

		public CreatePartnerPage(PartnerPageViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
		}

		async void OnSaveClicked(object sender, EventArgs args)
		{
			DataStore<Partner> datastore = (DataStore<Partner>)Application.Current.Properties["partnerDataStore"];
			Partner newPartner = new Partner(nameEntry.Text, companyEntry.Text, emailEntry.Text);
			Partner result = await datastore.SaveAsync(newPartner);
			List<Partner> newList = viewModel.Partners;
			newList.Add(result);
			viewModel.Partners = newList;
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

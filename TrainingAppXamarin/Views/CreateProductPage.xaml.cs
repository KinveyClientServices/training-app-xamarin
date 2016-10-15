using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class CreateProductPage : ContentPage
	{
		private ProductPageViewModel viewModel;

		public CreateProductPage(ProductPageViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
		}

		async void OnSaveClicked(object sender, EventArgs args)
		{
			DataStore<Product> datastore = (DataStore<Product>)Application.Current.Properties["productDataStore"];
			Product newProduct = new Product(nameEntry.Text, descriptionEntry.Text);
			Product result = await datastore.SaveAsync(newProduct);
			List<Product> newList = viewModel.Products;
			newList.Add(result);
			viewModel.Products = newList;
			await returnToView();
		}

		async void OnCancelClicked(object sender, EventArgs args)
		{
			await returnToView();
		}

		private async Task<Page> returnToView()
		{
			Navigation.InsertPageBefore(new ProductPage(), this);
			return await Navigation.PopAsync();
		}

	}
}

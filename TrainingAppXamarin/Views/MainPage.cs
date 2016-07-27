using Xamarin.Forms;
using System;
using System.Collections.Generic;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//if (!Client.SharedClient.CurrentUser.isUserLoggedIn())
			//{
			//	Navigation.PushAsync(new LoginPage());
			//}
		}


		async void OnButtonClicked(object sender, EventArgs args)
		{
			try
			{
				DataStore<Book> dataStore = DataStore<Book>.GetInstance(DataStoreType.SYNC, "books");

				Button button = (Button)sender;

				if (button.Text == "Add Book")
				{
					Book b = new Book();
					b.Title = "Crime and Punishment";
					b.Genre = "Fiction";
					await dataStore.SaveAsync(b);

					await DisplayAlert("Book Added!",
										"The button labeled '" + button.Text + "' has been clicked, and the book '" + b.Title + "' has been added.",
										"OK");
				}
				else if (button.Text == "Push")
				{
					DataStoreResponse dsr = await dataStore.PushAsync();
					await DisplayAlert("Local Data Pushed!",
										"The button labeled '" + button.Text + "' has been clicked, and " + dsr.Count + " book(s) has/have been pushed to Kinvey.",
										"OK");
				}
				else if (button.Text == "Pull")
				{
					List<Book> books = await dataStore.PullAsync();
					await DisplayAlert("Local Data Pulled!",
										"The button labeled '" + button.Text + "' has been clicked, and " + books.Count + " book(s) has/have been pulled from Kinvey.",
										"OK");
				}
				else if (button.Text == "Sync")
				{
					DataStoreResponse dsr = await dataStore.SyncAsync();
					await DisplayAlert("Local Data Synced!",
										"The button labeled '" + button.Text + "' has been clicked, and " + dsr.Count + " book(s) has/have been synced with Kinvey.",
										"OK");
				}
				else if (button.Text == "Logout")
				{
					Client.SharedClient.CurrentUser.Logout();
					App.Current.MainPage = new LoginPage();
				}
			}
			catch (KinveyException ke)
			{
				await DisplayAlert("Kinvey Exception",
								   ke.Reason + " | " + ke.Explanation + " | " + ke.Fix,
								   "OK");
			}
			catch (Exception e)
			{
				await DisplayAlert("General Exception",
								   e.Message,
								   "OK");
			}
		}
	}

	public interface ISQLite
	{
		SQLite.Net.Interop.ISQLitePlatform GetConnection();
		string GetPath();
	}
}


using System;
using System.Threading.Tasks;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class App : Application
	{
		private string app_key = "kid_Wy7NMiwaTx";
		private string app_secret = "18e581bc9c7046a5b1b20ae838105126";

		public App()
		{
			InitializeComponent();

			try
			{
				Client.Builder builder = new Client.Builder(app_key, app_secret)
											.setFilePath(DependencyService.Get<ISQLite>().GetPath())
											.setOfflinePlatform(DependencyService.Get<ISQLite>().GetConnection())
											.setLogger(delegate (string msg) { System.Diagnostics.Debug.WriteLine(msg); });

				buildClient(builder).RunSynchronously();

				Client.SharedClient.MICApiVersion = "v2";
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("General Exception", e.Message);
			}

			this.Properties.Add("partnerDataStore", DataStore<Partner>.Collection("Partner", DataStoreType.SYNC));
			this.Properties.Add("productDataStore", DataStore<Product>.Collection("Products", DataStoreType.CACHE));

			if (Client.SharedClient.ActiveUser != null && Client.SharedClient.ActiveUser.IsActive())
				MainPage = new MainPage();
			else
				MainPage = new LoginPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		private async Task buildClient(Client.Builder builder)
		{
			await builder.Build();
		}

	}
}


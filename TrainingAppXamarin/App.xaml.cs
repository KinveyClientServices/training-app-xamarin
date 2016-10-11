using System;
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
				Client.SharedClient = new Client.Builder(app_key, app_secret)

									.setFilePath(DependencyService.Get<ISQLite>().GetPath())
									.setOfflinePlatform(DependencyService.Get<ISQLite>().GetConnection())
									.setLogger (delegate (string msg) { System.Diagnostics.Debug.WriteLine (msg); })
									.build();

				//Client.SharedClient.MICApiVersion = "v2";
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("General Exception", e.Message);
			}

			//Test API call for use when initially starting development
			Client.SharedClient.PingAsync();

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
	}
}


using System;
using KinveyXamarin;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public partial class App : Application
	{
		private string app_key = "kid_Wy7NMiwaTx";
		private string app_secret = "18e581bc9c7046a5b1b20ae838105126";
		private string user = "austin";
		private string pass = "12345";

		public App()
		{
			InitializeComponent();

			try
			{
				client = new Client.Builder(app_key, app_secret)
									//.setFilePath (NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User) [0].ToString ())
									.setFilePath(DependencyService.Get<ISQLite>().GetPath())
									.setOfflinePlatform(DependencyService.Get<ISQLite>().GetConnection())
									//.setLogger (delegate (string msg) { Console.WriteLine (msg); })
									.build();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("General Exception", e.Message);
			}


			if (Client.SharedClient.CurrentUser.isUserLoggedIn())
				MainPage = new NavigationPage(new MainPageCS());
			else
				MainPage = new NavigationPage(new LoginPageCS());
		}

		protected override async void OnStart()
		{
			//if (!Client.SharedClient.CurrentUser.isUserLoggedIn())
			//{
			//	await Client.SharedClient.CurrentUser.LoginAsync(user, pass);
			//}
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static Client client
		{
			get;
			private set;
		}
	}
}


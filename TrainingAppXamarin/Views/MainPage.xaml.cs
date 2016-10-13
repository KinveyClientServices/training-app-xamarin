using Xamarin.Forms;
using System;
using KinveyXamarin;

namespace TrainingAppXamarin
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void OnLogoutButtonClicked(object sender, EventArgs e)
		{
			Client.SharedClient.ActiveUser.Logout();
			Application.Current.MainPage = new LoginPage();
		}
	}

	public interface ISQLite
	{
		SQLite.Net.Interop.ISQLitePlatform GetConnection();
		string GetPath();
	}
}


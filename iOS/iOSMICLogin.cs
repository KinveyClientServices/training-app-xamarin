using System;
using Foundation;
using KinveyXamarin;
using TrainingAppXamarin.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSMICLogin))]
namespace TrainingAppXamarin.iOS
{
	public class iOSMICLogin : IMICLogin
	{
		public iOSMICLogin()
		{
		}

		public void login()
		{
			User.LoginWithAuthorizationCodeLoginPage("training://", new KinveyMICDelegate<User>()
			{
				onSuccess = (u) => { Console.WriteLine("logged in as: " + u.Id); },
				onError = (error) => { Console.WriteLine("something went wrong: " + error.Message); },
				onReadyToRender = (url) => { UIApplication.SharedApplication.OpenUrl(new NSUrl(url)); }
			});
		}
	}
}

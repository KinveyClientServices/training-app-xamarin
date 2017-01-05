using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using KinveyXamariniOS;

namespace TrainingAppXamarin.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}	

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return KinveyXamarin.Client.SharedClient.ActiveUser.OnOAuthCallbackRecieved(url);
		}
	}
}


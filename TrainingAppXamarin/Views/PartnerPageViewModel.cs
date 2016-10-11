using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	public class PartnerPageViewModel : INotifyPropertyChanged
	{
		public List<Partner> partners = new List<Partner>();

		public List<Partner> Partners
		{
			get
			{
				return partners;
			}
			set
			{
				if (partners != null)
				{
					partners = value;
					OnPropertyChanged("Partners");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}


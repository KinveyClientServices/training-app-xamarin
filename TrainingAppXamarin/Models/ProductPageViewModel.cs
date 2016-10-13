using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace TrainingAppXamarin
{
	public class ProductPageViewModel : INotifyPropertyChanged
	{
		public List<Product> products = new List<Product>();

		public List<Product> Products
		{
			get
			{
				return products;
			}
			set
			{
				if (products != null)
				{
					products = value;
					OnPropertyChanged("Products");
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

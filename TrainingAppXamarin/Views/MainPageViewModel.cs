using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace TrainingAppXamarin
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public string textTest = "Xamarin v3.0 Training App";

		public string TextTest
		{
			get
			{
				return textTest;
			}
			set
			{
				if (textTest != value)
				{
					textTest = value;
					OnPropertyChanged("TextTest");
				}
			}
		}

		public List<Product> products = new List<Product> {new Product("Amazon", "drones")};

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

using System;
using KinveyXamarin;
using Newtonsoft.Json;

namespace TrainingAppXamarin
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Product : Entity
	{
		[JsonProperty("productname")]
		public string Name { get; set; }

		[JsonProperty("productdesc")]
		public string Description { get; set; }

		public Product() { }

		public Product(string name, string description)
		{
			this.Name = name;
			this.Description = description;
		}
	}
}

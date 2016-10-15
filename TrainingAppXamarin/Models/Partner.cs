using System;
using KinveyXamarin;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace TrainingAppXamarin
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Partner : Entity
	{
		[JsonProperty("partnername")]
		public string Name { get; set; }

		[JsonProperty("partnercompany")]
		public string Company { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		public Partner() { }

		public Partner(string name, string company, string email)
		{
			this.Name = name;
			this.Company = company;
			this.Email = email;
		}
	}
}


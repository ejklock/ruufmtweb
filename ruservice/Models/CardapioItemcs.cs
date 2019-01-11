using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ruservice.Models
{
	public class CardapioItemcs
	{
		[Display(Name ="Período")]
		public string periodo { get; set; }
		[Display(Name = "Tipo ")]
		public string tipo { get; set; }
		[Display(Name = "Prato")]
		public string prato { get; set; }
		[Display(Name = "Data")]
		public string data { get; set; }

	
	}
}
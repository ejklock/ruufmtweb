using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ruservice.Models
{
	public class Cardapio
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string periodo { get; set; }
		public string data { get; set; }
		public virtual List<Item> items { get; set; }

		public Cardapio()
		{
			items = new List<Item>();
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ruservice.Models
{
	public class Item
	{

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string tipo { get; set; }
		public string prato { get; set; }
		public virtual int cardapioId { get; set; }
	}
}
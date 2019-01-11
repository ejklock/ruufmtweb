using ruservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ruservice.Configs
{
	public class Contexto:DbContext
	{
		public Contexto(): base("RuContexto")
		{

		}

		public DbSet<Cardapio> Cardapio { get; set; }
		public DbSet<Item> Item { get; set; }
	}
}
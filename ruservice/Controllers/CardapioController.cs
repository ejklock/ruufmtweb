using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ruservice.Configs;
using ruservice.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ruservice.Controllers
{
	public class CardapioController : ApiController
	{
		private Contexto db;

		public CardapioController()
		{
			db = new Contexto();
		}

		// GET: api/Cardapio
		public IEnumerable<Cardapio> GetCardapio() {

			var results = db.Cardapio.ToList().Select(c => new Cardapio { Id = c.Id, data = c.data, periodo = c.periodo, items = c.items.ToList() });
			return results;
		}

		// GET: api/Cardapio/5
		[ResponseType(typeof(Cardapio))]
		public IHttpActionResult GetCardapio(string id)
		{
			Cardapio cardapio = db.Cardapio.Find(id);
			if (cardapio == null)
			{
				return NotFound();
			}

			return Ok(cardapio);
		}
	}
}

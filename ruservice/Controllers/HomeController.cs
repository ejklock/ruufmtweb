using ruservice.Configs;
using ruservice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ruservice.Controllers
{
    public class HomeController : Controller
    {
		// GET: Home
		Contexto db;
		public HomeController()
		{
			db = new Contexto();
			db.Configuration.AutoDetectChangesEnabled = false;
			db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
			db.Configuration.LazyLoadingEnabled = false;
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.UseDatabaseNullSemantics = false;
			db.Configuration.ValidateOnSaveEnabled = false;
		}
		
        public  ActionResult Index()
        {
			var result = (from i in db.Item join c in db.Cardapio on i.cardapioId equals c.Id select new CardapioItemcs { periodo = c.periodo, tipo = i.tipo, prato = i.prato, data = c.data }).ToList();
			
			return View(result);
        }
    }
}
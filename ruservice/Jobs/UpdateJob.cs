using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using Quartz;
using ruservice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using ruservice.Configs;

namespace ruservice.Jobs
{
	public class UpdateJob : IJob
	{
		public async void Execute(IJobExecutionContext context)
		{
			await GetCardapioDataAsync();
		}

		public void TruncateTables()
		{

			using (Contexto db = new Contexto())
			{
				db.Item.RemoveRange(db.Item);
				db.Cardapio.RemoveRange(db.Cardapio);
				db.SaveChanges();
			}
		}

		public string GetTipo(int index)
		{
			if (index==0){ return "Salada"; }
			if (index == 1) { return "Prato Principal"; }
			if (index == 2) { return "Opção Vegetariana"; }
			if (index == 3) { return "Guarnição"; }
			if (index == 4) { return "Acompanhamento"; }
			if (index == 5) { return "Sobremesa"; }
			if (index == 6) { return "Suco"; }
			return "null";
		}

		private async Task GetCardapioDataAsync()
		{

			Exception exception = null;
			Contexto db = new Contexto();
			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Host = "www.ufmt.br";
					client.DefaultRequestHeaders.Add("Accept-Language", "de,en;q=0.7,en-us;q=0.3");
					var doc = new HtmlDocument();
					var pagina = await client.GetStreamAsync("http://www.ufmt.br/ufmt/unidade/index.php/secao/visualizar/3793/RU");
					var streamReader = new StreamReader(pagina);
					doc.Load(streamReader);
					List<IEnumerable<HtmlNode>> teste = new List<IEnumerable<HtmlNode>>();
					for (int i = 1; i <= 7; i++)
					{
						teste.Add(doc.DocumentNode.QuerySelectorAll("tr:nth-child(" + i + ") > td:nth-child(2)"));
					}
					
					List<Cardapio> cardapios = new List<Cardapio>();
					cardapios.Add(new Cardapio() { periodo = "Almoço", data = doc.DocumentNode.QuerySelector("#secao > p:nth-child(5)").InnerText.Trim().Substring(5, 10) });
					cardapios.Add(new Cardapio() { periodo = "Jantar", data = doc.DocumentNode.QuerySelector("#secao > p:nth-child(5)").InnerText.Trim().Substring(5, 10) });
					cardapios.Add(new Cardapio() { periodo = "Sabado", data = doc.DocumentNode.QuerySelector("#secao > p:nth-child(5)").InnerText.Trim().Substring(5, 10) });
				
					int j = 0;
					for (int i = 0; i < teste.Count; i++)
					{
						j = 0;
						foreach (var obj in teste[i])
						{

							if (j == 0)
							{
								cardapios[j].items.Add(new Item {tipo = GetTipo(i), prato = obj.InnerText.Trim() });

							}
							if (j == 1)
							{
								cardapios[j].items.Add(new Item { tipo = GetTipo(i), prato = obj.InnerText.Trim() });

							}
							if (j == 2)
							{
								cardapios[j].items.Add(new Item { tipo = GetTipo(i), prato = obj.InnerText.Trim() });

							}

							j++;
						}
						
					}
					TruncateTables();
					db.Cardapio.AddRange(cardapios);
					db.SaveChanges();
					GC.SuppressFinalize(cardapios);
					GC.SuppressFinalize(teste);
					GC.SuppressFinalize(db);
					GC.SuppressFinalize(doc);
					GC.SuppressFinalize(pagina);
					GC.SuppressFinalize(streamReader);

				}
			}

			catch (Exception ex)
			{

			}   //_testData.Close(); // Close the instance of StreamWriter.

		}

	}
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ruservice.Configs
{
	public class MySqlConfiguration:DbConfiguration
	{
		public MySqlConfiguration()
		{
			SetHistoryContext(
           "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
		}

	}
}
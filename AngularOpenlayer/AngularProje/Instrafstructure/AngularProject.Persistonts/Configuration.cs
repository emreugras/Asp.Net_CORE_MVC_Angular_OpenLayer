using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence
{
	static class Configuration
	{
		static public string ConnectionString
		{
			get
			{
				ConfigurationManager configration = new();
				configration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentetion/AngularProject.Api"));
				configration.AddJsonFile("appsettings.json");
				return configration.GetConnectionString("PostgreSQL");
			}
		}
	}
}

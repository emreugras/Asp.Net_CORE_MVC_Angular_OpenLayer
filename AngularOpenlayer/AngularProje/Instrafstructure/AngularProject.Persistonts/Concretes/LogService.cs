using AngularProject.Application.Abstraction;
using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Concretes
{
	internal class LogService : ILogService
	{
		public List<Logger> GetLogs()
		=> new()
		{

		};
	}
}

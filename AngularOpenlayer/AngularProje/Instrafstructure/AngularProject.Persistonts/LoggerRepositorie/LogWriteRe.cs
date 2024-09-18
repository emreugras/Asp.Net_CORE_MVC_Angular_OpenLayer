using AngularProject.Application.RepositoriesLogger;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using AngularProject.Application.RepositoriesLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularProject.Persistence.Repositories.LoggerRepositorie;

namespace AngularProject.Persistence.LoggerRepositorie
{
	public class LogWriteRe :LogWrite<Logger>,ILoggerWriteRepository
	{
		public LogWriteRe(LoggerDbContext loggerDbContext) : base(loggerDbContext)
		{
		}
	}
}

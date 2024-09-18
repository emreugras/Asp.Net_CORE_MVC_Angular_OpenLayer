using AngularProject.Application.RepositoriesLogger;
using AngularProject.Application.RepositoriesUser;
using AngularProject.Domain.Entities;
using AngularProject.Application.RepositoriesLogger;
using AngularProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories.LoggerRepositorie
{
	public class LogReadRep : LogRead<Logger>, ILoggerReadRepository
	{
		public LogReadRep(LoggerDbContext loggerDbContext) : base(loggerDbContext)
		{
		}
	}
}

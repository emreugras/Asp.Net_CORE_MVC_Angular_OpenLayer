using AngularProject.Application.RepositoriesLogger;
using AngularProject.Application.RepositoriesUser;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories.LoggerRepositorie
{
	public class LogRead<T> : ILogReadRepository<T> where T : Logger
	{
		private readonly LoggerDbContext _loggerDbContext;
		
		public LogRead(LoggerDbContext loggerDbContext)
		{
			_loggerDbContext = loggerDbContext;
		}

		public DbSet<T> Table => _loggerDbContext.Set<T>();

		

		public IQueryable<T> GetAll()
		=> Table;
	}

	
}

using AngularProject.Application.RepositoriesLogger;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories.LoggerRepositorie
{
	public class LogWrite<T> : ILogWriteRepository<T> where T : Logger
	{
		private readonly LoggerDbContext _loggerDbContext;

		public LogWrite(LoggerDbContext loggerDbContext)
		{
			_loggerDbContext = loggerDbContext;
		}
		public DbSet<T> Table => _loggerDbContext.Set<T>();

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<int> SaveAsync()
		 => await _loggerDbContext.SaveChangesAsync();
	}
}

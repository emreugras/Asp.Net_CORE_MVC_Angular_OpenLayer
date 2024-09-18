
using AngularProject.Application.RepositoriesGeometry;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories
{
	public class WriteRepository<T> :IGWriteRepository<T> where T : Geometry
	{
		readonly GeometryDbContext _context;
		public WriteRepository(GeometryDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddeAsync(List<T> model)
		{
			await Table.AddRangeAsync(model);
			return true;
		}

		public async Task<int> SaveAsync()
		 =>await _context.SaveChangesAsync();

		public bool Update(T model)
		{
			EntityEntry entityEntry=Table.Update(model);
			return entityEntry.State==EntityState.Modified;
		}

		public Task<bool> UpdateAsync(string id)
		{
			throw new NotImplementedException();
		}

		public bool Remove(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}
		
		public async Task<bool> RemoveAsync(string id)
		{
			T model = await Table.FirstOrDefaultAsync(data => data.id ==id);
			return Remove(model);
		}
	}
}

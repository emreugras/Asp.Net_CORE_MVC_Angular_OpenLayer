using AngularProject.Application.RepositoriesGeometry;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories
{
	public class ReadRepository<T> : IGReadRepository<T> where T : Geometry
	{
		 readonly GeometryDbContext _context;

		public ReadRepository(GeometryDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll()
		=> Table;

		public async Task<T> GetByIdAsync(string id)
			=> await Table.FindAsync(id);
		//=> await Table.FirstOrDefaultAsync(data => data.id == Int32.Parse(id)); Marker methodu


		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
		=> await Table.FirstOrDefaultAsync(method);

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
		=> Table.Where(method);
	}
}

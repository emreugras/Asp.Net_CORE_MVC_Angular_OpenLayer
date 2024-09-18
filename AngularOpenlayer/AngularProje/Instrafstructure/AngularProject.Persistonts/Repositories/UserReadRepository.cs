using AngularProject.Application.RepositoriesUser;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngularProject.Persistence.Repositories
{
    public class UserReadRepository<T> : IReadUserRepository<T> where T : User
	{
		private readonly UserDbContext _context;
		public UserReadRepository(UserDbContext context)
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

		public async Task<T> GetByNameAndPasswordAsync(string name, string password)
		=> await Table.FindAsync(name ,password);

		
	}
}



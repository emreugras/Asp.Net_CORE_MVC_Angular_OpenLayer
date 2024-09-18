using AngularProject.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Contexts
{
	public class GeometryDbContext:DbContext
	{
        public GeometryDbContext(DbContextOptions<GeometryDbContext> options): base(options){ }
        public DbSet<Geometry> geo { get; set; }
		
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var datas=ChangeTracker.Entries<Geometry>();
				//entitiler üzerinden yapılan değişikliklerin ya da insert verilerinin yakalanmasını sağlar,update oprsynlarında track edilen verileri yakalar.
			
			foreach (var items in datas)
			{
				_ = items.State switch
				{
					EntityState.Added => items.Entity.Datew=DateTime.Now.ToString(),
					EntityState.Modified =>items.Entity.Datew=DateTime.Now.ToString(),
					_ =>DateTime.Now.ToString()	
				};
			}
			return await base.SaveChangesAsync(cancellationToken);//insert ve aupdate işlemlerinde yapılır
		}
	}
}

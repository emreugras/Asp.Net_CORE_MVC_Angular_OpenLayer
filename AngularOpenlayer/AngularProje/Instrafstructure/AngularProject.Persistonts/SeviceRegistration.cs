using AngularProject.Application.Abstraction;
using AngularProject.Persistence.Concretes;
using AngularProject.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

using AngularProject.Persistence.Repositories;
using AngularProject.Domain.Entities;
using Microsoft.Extensions.Options;
using AngularProject.Application.Abstraction.Token;
using AngularProject.Instrafstructure.Token;
using Microsoft.VisualBasic;
using AngularProject.Application.RepositoriesUser;
using AngularProject.Application.RepositoriesGeometry;
using AngularProject.Application.RepositoriesLogger;
using AngularProject.Persistence.Repositories.LoggerRepositorie;
using AngularProject.Persistence.LoggerRepositorie;

namespace AngularProject.Persistence
{
	public static class SeviceRegistration
	{//Icontainer a erişim sağladığımız yer(sevislere yani apiye)

		
		public static void AddPersistanceService(this IServiceCollection services)
		{
			services.AddDbContext<GeometryDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddDbContext<UserDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddDbContext<LoggerDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddScoped<IUserReadRepository, ReadUser>();
			services.AddScoped<ILoggerReadRepository, LogReadRep>();
			services.AddScoped<ILoggerWriteRepository,LogWriteRe>();
			services.AddScoped<IGeomReadRepository, GeometryReadRepository>();
			services.AddScoped<IGeomWriteRepository, GeometryWriteRepository>();
			


			//services.AddIdentity<User, UseRole>(Options =>
			//{
			//	Options.Password.RequiredLength = 3;
			//	Options.Password.RequireNonAlphanumeric = false;
			//	Options.Password.RequireDigit = false;
			//	Options.Password.RequireLowercase = false;
			//	Options.Password.RequireUppercase = false;

			//}
			//).AddEntityFrameworkStores<UserDbContext>();
		}
	}
}

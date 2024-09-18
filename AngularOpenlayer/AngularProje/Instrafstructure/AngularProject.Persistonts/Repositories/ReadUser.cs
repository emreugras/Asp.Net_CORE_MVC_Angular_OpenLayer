using AngularProject.Application.RepositoriesUser;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories
{
	public class ReadUser : UserReadRepository<User>, IUserReadRepository
	{
		public ReadUser(UserDbContext context) : base(context)
		{
		}
	}
}

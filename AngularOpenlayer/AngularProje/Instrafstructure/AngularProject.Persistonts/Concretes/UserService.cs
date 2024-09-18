using AngularProject.Application.Abstraction;
using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Concretes
{
	public class UserService : IUserService
	{
		public List<User> Users()
			=> new()
			{

			};
	}
}

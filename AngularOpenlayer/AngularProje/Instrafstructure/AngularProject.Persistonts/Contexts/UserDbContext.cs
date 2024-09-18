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
	public class UserDbContext:DbContext
	{
		

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{ }
		public virtual DbSet<User> Users{ get; set; }
	}
}

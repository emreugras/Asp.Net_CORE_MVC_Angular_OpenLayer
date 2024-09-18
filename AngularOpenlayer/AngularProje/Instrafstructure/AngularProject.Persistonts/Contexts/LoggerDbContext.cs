using AngularProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Contexts
{
	public class LoggerDbContext :DbContext
	{
	    public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options){
		
		}
		public virtual DbSet<Logger> logger { get; set; }
	}
}

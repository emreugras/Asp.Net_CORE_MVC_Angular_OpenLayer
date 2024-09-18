using AngularProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesLogger
{
	public interface ILogRepository<T> where T :Logger
	{
				DbSet<T> Table { get; }
	}
}

using AngularProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesGeometry
{
	public interface IGRepository<T> where T : Geometry
	{
		DbSet<T> Table { get; }
	}
}

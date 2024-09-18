
using AngularProject.Application.RepositoriesGeometry;
using AngularProject.Domain.Entities;
using AngularProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories
{
	public class GeometryWriteRepository : WriteRepository<Geometry>, IGeomWriteRepository
	{
		public GeometryWriteRepository(GeometryDbContext context) : base(context)
		{
		}
	}
}

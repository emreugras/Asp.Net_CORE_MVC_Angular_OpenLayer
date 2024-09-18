using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AngularProject.Application.Abstraction
{
	public interface IGeometryService
	{
		List<Geometry> GetGeometries();

	}
}

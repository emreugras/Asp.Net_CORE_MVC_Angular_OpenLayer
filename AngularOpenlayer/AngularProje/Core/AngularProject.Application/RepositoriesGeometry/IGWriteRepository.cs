using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesGeometry
{
	public interface IGWriteRepository<T>:IGRepository<T> where T : Geometry
	{
		Task<bool> AddAsync(T model);//tek bir şey ekleme işlemi için
		Task<bool> AddeAsync(List<T> model);//çoğul eklerken
		bool Remove(T model);//Remove
		Task<bool> RemoveAsync(string id);//id ile Remove
		Task<bool> UpdateAsync(string id);//id ile update
		Task<int> SaveAsync();
	}
}

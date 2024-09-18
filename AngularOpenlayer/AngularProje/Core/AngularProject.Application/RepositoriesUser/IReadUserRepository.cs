using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesUser
{
    public interface IReadUserRepository<T> : IReadUser<T> where T : User
    {
        IQueryable<T> GetAll();//Sorgu için 
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);//where fonksiyonu ile sorgu
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);//Şarta uygun olanı getircek,Async çalışcak
        Task<T> GetByIdAsync(string id);//İd İle Getirecek,Async çalışcak
        Task<T> GetByNameAndPasswordAsync(string name,string password);
    }
}

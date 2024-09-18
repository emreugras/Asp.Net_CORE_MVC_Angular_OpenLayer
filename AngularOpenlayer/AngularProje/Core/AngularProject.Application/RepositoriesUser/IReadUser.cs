using AngularProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesUser
{
    public interface IReadUser<T> where T : User
    {
        DbSet<T> Table { get; }

    }
}

﻿using AngularProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.RepositoriesLogger
{
	public interface ILogWriteRepository<T>:ILogRepository<T> where T : Logger
	{
		Task<bool> AddAsync(T model);
		Task<int> SaveAsync();
	}
}

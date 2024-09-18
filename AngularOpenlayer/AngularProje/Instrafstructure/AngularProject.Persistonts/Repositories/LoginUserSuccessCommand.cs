using AngularProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Persistence.Repositories
{
	public class LoginUserSuccessCommand
	{
		public Token Token { get; set; }
	}
}

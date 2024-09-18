using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Application.Abstraction.Token
{
	public interface ITokenHandler
	{
		DTO.Token CreatAccessToken(int minute);
	}
}

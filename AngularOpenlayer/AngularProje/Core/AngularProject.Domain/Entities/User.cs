using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Domain.Entities
{
	public class User
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string Id {  get; set; }
	}
}

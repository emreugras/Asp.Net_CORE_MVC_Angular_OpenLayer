using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Domain.Entities
{
	public class Logger
	{
		[Key]
		public string user { get; set; }
		public string message { get; set; }
		public string date { get; set; }
		
	}
}

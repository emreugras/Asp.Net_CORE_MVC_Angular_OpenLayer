using AngularProject.Application.ViewModels.Users;
using AngularProject.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MediatR;
using Microsoft.Owin.Security.Provider;
using Microsoft.Extensions.Options;
using AngularProject.Domain.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using AngularProject.Persistence.Repositories;
using AngularProject.Application.RepositoriesUser;
using AngularProject.Application.Exceptions;
using AngularProject.Instrafstructure.Token;
using AngularProject.Application.DTO;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Owin.Security;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using AngularProject.Persistence;
using AngularProject.Persistence.Repositories.LoggerRepositorie;
using AngularProject.Persistence.LoggerRepositorie;
using AngularProject.Application.RepositoriesLogger;

namespace AngularProject.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class UserController : ControllerBase
	{
		public string deneme = "sdsd";
 		readonly IUserReadRepository _userReadRepository;
		readonly ILoggerReadRepository _logReadRepository;
		readonly ILoggerWriteRepository _loggerWriteRepository;
	
		private readonly IConfiguration _configuration;
		public UserController(IUserReadRepository userReadRepository, IConfiguration configuration,ILoggerReadRepository logReadRepository,ILoggerWriteRepository loggerWriteRepository
			)
		{

			
			_configuration = configuration;
			_userReadRepository = userReadRepository;
			_logReadRepository= logReadRepository;
			_loggerWriteRepository = loggerWriteRepository;
		}

		//public UserController(IMediator mediator)
		//{
		//	_mediator = mediator;
		//}
		[HttpPost("{action}")]
		public async Task<IActionResult> login(VM_logger vM_Logger)
		{
			
			
			 
			
			List<User> data = _userReadRepository.GetAll().ToList();
			var a = data.FindAll(x => x.Name == vM_Logger.name && x.Password == vM_Logger.password);

			//var a=data.Where(x => x.Name == vM_Logger.name && x.Password == vM_Logger.password).AsQueryable();
			var us = vM_Logger.name.ToString();
			if (a.Count == 1)
			{
				


				Token token = TokenHandler.CreatAccessToken(_configuration);
				
				return Ok(new LoginUserSuccessCommand()
				{
					
					Token = token,
				});
			}
			

            return null;
		}
		//[HttpPost]
		//public async Task<IActionResult> Deneme()
		//{
		//	await _loggerWriteRepository.AddAsync(new()
		//	{
				
		//		message = "Kullanıcı Giriş Yaptık",
		//		date = DateTime.Now.ToString()
		//	});
		//	return Ok();
		//}
	}
}

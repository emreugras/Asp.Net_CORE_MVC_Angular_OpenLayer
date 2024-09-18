using AngularProject.Application.Abstraction.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Instrafstructure.Token
{
	public class TokenHandler 
	{ 
		
		public static Application.DTO.Token CreatAccessToken(IConfiguration _configuration)
		{
			Application.DTO.Token token = new();
			SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
			SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
			token.Expiration = DateTime.Now.AddMinutes(5);
			//token.Expiration = DateTime.UtcNow.AddMinutes();
			JwtSecurityToken securityToken = new(audience: _configuration["Token:Audience"],
				issuer: _configuration["Token:Issuer"], expires: DateTime.UtcNow.AddMinutes(25), notBefore: DateTime.UtcNow,signingCredentials:signingCredentials);

			JwtSecurityTokenHandler tokenHandler = new();
		token.AccessToken=	tokenHandler.WriteToken(securityToken);
			//byte[] numbers=new byte[32];
			//using RandomNumberGenerator _random=RandomNumberGenerator.Create();
			//_random.GetBytes(numbers);
			
			return token;
		}
	}
}

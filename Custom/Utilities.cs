
using InventoryManagementaAPI.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InventoryManagementaAPI.Custom
{
	public class Utilities
	{
		private readonly IConfiguration _configuration;
		public Utilities(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string EncryptSHA256(string value)
		{
			byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
			StringBuilder builder = new();
			for (int i = 0; i < bytes.Length; i++)
			{
				builder.Append(bytes[i].ToString("X2"));
			}
			return builder.ToString();
		}

		public string GenerateJWT(LoginViewModel model)
		{
			var userClaims = new[]{
				new Claim(ClaimTypes.NameIdentifier, model.Id!.ToString()),
				new Claim(ClaimTypes.Email, model.Email!.ToString())
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var JwtConfig = new JwtSecurityToken(
				claims: userClaims,
				expires: DateTime.UtcNow.AddMinutes(10),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(JwtConfig);
		}

		public string GenerateToken(LoginViewModel user)
		{
			var handler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = GenerateClaims(user),
				Expires = DateTime.UtcNow.AddMinutes(15),
				SigningCredentials = credentials,
			};

			var token = handler.CreateToken(tokenDescriptor);
			return handler.WriteToken(token);
		}

		private static ClaimsIdentity GenerateClaims(LoginViewModel user)
		{
			var claims = new ClaimsIdentity();
			claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id!));
			claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
			return claims;
		}
	}
}

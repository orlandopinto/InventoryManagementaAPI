using AutoMapper;
using InventoryManagementaAPI.Custom;
using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using InventoryManagementaAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
		private readonly ILogger<AccountController> _logger;
		private AccountRepository repository;
		Utilities utilities;
		IConfiguration _configuration;

		public AccountController(ILogger<AccountController> logger, InventoryContext context, IMapper mapper, IConfiguration configuration)
		{
			_logger = logger;
			repository = new AccountRepository(context, mapper);
			utilities = new(configuration);
		}

		[HttpPost]
		[Route(@"Login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
		{
			Users result;
			try
			{
				result = await repository.Login(loginViewModel);
			}
			catch (Exception)
			{

				throw;
			}
			if (result == null)
				return StatusCode(StatusCodes.Status200OK, new { isAuthenticated = false, token = "" });
			else
			{
				LoginViewModel loginResult = new()
				{
					Id = result.Id!,
					Email = result.Email!,
					Password = result.PasswordHash
				};
				string accessToken = utilities.GenerateToken(loginResult);
				string refreshToken = utilities.GenerateRefreshToken(loginResult);

				var tokenResult = new TokenResult
				{
					AccessToken = accessToken,
					RefreshToken = refreshToken
				};

				return StatusCode(StatusCodes.Status200OK, new { isAuthenticated = true, FullName = $"{result.FirstName} {result.LastName}.", UserName = result.UserName, isAdmin = result.IsAdmin, tokenResult = tokenResult });
			}
		}

		[HttpPost]
		[Route(@"AccountExists")]
		public async Task<IActionResult> AccountExists([FromBody] AccountExistsViewModel Account)
		{
			bool result;
			try
			{
				result = await repository.AccountExists(Account);
			}
			catch (Exception)
			{

				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { isSuccess = result, result = result });
		}

		[HttpPost]
		[Route(@"Register")]
		public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
		{
			bool result;
			try
			{
				result = await repository.Register(registerViewModel);
			}
			catch (Exception)
			{

				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { isSuccess = result, result = result });
		}

		[HttpPost("refresh")]
		public IActionResult Refresh(TokenResult tokenResult)
		{
			// For simplicity, assume the refresh token is valid and stored securely
			// var storedRefreshToken = _userService.GetRefreshToken(userId);

			// Verify refresh token (validate against the stored token)
			// if (storedRefreshToken != tokenResult.RefreshToken)
			//    return Unauthorized();

			// For demonstration, let's just generate a new access token
			var newAccessToken = utilities.GenerateAccessTokenFromRefreshToken(tokenResult.RefreshToken);

			var response = new TokenResult
			{
				AccessToken = newAccessToken,
				RefreshToken = tokenResult.RefreshToken // Return the same refresh token
			};

			return Ok(response);
		}
	}
}

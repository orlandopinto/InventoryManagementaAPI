using AutoMapper;
using InventoryManagementaAPI.Custom;
using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using InventoryManagementaAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

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

		public AccountController(ILogger<AccountController> logger, UsersContext context, IMapper mapper, IConfiguration configuration)
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

				return StatusCode(StatusCodes.Status200OK, new { isAuthenticated = true, FullName = $"{result.FirstName} {result.LastName}.", UserName = result.UserName, isAdmin = result.IsAdmin, token = utilities.GenerateToken(loginResult) });
			}
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
	}
}

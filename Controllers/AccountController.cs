using AutoMapper;
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

		public AccountController(ILogger<AccountController> logger, UsersContext context, IMapper mapper)
		{
			_logger = logger;

			repository = new AccountRepository(context, mapper);
		}

		[HttpPost]
		[Route(@"Login")]
		public async Task<Users> Login([FromBody] LoginViewModel loginViewModel)
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
			return await Task.FromResult(result);
		}

		[HttpPost]
		[Route(@"Register")]
		public async Task<bool> Register([FromBody] RegisterViewModel registerViewModel)
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
			return await Task.FromResult(result);
		}
	}
}

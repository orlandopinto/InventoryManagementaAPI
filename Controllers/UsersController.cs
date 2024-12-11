using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	[Authorize]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private UsersRepository repository;

		public UsersController(ILogger<UsersController> logger, UsersContext context)
		{
			_logger = logger;
			repository = new UsersRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Users> result;
			try
			{
				result = await repository.GetAll();
			}
			catch (Exception)
			{
				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { result = result });
		}

		[HttpGet(@"{Id:guid}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			Users result;
			try
			{
				result = await repository.Get(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { result = result });
		}

		[HttpPost]
		public async Task<IActionResult> Post(Users user)
		{
			bool result;
			try
			{
				result = await repository.Post(user);
			}
			catch (Exception)
			{
				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { result = result });
		}

		[HttpPut]
		public async Task<IActionResult> Put(Users user)
		{
			bool result;
			try
			{
				result = await repository.Put(user);
			}
			catch (Exception)
			{
				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { result = result });
		}

		[HttpDelete(@"{Id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			bool result;
			try
			{
				result = await repository.Delete(Id);
			}
			catch (Exception)
			{
				throw;
			}
			return StatusCode(StatusCodes.Status200OK, new { result = result });
		}
	}
}

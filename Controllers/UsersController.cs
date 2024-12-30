using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private UsersRepository repository;

		public UsersController(ILogger<UsersController> logger, InventoryContext context)
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
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();

			}
		}

		[HttpGet(@"{Id}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			Users result;
			try
			{
				result = await repository.Get(Id);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(Users user)
		{
			bool result;
			try
			{
				result = await repository.Post(user);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();

			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(Users user)
		{
			bool result;
			try
			{
				result = await repository.Put(user);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpDelete(@"{Id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			bool result;
			try
			{
				result = await repository.Delete(Id);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}

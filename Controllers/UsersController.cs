using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
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
		public async Task<List<Users>> GetAll()
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
			return await Task.FromResult(result);
		}

		[HttpGet(@"{Id:guid}")]
		public async Task<Users> Get(Guid Id)
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
			return await Task.FromResult(result);
		}

		[HttpPost]
		public async Task<bool> Post(Users user)
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
			return await Task.FromResult(result);
		}

		[HttpPut]
		public async Task<bool> Put(Users user)
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
			return await Task.FromResult(result);
		}

		[HttpDelete(@"{Id}")]
		public async Task<bool> Delete(Guid Id)
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
			return await Task.FromResult(result);
		}
	}
}

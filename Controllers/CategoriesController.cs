using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class CategoriesController : Controller
	{
		private readonly ILogger<CategoriesController> _logger;
		private CategoriesRepository repository;

		public CategoriesController(ILogger<CategoriesController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new CategoriesRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Categories> result;
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

		[HttpGet(@"{Id:guid}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			Categories result;
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
		public async Task<IActionResult> Post(Categories categories)
		{
			bool result;
			try
			{
				result = await repository.Post(categories);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(Categories categories)
		{
			bool result;
			try
			{
				result = await repository.Put(categories);
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

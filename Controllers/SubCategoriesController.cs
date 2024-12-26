using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class SubCategoriesController : Controller
	{
		private readonly ILogger<SubCategoriesController> _logger;
		private SubCategoriesRepository repository;

		public SubCategoriesController(ILogger<SubCategoriesController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new SubCategoriesRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<SubCategories> result;
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
			SubCategories result;
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
		public async Task<IActionResult> Post(SubCategories subCategories)
		{
			bool result;
			try
			{
				result = await repository.Post(subCategories);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(SubCategories subCategories)
		{
			bool result;
			try
			{
				result = await repository.Put(subCategories);
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

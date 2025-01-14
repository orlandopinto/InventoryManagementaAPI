using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class ProductsController : Controller
    {
		private readonly ILogger<ProductsController> _logger;
		private ProductsRepository repository;

		public ProductsController(ILogger<ProductsController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new ProductsRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Products> result;
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
			Products result;
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
		public async Task<IActionResult> Post(Products product)
		{
			bool result;
			try
			{
				result = await repository.Post(product);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(Products product)
		{
			bool result;
			try
			{
				result = await repository.Put(product);
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

using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class DiscountsController : Controller
	{
		private readonly ILogger<DiscountsController> _logger;
		private DiscountsRepository repository;

		public DiscountsController(ILogger<DiscountsController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new DiscountsRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Discounts> result;
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
			Discounts result;
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
		public async Task<IActionResult> Post(Discounts discount)
		{
			bool result;
			try
			{
				result = await repository.Post(discount);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(Discounts discount)
		{
			bool result;
			try
			{
				result = await repository.Put(discount);
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

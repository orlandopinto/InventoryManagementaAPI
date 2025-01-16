using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class MultimediaFilesProductController : Controller
	{
		private readonly ILogger<MultimediaFilesProductController> _logger;
		private MultimediaFilesProductRepository repository;

		public MultimediaFilesProductController(ILogger<MultimediaFilesProductController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new MultimediaFilesProductRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<MultimediaFilesProduct> result;
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
			MultimediaFilesProduct result;
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

		[HttpGet]
		[Route("/MultimediaFilesProduct/MultimediaFilesByProduct/api/{ProductId:Guid}")]

		public async Task<IActionResult> GetMultimediaFilesByProductId(Guid ProductId)
		{
			List<MultimediaFilesProduct> result;
			try
			{
				result = await repository.GetMultimediaFilesByProductId(ProductId);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(MultimediaFilesProduct imageProduct)
		{
			bool result;
			try
			{
				result = await repository.Post(imageProduct);
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

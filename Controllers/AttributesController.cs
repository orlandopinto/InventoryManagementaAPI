using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class AttributesController : Controller
	{
		private const string attributeValueId = @"{attributeValueId}";
		private readonly ILogger<CategoriesController> _logger;
		private AttributesRepository repository;

		public AttributesController(ILogger<CategoriesController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new AttributesRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAttributes()
		{
			List<Attributes> result;
			try
			{
				result = await repository.GetAllAttributes();
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route(@"AttributeValues")]
		public async Task<IActionResult> GetAllAttributeValues()
		{
			List<AttributeValues> result;
			try
			{
				result = await repository.GetAllAttributeValues();
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(Attributes attribute)
		{
			bool result;
			try
			{
				result = await repository.Post(attribute);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[Route(@"AttributeValues")]
		public async Task<IActionResult> PostAttributeValue(AttributeValues attributeValue)
		{
			bool result;
			try
			{
				result = await repository.Post(attributeValue);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpDelete(@"{Id}")]
		public async Task<IActionResult> DeleteAttribute(Guid Id)
		{
			bool result;
			try
			{
				result = await repository.DeleteAttribute(Id);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("/attributes/api/AttributeValues/{attributeValueId:Guid}")]
		public async Task<IActionResult> DeleteAttributeValue(Guid attributeValueId)
		{
			bool result;
			try
			{
				result = await repository.DeleteAttributeValue(attributeValueId);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}

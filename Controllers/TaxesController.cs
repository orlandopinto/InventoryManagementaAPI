﻿using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementaAPI.Controllers
{
	[Route(@"[controller]/api")]
	//[Authorize]
	[ApiController]
	public class TaxesController : Controller
	{
		private readonly ILogger<TaxesController> _logger;
		private TaxesRepository repository;

		public TaxesController(ILogger<TaxesController> logger, InventoryContext context)
		{
			_logger = logger;
			repository = new TaxesRepository(context);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Taxes> result;
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
			Taxes result;
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
		public async Task<IActionResult> Post(Taxes tax)
		{
			bool result;
			try
			{
				result = await repository.Post(tax);
				return Ok(result);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> Put(Taxes tax)
		{
			bool result;
			try
			{
				result = await repository.Put(tax);
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

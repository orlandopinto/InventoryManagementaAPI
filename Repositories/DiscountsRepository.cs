using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class DiscountsRepository : IDiscountsRepository
	{
		protected readonly InventoryContext _context;

		public DiscountsRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Discounts>> GetAll()
		{
			List<Discounts> result;
			try
			{
				result = await _context.Discounts.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Discounts> Get(Guid ID)
		{
			Discounts? result;
			try
			{
				result = await _context.Discounts.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}


		public async Task<bool> Post(Discounts discount)
		{
			bool result;
			try
			{
				_context.Discounts.Add(discount);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Discounts discount)
		{
			bool result;
			try
			{
				_context.Entry(discount).State = EntityState.Modified;
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Delete(Guid ID)
		{
			bool result;
			try
			{
				var discount = await _context.Discounts.FindAsync(ID);
				_context.Discounts.Remove(discount!);
				var response = await _context.SaveChangesAsync();
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
	}
}

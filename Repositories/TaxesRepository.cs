using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class TaxesRepository : ITaxesRepository
	{
		protected readonly InventoryContext _context;

		public TaxesRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Taxes>> GetAll()
		{
			List<Taxes> result;
			try
			{
				result = await _context.Taxes.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Taxes> Get(Guid ID)
		{
			Taxes? result;
			try
			{
				result = await _context.Taxes.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}


		public async Task<bool> Post(Taxes tax)
		{
			bool result;
			try
			{
				_context.Taxes.Add(tax);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Taxes tax)
		{
			bool result;
			try
			{
				_context.Entry(tax).State = EntityState.Modified;
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
				var statu = await _context.Taxes.FindAsync(ID);
				_context.Taxes.Remove(statu!);
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

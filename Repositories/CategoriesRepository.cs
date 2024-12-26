using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class CategoriesRepository : ICategoriesRepository
	{
		protected readonly InventoryContext _context;

		public CategoriesRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Categories>> GetAll()
		{
			List<Categories> result;
			try
			{
				result = await _context.Categories.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Categories> Get(Guid ID)
		{
			Categories? result;
			try
			{
				result = await _context.Categories.FindAsync(ID.ToString());
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}


		public async Task<bool> Post(Categories user)
		{
			bool result;
			try
			{
				//user.Id = Guid.NewGuid();
				_context.Categories.Add(user);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Categories user)
		{
			bool result;
			try
			{
				_context.Entry(user).State = EntityState.Modified;
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
				var user = await _context.Categories.FindAsync(ID.ToString());
				_context.Categories.Remove(user);
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

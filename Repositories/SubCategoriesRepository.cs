using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class SubCategoriesRepository : ISubCategoriesRepository
	{
		protected readonly InventoryContext _context;

		public SubCategoriesRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<SubCategories>> GetAll()
		{
			List<SubCategories> result;
			try
			{
				result = await _context.SubCategories.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<SubCategories> Get(Guid ID)
		{
			SubCategories? result;
			try
			{
				result = await _context.SubCategories.FindAsync(ID.ToString());
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}


		public async Task<bool> Post(SubCategories subCategories)
		{
			bool result;
			try
			{
				//user.Id = Guid.NewGuid();
				_context.SubCategories.Add(subCategories);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(SubCategories subCategories)
		{
			bool result;
			try
			{
				_context.Entry(subCategories).State = EntityState.Modified;
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
				var subCategories = await _context.SubCategories.FindAsync(ID.ToString());
				_context.SubCategories.Remove(subCategories);
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

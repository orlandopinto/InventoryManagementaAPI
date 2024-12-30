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
			List<SubCategories> subCategories;
			try
			{
				subCategories = await _context.SubCategories.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(subCategories);
		}

		public async Task<SubCategories> Get(Guid ID)
		{
			SubCategories? subCategory;
			try
			{
				subCategory = await _context.SubCategories.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(subCategory!);
		}


		public async Task<bool> Post(SubCategories subCategory)
		{
			bool result;
			try
			{
				_context.SubCategories.Add(subCategory);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(SubCategories subCategory)
		{
			bool result;
			try
			{
				_context.Entry(subCategory).State = EntityState.Modified;
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
				var subCategory = await _context.SubCategories.FindAsync(ID);
				_context.SubCategories.Remove(subCategory!);
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

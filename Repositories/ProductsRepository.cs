using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class ProductsRepository : IProductsRepository
	{
		protected readonly InventoryContext _context;

		public ProductsRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Products>> GetAll()
		{
			List<Products> result;
			try
			{
				result = await _context.Products.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Products> Get(Guid ID)
		{
			Products? result;
			try
			{
				result = await _context.Products.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}


		public async Task<bool> Post(Products product)
		{
			bool result;
			try
			{
				_context.Products.Add(product);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Products product)
		{
			bool result;
			try
			{
				_context.Entry(product).State = EntityState.Modified;
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
				var statu = await _context.Products.FindAsync(ID);
				_context.Products.Remove(statu!);
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

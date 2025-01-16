using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class MultimediaFilesProductRepository : IMultimediaFilesProductRepository
	{
		protected readonly InventoryContext _context;

		public MultimediaFilesProductRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<MultimediaFilesProduct>> GetAll()
		{
			List<MultimediaFilesProduct> result;
			try
			{
				result = await _context.MultimediaFilesProduct.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<List<MultimediaFilesProduct>> GetMultimediaFilesByProductId(Guid ProductId)
		{
			List<MultimediaFilesProduct>? result;
			try
			{
				result = await _context.MultimediaFilesProduct.Where(w => w.ProductId == ProductId).ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}

		public async Task<MultimediaFilesProduct> Get(Guid ID)
		{
			MultimediaFilesProduct? result;
			try
			{
				result = await _context.MultimediaFilesProduct.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}


		public async Task<bool> Post(MultimediaFilesProduct imageProduct)
		{
			bool result;
			try
			{
				_context.MultimediaFilesProduct.Add(imageProduct);
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
				var statu = await _context.MultimediaFilesProduct.FindAsync(ID);
				_context.MultimediaFilesProduct.Remove(statu!);
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

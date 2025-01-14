using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class StatusRepository : IStatusRepository
	{
		protected readonly InventoryContext _context;

		public StatusRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Status>> GetAll()
		{
			List<Status> result;
			try
			{
				result = await _context.Status.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Status> Get(Guid ID)
		{
			Status? result;
			try
			{
				result = await _context.Status.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result!);
		}


		public async Task<bool> Post(Status statu)
		{
			bool result;
			try
			{
				_context.Status.Add(statu);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Status statu)
		{
			bool result;
			try
			{
				_context.Entry(statu).State = EntityState.Modified;
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
				var statu = await _context.Status.FindAsync(ID);
				_context.Status.Remove(statu!);
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

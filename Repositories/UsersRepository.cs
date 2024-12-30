using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		protected readonly InventoryContext _context;

		public UsersRepository(InventoryContext context)
		{
			_context = context;
		}
		public async Task<List<Users>> GetAll()
		{
			List<Users> users;
			try
			{
				users = await _context.Users.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(users);
		}

		public async Task<Users> Get(Guid ID)
		{
			Users? user;
			try
			{
				user = await _context.Users.FindAsync(ID);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(user!);
		}


		public async Task<bool> Post(Users user)
		{
			bool result;
			try
			{
				_context.Users.Add(user);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public async Task<bool> Put(Users user)
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
				var user = await _context.Users.FindAsync(ID);
				_context.Users.Remove(user!);
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

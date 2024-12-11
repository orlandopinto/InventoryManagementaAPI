using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		protected readonly UsersContext _context;

		public UsersRepository(UsersContext context)
		{
			_context = context;
		}
		public async Task<List<Users>> GetAll()
		{
			List<Users> result;
			try
			{
				result = await _context.Users.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}

		public async Task<Users> Get(Guid ID)
		{
			Users? result;
			try
			{
				result = await _context.Users.FindAsync(ID.ToString());
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(result);
		}


		public async Task<bool> Post(Users user)
		{
			bool result;
			try
			{
				//user.Id = Guid.NewGuid();
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
				var user = await _context.Users.FindAsync(ID.ToString());
				_context.Users.Remove(user);
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

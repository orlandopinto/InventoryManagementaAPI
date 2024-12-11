using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IUsersRepository
	{
		public Task<List<Users>> GetAll();
		public Task<Users> Get(Guid ID);
		public Task<bool> Post(Users user);
		public Task<bool> Put(Users user);
		public Task<bool> Delete(Guid ID);
	}
}

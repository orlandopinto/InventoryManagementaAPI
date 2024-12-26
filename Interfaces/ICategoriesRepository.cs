using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface ICategoriesRepository
	{
		public Task<List<Categories>> GetAll();
		public Task<Categories> Get(Guid ID);
		public Task<bool> Post(Categories user);
		public Task<bool> Put(Categories user);
		public Task<bool> Delete(Guid ID);
	}
}

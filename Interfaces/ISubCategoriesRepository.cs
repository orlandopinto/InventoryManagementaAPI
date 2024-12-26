using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface ISubCategoriesRepository
	{
		public Task<List<SubCategories>> GetAll();
		public Task<SubCategories> Get(Guid ID);
		public Task<bool> Post(SubCategories user);
		public Task<bool> Put(SubCategories user);
		public Task<bool> Delete(Guid ID);
	}
}

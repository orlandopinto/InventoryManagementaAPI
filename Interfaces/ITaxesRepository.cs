using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface ITaxesRepository
	{
		public Task<List<Taxes>> GetAll();
		public Task<Taxes> Get(Guid ID);
		public Task<bool> Post(Taxes tax);
		public Task<bool> Put(Taxes tax);
		public Task<bool> Delete(Guid ID);
	}
}

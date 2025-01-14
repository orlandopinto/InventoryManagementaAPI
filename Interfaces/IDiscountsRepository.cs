using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IDiscountsRepository
	{
		public Task<List<Discounts>> GetAll();
		public Task<Discounts> Get(Guid ID);
		public Task<bool> Post(Discounts discount);
		public Task<bool> Put(Discounts discount);
		public Task<bool> Delete(Guid ID);
	}
}

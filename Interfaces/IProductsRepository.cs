using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IProductsRepository
	{
		public Task<List<Products>> GetAll();
		public Task<Products> Get(Guid ID);
		public Task<bool> Post(Products product);
		public Task<bool> Put(Products product);
		public Task<bool> Delete(Guid ID);
	}
}

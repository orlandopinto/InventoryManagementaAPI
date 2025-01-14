using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IStatusRepository
	{
		public Task<List<Status>> GetAll();
		public Task<Status> Get(Guid ID);
		public Task<bool> Post(Status statu);
		public Task<bool> Put(Status statu);
		public Task<bool> Delete(Guid ID);
	}
}

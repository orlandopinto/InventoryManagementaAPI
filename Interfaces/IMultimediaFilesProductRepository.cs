using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IMultimediaFilesProductRepository
	{
		public Task<List<MultimediaFilesProduct>> GetAll();
		public Task<MultimediaFilesProduct> Get(Guid ID);
		public Task<List<MultimediaFilesProduct>> GetMultimediaFilesByProductId(Guid ProductId);
		public Task<bool> Post(MultimediaFilesProduct multimediaFilesProduct);
		public Task<bool> Delete(Guid ID);
	}
}

using InventoryManagementaAPI.Models;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IAttributesRepository
	{
		public Task<List<Attributes>> GetAllAttributes();
		public Task<List<AttributeValues>> GetAllAttributeValues();
		public Task<bool> Post(Attributes attribute);
		public Task<bool> Post(AttributeValues attributeValue);
		public Task<bool> DeleteAttribute(Guid ID);
		public Task<bool> DeleteAttributeValue(Guid AttributeValueId);
	}
}

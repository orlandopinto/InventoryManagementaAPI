namespace InventoryManagementaAPI.Models;

public partial class AttributeValues
{
	public Guid Id { get; set; }
	public Guid AttributeId { get; set; }
	public required string AttributeValue { get; set; }
}

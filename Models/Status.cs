namespace InventoryManagementaAPI.Models;

public partial class Status
{
	public Guid Id { get; set; }

	public string StatusDescription { get; set; }
	public string CreateBy { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? UpdateDate { get; set; }
}

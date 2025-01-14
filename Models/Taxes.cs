namespace InventoryManagementaAPI.Models;

public partial class Taxes
{
	public Guid Id { get; set; }
	public string TaxDescription { get; set; }
	public decimal Tax { get; set; }
	public string CreateBy { get; set; }
	public bool Active { get; set; }
	public DateTime DateFrom { get; set; }
	public DateTime? DateTo { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? UpdateDate { get; set; }
}

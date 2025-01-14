namespace InventoryManagementaAPI.Models;

public partial class Discounts
{
	public Guid Id { get; set; }
	public string DiscountDescription { get; set; }
	public int Discount { get; set; }
    public string CreateBy { get; set; }
    public DateTime CreationDate { get; set; }
	public DateTime? UpdateDate { get; set; }
	public bool Active { get; set; }
}

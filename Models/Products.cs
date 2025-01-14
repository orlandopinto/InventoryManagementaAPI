namespace InventoryManagementaAPI.Models;

public partial class Products
{
	public Guid Id { get; set; }
	public string ProductName { get; set; }
	public string? ProductDescription { get; set; }
	public decimal Cost { get; set; }
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public int MinimunQuantity { get; set; }
	public string? CodeBar { get; set; }
	public string? Sku { get; set; }
	public string CreateBy { get; set; }
	public Guid CategoryId { get; set; }
	public Guid SubCategoryId { get; set; }
	public Guid DiscountId { get; set; }
	public Guid StatusId { get; set; }
	public Guid TaxId { get; set; }
	public bool Active { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? UpdateDate { get; set; }
}

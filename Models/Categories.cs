namespace InventoryManagementaAPI.Models
{
	public partial class Categories
	{
		public Guid Id { get; set; }
		public required string CategoryName { get; set; }
		public required string CategoryCode { get; set; }
		public string? CategoryDescription { get; set; }
		public required string CreateBy { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public required string CategoryImagePath { get; set; }
	}
}

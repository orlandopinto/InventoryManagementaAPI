namespace InventoryManagementaAPI.Models
{
	public partial class SubCategories
	{
		public Guid Id { get; set; }
		public Guid CategoryID { get; set; }
		public required string SubCategoryName { get; set; }
		public string? SubCategoryDescription { get; set; }
		public required string CreateBy { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
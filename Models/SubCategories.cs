namespace InventoryManagementaAPI.Models
{
	public partial class SubCategories
	{
		public Guid Id { get; set; }

		public string CategoryCode { get; set; }

		public string SubCategoryName { get; set; }

		public string SubCategoryDescription { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? UpdateDate { get; set; }
	}
}
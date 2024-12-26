namespace InventoryManagementaAPI.Models
{
	public partial class Categories
	{
		public Guid Id { get; set; }

		public string CategoryName { get; set; }

		public string CategoryCode { get; set; }

		public string CategoryDescription { get; set; }

		public string CreateBy { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		public string CategoryImagePath { get; set; }
	}
}

using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementaAPI.Models;

public partial class MultimediaFilesProduct
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public string Type { get; set; }
	public string PublicId { get; set; }
	public string SecureUrl { get; set; }
}

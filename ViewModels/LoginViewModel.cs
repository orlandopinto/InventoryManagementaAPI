namespace InventoryManagementaAPI.ViewModels
{
	public class LoginViewModel
	{
		public required Guid Id { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
	}
}

namespace InventoryManagementaAPI.Models
{
	public partial class Users
	{
		public Guid Id { get; set; }
		public string? UserName { get; set; }
		public string? NormalizedUserName { get; set; }
		public string Email { get; set; }
		public string? NormalizedEmail { get; set; }
		public bool EmailConfirmed { get; set; }
		public string PasswordHash { get; set; }
		public string? PhoneNumber { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public DateTimeOffset? LockoutEnd { get; set; }
		public bool LockoutEnabled { get; set; }
		public int AccessFailedCount { get; set; }
		public string? Address { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int? ZipCode { get; set; }
		public bool IsAdmin { get; set; }
		public string? RoleId { get; set; }
	}
}
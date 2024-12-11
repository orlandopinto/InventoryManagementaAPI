using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.ViewModels;

namespace InventoryManagementaAPI.Interfaces
{
	public interface IAccountRepository
	{
		public Task<Users> Login(LoginViewModel loginViewModel);
		public Task<bool> Register(RegisterViewModel registerViewModel);
	}
}

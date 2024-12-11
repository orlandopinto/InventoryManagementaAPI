using AutoMapper;
using InventoryManagementaAPI.Interfaces;
using InventoryManagementaAPI.Models;
using InventoryManagementaAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		protected readonly UsersContext _context;
		private readonly IMapper _mapper;

		public AccountRepository(UsersContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Users> Login(LoginViewModel loginViewModel)
		{
			Users User = new();
			try
			{
				List<Users> users = await _context.Users.ToListAsync();
				var tmpUser = users.Where(w => w.Email == loginViewModel.Email && w.PasswordHash == loginViewModel.Password).FirstOrDefault();
				User = _mapper.Map<Users>(tmpUser);
			}
			catch (Exception)
			{
				throw;
			}
			return await Task.FromResult(User);
		}

		public async Task<bool> Register(RegisterViewModel registerViewModel)
		{
			bool result;
			try
			{
				Users User = new()
				{
					Id = Guid.NewGuid().ToString(),
					Email = registerViewModel.Email,
					UserName = registerViewModel.Email,
					NormalizedEmail = registerViewModel.Email,
					NormalizedUserName = registerViewModel.Email,
					EmailConfirmed = true,
					PasswordHash = registerViewModel.Password,
					PhoneNumberConfirmed = true,
					TwoFactorEnabled = false,
					LockoutEnabled = false,
					AccessFailedCount = 0,
					IsAdmin = false
				};
				_context.Users.Add(User);
				int response = await (_context.SaveChangesAsync());
				result = response == 1;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
	}
}

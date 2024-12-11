using InventoryManagementaAPI.Models;
using Microsoft.EntityFrameworkCore;

public partial class UsersContext : DbContext
{
	public UsersContext(DbContextOptions<UsersContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Users> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Users>(entity =>
		{
			entity.Property(e => e.Address).HasMaxLength(250);
			entity.Property(e => e.Email).HasMaxLength(256);
			entity.Property(e => e.FirstName).HasMaxLength(150);
			entity.Property(e => e.LastName).HasMaxLength(150);
			entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
			entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
			entity.Property(e => e.RoleId).HasMaxLength(450);
			entity.Property(e => e.UserName).HasMaxLength(256);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
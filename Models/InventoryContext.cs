using Microsoft.EntityFrameworkCore;

namespace InventoryManagementaAPI.Models;

public partial class InventoryContext : DbContext
{
	public InventoryContext()
	{
	}

	public InventoryContext(DbContextOptions<InventoryContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Attributes> Attributes { get; set; }

	public virtual DbSet<AttributeValues> AttributeValues { get; set; }

	public virtual DbSet<Categories> Categories { get; set; }

	public virtual DbSet<SubCategories> SubCategories { get; set; }

	public virtual DbSet<Users> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Attributes>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.AttributeName).IsRequired().HasMaxLength(50);
		});

		modelBuilder.Entity<AttributeValues>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.AttributeValue).IsRequired().HasMaxLength(50).HasColumnName("AttributeValue");
		});

		modelBuilder.Entity<Categories>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK_Products");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryCode).IsRequired().HasMaxLength(7);
			entity.Property(e => e.CategoryDescription).HasMaxLength(150);
			entity.Property(e => e.CategoryImagePath).IsRequired().HasMaxLength(150);
			entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(50);
			entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);
			entity.Property(e => e.CreationDate).HasColumnType("datetime");
			entity.Property(e => e.UpdateDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<SubCategories>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
			entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);
			entity.Property(e => e.SubCategoryDescription).HasMaxLength(150);
			entity.Property(e => e.SubCategoryName).IsRequired().HasMaxLength(50);
			entity.Property(e => e.UpdateDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<Users>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Address).HasMaxLength(250);
			entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
			entity.Property(e => e.FirstName).HasMaxLength(150);
			entity.Property(e => e.LastName).HasMaxLength(150);
			entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
			entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
			entity.Property(e => e.PasswordHash).IsRequired();
			entity.Property(e => e.RoleId).HasMaxLength(450);
			entity.Property(e => e.UserName).HasMaxLength(256);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

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
	public virtual DbSet<Discounts> Discounts { get; set; }
	public virtual DbSet<MultimediaFilesProduct> MultimediaFilesProduct { get; set; }
	public virtual DbSet<Products> Products { get; set; }
	public virtual DbSet<Status> Status { get; set; }
	public virtual DbSet<SubCategories> SubCategories { get; set; }
	public virtual DbSet<Taxes> Taxes { get; set; }
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

		modelBuilder.Entity<Discounts>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.Discount).HasColumnName("Discount");
			entity.Property(e => e.DiscountDescription).IsRequired().HasMaxLength(10);
			entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(15);
			entity.Property(e => e.CreationDate).HasColumnType("datetime");
			entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			entity.Property(e => e.Active).HasDefaultValue(true);
		});

		modelBuilder.Entity<MultimediaFilesProduct>(entity =>
		{
			entity.ToTable("MultimediaFilesProduct");
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.ProductId).HasColumnName("ProductID");
			entity.Property(e => e.Type).IsRequired().HasMaxLength(10);
			entity.Property(e => e.PublicId).IsRequired().HasMaxLength(150).HasColumnName("public_id");
			entity.Property(e => e.SecureUrl).IsRequired().HasMaxLength(200).HasColumnName("secure_url");
		});

		modelBuilder.Entity<Products>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK_Products_1");
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.Active).HasDefaultValue(true);
			entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
			entity.Property(e => e.CodeBar).HasMaxLength(50);
			entity.Property(e => e.Cost).HasColumnType("decimal(6, 2)");
			entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(10);
			entity.Property(e => e.CreationDate).HasColumnType("datetime");
			entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
			entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
			entity.Property(e => e.ProductDescription).HasMaxLength(50);
			entity.Property(e => e.ProductName).IsRequired().HasMaxLength(50);
			entity.Property(e => e.Sku).HasMaxLength(20).HasColumnName("SKU");
			entity.Property(e => e.StatusId).HasColumnName("StatusID");
			entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
			entity.Property(e => e.TaxId).HasColumnName("TaxID");
			entity.Property(e => e.UpdateDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<Status>(entity =>
		{
			entity.ToTable("Status");
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.StatusDescription).IsRequired().HasMaxLength(10);
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

		modelBuilder.Entity<Taxes>(entity =>
		{
			entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
			entity.Property(e => e.CreateBy).IsRequired().HasMaxLength(50);
			entity.Property(e => e.CreationDate).HasColumnType("datetime");
			entity.Property(e => e.DateFrom).HasColumnType("datetime");
			entity.Property(e => e.DateTo).HasColumnType("datetime");
			entity.Property(e => e.Tax).HasColumnType("decimal(5, 2)");
			entity.Property(e => e.TaxDescription).IsRequired().HasMaxLength(50);
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

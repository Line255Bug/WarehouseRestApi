using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarehouseAPI
{
    public partial class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<BusinessUser> BusinessUsers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<StorageCategory> StorageCategories { get; set; } = null!;
        public virtual DbSet<SysRole> SysRoles { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;
        public virtual DbSet<WarehouseSection> WarehouseSections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Cobalt;Username=postgres;Password=Elefante2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.BsnId)
                    .HasName("business_pkey");

                entity.ToTable("business");

                entity.Property(e => e.BsnId)
                    .HasColumnName("bsn_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BsnName)
                    .HasMaxLength(50)
                    .HasColumnName("bsn_name");

                entity.Property(e => e.BsnRut)
                    .HasMaxLength(14)
                    .HasColumnName("bsn_rut");
            });

            modelBuilder.Entity<BusinessUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("business_users");

                entity.Property(e => e.BsnId).HasColumnName("bsn_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Bsn)
                    .WithMany()
                    .HasForeignKey(d => d.BsnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_business");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bsn_user");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdSku)
                    .HasName("product_pkey");

                entity.ToTable("product");

                entity.Property(e => e.ProdSku)
                    .HasMaxLength(64)
                    .HasColumnName("prod_sku");

                entity.Property(e => e.ProdDescription)
                    .HasMaxLength(200)
                    .HasColumnName("prod_description");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(30)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice)
                    .HasPrecision(10, 3)
                    .HasColumnName("prod_price");
            });

            modelBuilder.Entity<StorageCategory>(entity =>
            {
                entity.HasKey(e => e.StorCatId)
                    .HasName("storage_categories_pkey");

                entity.ToTable("storage_categories");

                entity.Property(e => e.StorCatId)
                    .HasColumnName("stor_cat_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.StorCatName)
                    .HasMaxLength(30)
                    .HasColumnName("stor_cat_name");

                entity.Property(e => e.StorCatWrhId).HasColumnName("stor_cat_wrh_id");

                entity.HasOne(d => d.StorCatWrh)
                    .WithMany(p => p.StorageCategories)
                    .HasForeignKey(d => d.StorCatWrhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_wrh_category");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("sys_role_pkey");

                entity.ToTable("sys_role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(15)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("sys_user_pkey");

                entity.ToTable("sys_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(40)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(60)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(60)
                    .HasColumnName("user_password");
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sys_user_roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WrhId)
                    .HasName("warehouse_pkey");

                entity.ToTable("warehouse");

                entity.Property(e => e.WrhId)
                    .HasColumnName("wrh_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.WrhAddress)
                    .HasMaxLength(50)
                    .HasColumnName("wrh_address");

                entity.Property(e => e.WrhAddressNum).HasColumnName("wrh_address_num");

                entity.Property(e => e.WrhCommune)
                    .HasMaxLength(50)
                    .HasColumnName("wrh_commune");

                entity.Property(e => e.WrhName)
                    .HasMaxLength(30)
                    .HasColumnName("wrh_name");

                entity.Property(e => e.WrhProvince)
                    .HasMaxLength(50)
                    .HasColumnName("wrh_province");

                entity.Property(e => e.WrhRegion)
                    .HasMaxLength(50)
                    .HasColumnName("wrh_region");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_wrh_business");
            });

            modelBuilder.Entity<WarehouseSection>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("warehouse_section_pkey");

                entity.ToTable("warehouse_section");

                entity.Property(e => e.SectionId)
                    .HasColumnName("section_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.SectionName)
                    .HasMaxLength(50)
                    .HasColumnName("section_name");

                entity.Property(e => e.SectionWrhId).HasColumnName("section_wrh_id");

                entity.HasOne(d => d.SectionWrh)
                    .WithMany(p => p.WarehouseSections)
                    .HasForeignKey(d => d.SectionWrhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_section_wrh");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

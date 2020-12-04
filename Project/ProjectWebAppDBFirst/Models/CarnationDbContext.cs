using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class CarnationDbContext : DbContext
    {
        public CarnationDbContext()
        {
        }

        public CarnationDbContext(DbContextOptions<CarnationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CustomDesign> CustomDesigns { get; set; }
        public virtual DbSet<FuturisticApproach> FuturisticApproaches { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<NewUser> NewUsers { get; set; }
        public virtual DbSet<ProductMerchant> ProductMerchants { get; set; }
        public virtual DbSet<ProductUser> ProductUsers { get; set; }
        public virtual DbSet<ServiceCenter> ServiceCenters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-96V90R7;database=CarnationDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.AdminPassword, "UQ__Admin__8B21651C7DA40B8A")
                    .IsUnique();

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("Admin_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Admin_Password");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Contact_Number");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Category1)
                    .HasName("PK__Category__4BB73C338F6C3976");

                entity.ToTable("Category");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .HasColumnName("Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Company__737584F71082EEC5");

                entity.ToTable("Company");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            });

            modelBuilder.Entity<CustomDesign>(entity =>
            {
                entity.ToTable("Custom_Design");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryType)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Type");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(50)
                    .HasColumnName("Company_Type");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.CustomDesigns)
                    .HasForeignKey(d => d.CategoryType)
                    .HasConstraintName("FK__Custom_De__Categ__5BE2A6F2");

                entity.HasOne(d => d.CompanyTypeNavigation)
                    .WithMany(p => p.CustomDesigns)
                    .HasForeignKey(d => d.CompanyType)
                    .HasConstraintName("FK__Custom_De__Compa__5AEE82B9");
            });

            modelBuilder.Entity<FuturisticApproach>(entity =>
            {
                entity.ToTable("Futuristic_Approach");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddedFeatures)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Added_Features");

                entity.Property(e => e.CategoryType)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Type");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(50)
                    .HasColumnName("Company_Type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.FuturisticApproaches)
                    .HasForeignKey(d => d.CategoryType)
                    .HasConstraintName("FK__Futuristi__Categ__5812160E");

                entity.HasOne(d => d.CompanyTypeNavigation)
                    .WithMany(p => p.FuturisticApproaches)
                    .HasForeignKey(d => d.CompanyType)
                    .HasConstraintName("FK__Futuristi__Compa__571DF1D5");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.HasIndex(e => e.LoginPassword, "UQ__Login__C0D29A3B65871B34")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .ValueGeneratedNever()
                    .HasColumnName("Login_Id");

                entity.Property(e => e.LoginPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Login_Password");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("Merchant");

                entity.HasIndex(e => e.MerchantPassword, "UQ__Merchant__46266409F45987E8")
                    .IsUnique();

                entity.Property(e => e.MerchantId)
                    .ValueGeneratedNever()
                    .HasColumnName("Merchant_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Contact_Number");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MerchantLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Merchant_Location");

                entity.Property(e => e.MerchantPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Merchant_Password");

                entity.Property(e => e.MerchantPin).HasColumnName("Merchant_PIN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NewUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__New_User__206D917054C85BDE");

                entity.ToTable("New_User");

                entity.HasIndex(e => e.UserPassword, "UQ__New_User__4525F7D829F39CC9")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Contact_Number");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserLocation)
                    .HasMaxLength(50)
                    .HasColumnName("User_Location");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPin).HasColumnName("User_PIN");
            });

            modelBuilder.Entity<ProductMerchant>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Product___9834FBBA3F251A00");

                entity.ToTable("Product_Merchant");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.BrakesType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Brakes_Type");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CentralLocking)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Central_Locking");

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DateOfManufacturing)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Manufacturing");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EngineType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Engine_Type");

                entity.Property(e => e.MerchantId).HasColumnName("Merchant_Id");

                entity.Property(e => e.MileageKmpl).HasColumnName("Mileage_Kmpl");

                entity.Property(e => e.ModelNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Model_Number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RearSuspension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Rear_Suspension");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ProductMerchants)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Product_M__Categ__4F7CD00D");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.ProductMerchants)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("FK__Product_M__Compa__4E88ABD4");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.ProductMerchants)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("FK__Product_M__Merch__4D94879B");
            });

            modelBuilder.Entity<ProductUser>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Product___9834FBBA341CF0EE");

                entity.ToTable("Product_User");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.BrakesType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Brakes_Type");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CentralLocking)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Central_Locking");

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DateOfManufacturing)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Manufacturing");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EngineType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Engine_Type");

                entity.Property(e => e.MileageKmpl).HasColumnName("Mileage_Kmpl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RearSuspension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Rear_Suspension");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ProductUsers)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Product_U__Categ__4AB81AF0");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.ProductUsers)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("FK__Product_U__Compa__49C3F6B7");
            });

            modelBuilder.Entity<ServiceCenter>(entity =>
            {
                entity.ToTable("Service_Center");

                entity.Property(e => e.ServiceCenterId)
                    .ValueGeneratedNever()
                    .HasColumnName("Service_Center_Id");

                entity.Property(e => e.CategoryType)
                    .HasMaxLength(50)
                    .HasColumnName("Category_Type");

                entity.Property(e => e.CertifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Certified_By");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(50)
                    .HasColumnName("Company_Type");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Contact_Number");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Timings).HasMaxLength(20);

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.ServiceCenters)
                    .HasForeignKey(d => d.CategoryType)
                    .HasConstraintName("FK__Service_C__Categ__534D60F1");

                entity.HasOne(d => d.CompanyTypeNavigation)
                    .WithMany(p => p.ServiceCenters)
                    .HasForeignKey(d => d.CompanyType)
                    .HasConstraintName("FK__Service_C__Compa__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

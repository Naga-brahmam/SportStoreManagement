using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportshopManagementSystem.Models
{
    public partial class Sports_ShopContext : DbContext
    {
        public Sports_ShopContext()
        {
        }

        public Sports_ShopContext(DbContextOptions<Sports_ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerManagementModule> CustomerManagementModule { get; set; }
        public virtual DbSet<ItemManagementModule> ItemManagementModule { get; set; }
        public virtual DbSet<OrderModule> OrderModule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-077TIHH4;Initial Catalog=Sports_Shop;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerManagementModule>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64D88242784B");

                entity.ToTable("Customer_Management_Module");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasColumnName("Email_Id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(20, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemManagementModule>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Item_Man__3FB5087446A0779B");

                entity.ToTable("Item_Management_Module");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Size)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderModule>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_Mo__46466601718BCE43");

                entity.ToTable("Order_Module");

                entity.Property(e => e.OrderId).HasColumnName("order_Id");

                entity.Property(e => e.DelivaryDate).HasColumnType("date");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderModule)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order_Mod__Custo__4222D4EF");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderModule)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Order_Mod__Item___4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

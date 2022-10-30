using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infosys.TravelAway.DAL.Models
{
    public partial class TravelAwayDBContext : DbContext
    {
        public TravelAwayDBContext()
        {
        }

        public TravelAwayDBContext(DbContextOptions<TravelAwayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<PackageCategories> PackageCategories { get; set; }
        public virtual DbSet<PackageDetails> PackageDetails { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TravelAwayDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B83E5656E0");

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Customer__7ED91ACEE6E51ECA")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PackageDetailsId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SysDateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.SysLastLogin).HasColumnType("datetime");

                entity.Property(e => e.SysLogoutTime).HasColumnType("datetime");

                entity.HasOne(d => d.PackageDetails)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PackageDetailsId)
                    .HasConstraintName("FK__Customers__Packa__34C8D9D1");
            });

            modelBuilder.Entity<PackageCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__PackageC__19093A0B7ACCFC6B");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__PackageC__8517B2E05D7576C5")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageDetails>(entity =>
            {
                entity.Property(e => e.PackageDetailsId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Accommodation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DaysAndNight)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PackageDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PlacesToVisit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PackageDe__Packa__2D27B809");
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK__Packages__322035CC5A189E6E");

                entity.HasIndex(e => e.PackageAvatar)
                    .HasName("UQ__Packages__AA7FC7A763959A45")
                    .IsUnique();

                entity.Property(e => e.PackageId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PackageAvatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfPackage)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Packages__Catego__29572725");
            });

            modelBuilder.HasSequence("CustomerSequence").StartsAt(1000);

            modelBuilder.HasSequence("PackageCategoriesSequence").StartsAt(100);

            modelBuilder.HasSequence("PackageDetailsSequence").StartsAt(1000);

            modelBuilder.HasSequence("PackageSequence").StartsAt(1000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

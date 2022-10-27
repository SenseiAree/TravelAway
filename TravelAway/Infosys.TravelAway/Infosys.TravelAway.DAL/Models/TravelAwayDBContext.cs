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
                    .HasName("PK__Customer__A4AE64B829C813BC");

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Customer__7ED91ACE66931CA3")
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

                entity.Property(e => e.SysDateOfJoining)
                    .HasColumnName("Sys_DateOfJoining")
                    .HasColumnType("datetime");

                entity.Property(e => e.SysLastLogin)
                    .HasColumnName("Sys_LastLogin")
                    .HasColumnType("date");

                entity.Property(e => e.SysLogoutTime)
                    .HasColumnName("Sys_LogoutTime")
                    .HasColumnType("date");

                entity.HasOne(d => d.PackageDetails)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PackageDetailsId)
                    .HasConstraintName("FK__Customers__Packa__33D4B598");
            });

            modelBuilder.Entity<PackageCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__PackageC__19093A0B1E791510");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__PackageC__8517B2E058958843")
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
                    .HasConstraintName("FK__PackageDe__Packa__2C3393D0");
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK__Packages__322035CC33EAF522");

                entity.Property(e => e.PackageId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(5)
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
                    .HasConstraintName("FK__Packages__Catego__286302EC");
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

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiComicTienda.Models
{
    public partial class DBComicTiendaContext : DbContext
    {
        public DBComicTiendaContext()
        {
        }

        public DBComicTiendaContext(DbContextOptions<DBComicTiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Comic> Comics { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<SalesDetail> SalesDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BTLG386;Initial Catalog=DBComicTienda;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.AccountName, "UQ__Account__406E0D2E85F888B5")
                    .IsUnique();

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordData)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comic>(entity =>
            {
                entity.Property(e => e.ComicId).ValueGeneratedNever();

                entity.Property(e => e.ComicName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Franchise)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateIssued).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Receipts)
                    .HasPrincipalKey(p => p.AccountName)
                    .HasForeignKey(d => d.Account)
                    .HasConstraintName("FK__Receipt__Account__4222D4EF");
            });

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.ToTable("SalesDetail");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Comic)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.ComicId)
                    .HasConstraintName("FK__SalesDeta__Comic__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

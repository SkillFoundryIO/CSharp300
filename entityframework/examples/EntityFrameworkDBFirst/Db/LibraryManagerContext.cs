using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDBFirst.Db;

public partial class LibraryManagerContext : DbContext
{
    public LibraryManagerContext()
    {
    }

    public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<CheckoutLog> CheckoutLogs { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LibraryManager;User Id=sa;Password=SQLR0ck$;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("PK__Borrower__568EDB771832191F");

            entity.ToTable("Borrower");

            entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(15);
            entity.Property(e => e.Phone).HasMaxLength(10);
        });

        modelBuilder.Entity<CheckoutLog>(entity =>
        {
            entity.HasKey(e => e.CheckoutLogId).HasName("PK__Checkout__09FC3C95159C778F");

            entity.ToTable("CheckoutLog");

            entity.Property(e => e.CheckoutLogId).HasColumnName("CheckoutLogID");
            entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");
            entity.Property(e => e.MediaId).HasColumnName("MediaID");

            entity.HasOne(d => d.Borrower).WithMany(p => p.CheckoutLogs)
                .HasForeignKey(d => d.BorrowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckoutL__Borro__2C3393D0");

            entity.HasOne(d => d.Media).WithMany(p => p.CheckoutLogs)
                .HasForeignKey(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckoutL__Media__2D27B809");
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.MediaTypeId).HasName("PK__MediaTyp__0E6FCB927E1A7942");

            entity.ToTable("MediaType");

            entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");
            entity.Property(e => e.MediaTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5AF8888D3D2");

            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.MediaType).WithMany(p => p.Media)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Media__MediaType__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

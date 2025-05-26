using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB_two.Models;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCheckout> BookCheckouts { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibraryDB;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07F374B046");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07607D3F07");

            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Books__AuthorId__403A8C7D");
        });

        modelBuilder.Entity<BookCheckout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookChec__3214EC074365B9FA");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCheckouts)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookCheck__BookI__47DBAE45");

            entity.HasOne(d => d.Member).WithMany(p => p.BookCheckouts)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__BookCheck__Membe__48CFD27E");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC077EE3F0C3");

            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

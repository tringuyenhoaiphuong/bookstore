using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.Models
{
    public partial class AppDataContext : DbContext
    {
        public AppDataContext()
        {
        }

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Categorybook> Categorybook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=greenbookstore");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DiscountedPrice)
                    .HasColumnName("discountedPrice")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Categorybook>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.CategoryId })
                    .HasName("PRIMARY");

                entity.ToTable("categorybook");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_CategoryBook_Category");

                entity.Property(e => e.BookId)
                    .HasColumnName("bookId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Categorybook)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_CategoryBook_Book");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Categorybook)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CategoryBook_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NewsApiREST.Models;

#nullable disable

namespace NewsApiREST.Data
{
    public partial class NewsProjectDBContext : DbContext
    {
        public NewsProjectDBContext()
        {
        }

        public NewsProjectDBContext(DbContextOptions<NewsProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<State> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewsProjectDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleId).ValueGeneratedNever();

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.CountryCode).IsUnicode(false);

                entity.Property(e => e.ImageAt).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Articles__Catego__47DBAE45");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__Articles__Countr__46E78A0C");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK__Articles__idAuth__45F365D3");

                entity.HasOne(d => d.IdSourceNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdSource)
                    .HasConstraintName("FK__Articles__IdSour__48CFD27E");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Articles__idStat__49C3F6B7");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PK__authors__5EE9536DBD8DA571");

                entity.Property(e => e.IdAuthor).ValueGeneratedNever();

                entity.Property(e => e.IdCountry).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK__authors__idCount__4222D4EF");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__authors__idState__4316F928");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__79D361B60159404D");

                entity.Property(e => e.IdCategory).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).IsUnicode(false);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Categorie__idSta__29572725");
            });
           
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Countrie__357D4CF8C399B464");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CountryName).IsUnicode(false);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Countries__idSta__3F466844");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.IdSource)
                    .HasName("PK__Sources__574D7FE3754ACF30");

                entity.Property(e => e.IdSource).ValueGeneratedNever();

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Sources)
                    .HasForeignKey(d => d.IdState)
                    .HasConstraintName("FK__Sources__idState__2C3393D0");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__State__98CB3723932A7BE7");

                entity.Property(e => e.IdState).ValueGeneratedNever();

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

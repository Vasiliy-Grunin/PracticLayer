using DAL.Entitys.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) => Database.Migrate();

        public LibraryDbContext()
        {
        }

        public virtual DbSet<PeopleModel> Peoples { get; set; }

        public virtual DbSet<BookModel> Books { get; set; }

        public virtual DbSet<GenryModel> Genries { get; set; }

        public virtual DbSet<AuthorModel> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleModel>()
                .HasMany<BookModel>(b => b.Books)
                .WithOne()
                .IsRequired();

            modelBuilder.Entity<GenryModel>()
                .HasMany<BookModel>(s => s.Books)
                .WithMany(x=>x.Genre);

            modelBuilder.Entity<AuthorModel>()
                .HasMany<BookModel>(b => b.Books)
                .WithOne()
                .IsRequired();

            modelBuilder.Entity<BookModel>()
                .HasOne<AuthorModel>(x => x.Author)
                .WithMany(x => x.Books);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using DAL.Entitys.Model;
using DAL.Entitys.Model.Inheritance;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) => Database.Migrate();


        public DbSet<PeopleModel> Peoples { get; set; }

        public DbSet<BookModel> Books { get; set; }

        public DbSet<GenryModel> Genries { get; set; }

        public DbSet<AuthorModel> Authors { get; set; }

        public DbSet<AuthorInheritance> AuthorInheritances { get; set; }

        public DbSet<BookInheritance> BookInheritances { get; set; }

        public DbSet<GenryInheritance> GenryInheritances { get; set; }

        public DbSet<PeopleInheritance> PeopleInheritances { get; set; }

        public void AddCascadingObject(object rootEntity)
        {
            ChangeTracker.TrackGraph(
                rootEntity,
                node =>
                    node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleModel>()
                .HasDiscriminator()
                .IsComplete(false);

            modelBuilder.Entity<AuthorModel>()
                .HasDiscriminator()
                .IsComplete(false);

            modelBuilder.Entity<GenryModel>()
                .HasDiscriminator()
                .IsComplete(false);

            modelBuilder.Entity<BookModel>()
                .HasDiscriminator()
                .IsComplete(false);

            modelBuilder.Entity<PeopleModel>()
                .HasMany<BookModel>(a => a.Books)
                .WithMany(c => c.Master);

            modelBuilder.Entity<BookModel>()
                .HasOne<AuthorModel>(s=>s.Author)
                .WithMany(c=>c.Books);

            modelBuilder.Entity<GenryModel>()
                .HasMany<BookModel>(b => b.Books)
                .WithMany(c=>c.Genre);

            modelBuilder.Entity<AuthorModel>()
                .HasMany<BookModel>(b => b.Books)
                .WithOne(c=>c.Author);

            base.OnModelCreating(modelBuilder);
        }
    }
}


using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Note
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Note>().HasKey(e => e.Id);
            modelBuilder.Entity<Note>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Note>()
               .Property(e => e.Content)
               .HasMaxLength(2000);
            modelBuilder.Entity<Note>()
                .HasOne(e => e.Detail)
                .WithOne(x => x.Note)
                .HasForeignKey<NoteDetail>(nd => nd.NoteId);
            modelBuilder.Entity<Note>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.CategoryId);
            #endregion

            #region Category
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region NoteDetails
            modelBuilder.Entity<NoteDetail>().ToTable("NoteDetails");
            modelBuilder.Entity<NoteDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<NoteDetail>()
                .Property(c => c.Created)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<NoteDetail>()
                .Property(x => x.LastModified)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();

            #endregion

        }
    }
}

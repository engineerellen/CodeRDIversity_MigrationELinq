using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AnimalContext: DbContext
    {
        public DbSet<Animal> Animais { get; set; }  


        public AnimalContext(DbContextOptions<AnimalContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<Animal>()
                .Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Animal>()
             .Property(a => a.Raça)
             .HasMaxLength(100);
        }

    }
}

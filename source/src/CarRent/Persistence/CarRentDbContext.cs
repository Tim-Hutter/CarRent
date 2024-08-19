namespace CarRent.Persistence
{
    using CarRent.Common.Domain;
    using CarRent.Feature.Cars.Infrastructure;

    using Microsoft.EntityFrameworkCore;

    public class CarRentDbContext : DbContext, IUnitOfWork
    {
        public CarRentDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());

            // Autoregistration
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public int CommitChanges()
        {
            return SaveChanges();
        }
    }
}

using doctorly.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Persistence
{
    public class DoctorlyContext : DbContext
    {
        public DoctorlyContext(DbContextOptions options)
    : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Attendee> Attendees { get; set; }
        
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("data");

            var currentAssembly = typeof(DoctorlyContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using doctorly.Persistence.Models;

namespace doctorly.Persistence.Configurations
{
    public class AttendeeConfigurations : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(attendee => attendee.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(attendee => attendee.Email).IsUnique();
            builder.Property(attendee => attendee.Email).HasMaxLength(50).IsRequired();

            builder.Property(attendee => attendee.isAttending).HasDefaultValue(false);
        }
    }
}

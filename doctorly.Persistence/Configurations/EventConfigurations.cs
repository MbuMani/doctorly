using doctorly.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Persistence.Configurations
{
    public class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(eventModel => eventModel.Title).HasMaxLength(50).IsRequired();

            builder.Property(eventModel => eventModel.StartTime).HasColumnType("datetime");

            builder.Property(eventModel => eventModel.EndTime).HasColumnType("datetime");
        }
    }
}

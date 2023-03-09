using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class PassengerConfiguration: IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, f =>
            {
                f.Property(h => h.FirstName).IsRequired().HasMaxLength(30);
                f.Property(h => h.lastName).IsRequired().HasMaxLength(30).HasColumnName("LastName");
            });
       //     builder.HasDiscriminator<int>("type").HasValue<Passenger>(0).HasValue<Staff>(1).HasValue<Traveller>(2);
        }
    }
}

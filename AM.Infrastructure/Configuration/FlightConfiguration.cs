using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    internal class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.flightId);
            builder.ToTable("MyFlight");
            builder.Property(f => f.departure).IsRequired().HasMaxLength(100).HasDefaultValue("TOUNES").HasColumnType("nchar");
            builder.HasOne(a=>a.plane).WithMany(b=>b.flights).HasForeignKey(f => f.PlaneFk).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(b => b.passengers).WithMany(a => a.flights).UsingEntity(a => a.ToTable("MyReservation"));
        }
    }
}

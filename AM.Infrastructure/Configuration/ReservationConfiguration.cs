using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(t => new { t.SeatFK, t.PassengerFK,t.DateReservation });
            builder.HasOne(p => p.Passenger).WithMany(m => m.Reservations).HasForeignKey(t => t.PassengerFK);
            builder.HasOne(p => p.Seat).WithMany(m=>m.Reservations).HasForeignKey(t=>t.SeatFK);
        }
    }
}

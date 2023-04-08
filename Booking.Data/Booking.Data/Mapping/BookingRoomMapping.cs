using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Mapping
{
    public class BookingRoomMapping : IEntityTypeConfiguration<BookingRoom>
    {
        public void Configure(EntityTypeBuilder<BookingRoom> builder)
        {
            builder.HasOne(x => x.Room).WithMany(x => x.Bookings).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.Client).WithMany(x => x.Bookings).HasForeignKey(x => x.ClientId);

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Start).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.End).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}

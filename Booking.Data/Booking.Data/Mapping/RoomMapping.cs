using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Mapping
{
    public class RoomMapping : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Available).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            
            builder.HasKey(x => x.Id);
        }
    }
}

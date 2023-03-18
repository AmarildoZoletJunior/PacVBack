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
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.OwnsOne(x => x.PersonType).Property(x => x.Surname).IsRequired();
            builder.OwnsOne(x => x.PersonType).Property(x => x.DocumentNumber).IsRequired();
            builder.OwnsOne(x => x.PersonType).Property(x => x.Name).IsRequired();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();


            builder.HasKey(x => x.Id);

        }
    }
}

using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Data.Mapping
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(X => X.Cliente).WithMany(x => x.Payments).HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

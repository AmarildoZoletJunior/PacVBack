using Booking.Data.Repositories;
using Booking.Domain.Ports;

namespace Booking.API.Ioc
{
    public static class BookingExtensions
    {
        public static IServiceCollection InjectionsExtensions(this IServiceCollection services)
        {
            services.AddScoped<IBookingRoomRepository,BookingRoomRepository>();

            return services;
        }
    }
}

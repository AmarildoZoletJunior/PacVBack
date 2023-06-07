using AutoMapper;
using Booking.Application.DTOs.ClientDTO;
using Booking.Application.DTOs.ImageDTO;
using Booking.Application.DTOs.PaymentDTO;
using Booking.Application.DTOs.RoomDTO;
using Booking.Domain.Entities;

namespace Booking.Application.Mapper
{
    public class MapperToDTO : Profile
    {
        public MapperToDTO() 
        {
            CreateMap<Client, ClientResponse>().ForMember(x => x.Surname, map => map.MapFrom(x => x.PersonType.Surname))
                            .ForMember(x => x.Name, map => map.MapFrom(x => x.PersonType.Name))
                            .ForMember(x => x.Phone, map => map.MapFrom(x => x.PersonType.Phone))
            .ForMember(x => x.DocumentNumber, map => map.MapFrom(x => x.PersonType.DocumentNumber))
            .ForMember(x => x.Email, map => map.MapFrom(x => x.Email));


            CreateMap<Room, RoomResponse>();
            CreateMap<Room, RoomResponseWithImage>();

            CreateMap<Image, ImageResponse>();

            CreateMap<Payment, PaymentResponse>();


        }
    }
}

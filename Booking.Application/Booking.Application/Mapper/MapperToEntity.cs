using AutoMapper;
using Booking.Application.DTOs.AuthDTO;
using Booking.Application.DTOs.BookingRoomDTO;
using Booking.Application.DTOs.ClientDTO;
using Booking.Application.DTOs.PaymentDTO;
using Booking.Application.DTOs.RoomDTO;
using Booking.Domain.Entities;
using Booking.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Mapper
{
    public class MapperToEntity : Profile
    {
        public MapperToEntity() 
        {
            CreateMap<ClientRequest, Client>()
                .ForMember(x => x.PersonType, map => map.MapFrom(x => new PersonInfo { DocumentNumber = x.DocumentNumber, Surname = x.Surname, Name = x.Name, Phone = x.Phone }));

            CreateMap<ClientUpdateRequest, Client>()
                .ForMember(x => x.PersonType, map => map.MapFrom(x => new PersonInfo { DocumentNumber = "123", Surname = x.Surname, Name = x.Name, Phone = "123" }));

            CreateMap<ClientPasswordRequest, Client>();

            CreateMap<AuthRequest, Client>();

            CreateMap<RoomRequest, Room>();
            CreateMap<RoomUpdateRequest, Room>();

            CreateMap<BookingRoomRequest, BookingRoom>();
            CreateMap<PaymentRequest, Payment>();
        }
    }
}

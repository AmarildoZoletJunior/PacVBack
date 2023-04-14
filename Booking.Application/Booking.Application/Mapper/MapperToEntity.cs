using AutoMapper;
using Booking.Application.DTOs.AuthDTO;
using Booking.Application.DTOs.ClientDTO;
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
                .ForMember(x => x.PersonType, map => map.MapFrom(x => new PersonInfo { DocumentNumber = x.DocumentNumber, Surname = x.Surname, Name = x.Name }));

            CreateMap<AuthRequest, Client>();
        }
    }
}

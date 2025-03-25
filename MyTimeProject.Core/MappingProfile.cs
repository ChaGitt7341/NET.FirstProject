using AutoMapper;
using MyTimeProject.Core.DTOs;
using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Presence, PresenceDto>().ReverseMap();
            CreateMap<Approvals, ApprovalsDto>().ReverseMap();
        }

    }
}

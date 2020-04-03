using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilProjektarbete.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationModel, User>().ForMember(u => u.UserName, r => r.MapFrom(o => o.Email));
        }
    }
}

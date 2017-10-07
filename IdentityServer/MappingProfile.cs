using AutoMapper;
using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
            : this(string.Empty)
        {
        }

        public MappingProfile(string profileName) 
            : base(profileName)
        {
            CreateMap<AspNetUser, UserModel>()
                .ReverseMap();
        }
    }
}

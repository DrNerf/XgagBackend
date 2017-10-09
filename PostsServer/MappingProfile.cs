using AutoMapper;
using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsServer
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostModel>()
                .ForMember(m => m.ImageUrl, (m) => 
                {
                    
                });
        }
    }
}

using AutoMapper;
using Common;
using DAL;

namespace PostsServer
{
    internal class MappingProfile : Profile
    {
        public static string PostsServerAddress;

        public MappingProfile()
        {
            CreateMap<Post, PostModel>()
                .ForMember(
                    m => m.ImageUrl,
                    m => m.MapFrom(p => $"{PostsServerAddress}/api/Posts/{p.ImageImageId}.jpg"))
                .ForMember(m => m.DateCreatedTicks, m => m.MapFrom(p => p.DateCreated.Ticks));
        }
    }
}

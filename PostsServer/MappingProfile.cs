using AutoMapper;
using Common;
using DAL;
using System.Linq;

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
                .ForMember(m => m.DateCreatedTicks, m => m.MapFrom(p => p.DateCreated.Ticks))
                .ForMember(m => m.IsYoutubePost, m => m.MapFrom(p => p.ImageImage == null))
                .ForMember(m => m.Score, m => m.MapFrom(p => p.Votes.Sum(v => v.Type)));
        }
    }
}

using AutoMapper;
using Common;
using DAL;
using System;
using System.Linq;

namespace PostsServer
{
    internal class MappingProfile : Profile
    {
        public static string PostsServerAddress;

        public MappingProfile()
        {
            CommonMappingProfile.AddIdentityMaps(this);

            CreateMap<Post, PostModel>()
                .ForMember(
                    m => m.ImageUrl,
                    m => m.MapFrom(p => $"{PostsServerAddress}/api/Images/{p.ImageImageId}.jpg"))
                .ForMember(
                    m => m.DateCreatedTicks,
                    m => m.MapFrom(p => p.DateCreated.GetJSTimeStamp()))
                .ForMember(
                    m => m.IsYoutubePost,
                    m => m.MapFrom(p => p.ImageImage == null))
                .ForMember(
                    m => m.Score,
                    m => m.MapFrom(p => p.Votes.Sum(v => v.Type)))
                .ForMember(
                    m => m.CommentsCount,
                    m => m.MapFrom(p => p.Comments.Count()))
                .ForMember(
                    m => m.HasNewComments,
                    m => m.MapFrom(p => p.Comments.Any(c => c.DateTimePosted.Date == DateTime.Now.Date)));

            CreateMap<Comment, CommentModel>()
                .ForMember(
                    m => m.DateTimePostedTicks, 
                    m => m.MapFrom(c => c.DateTimePosted.GetJSTimeStamp()))
                .ForMember(
                    m => m.SubComments,
                    m => m.MapFrom(c => c.InverseParentComment));

            CreateMap<Post, PostRichModel>();
        }
    }
}

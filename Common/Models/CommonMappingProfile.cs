using AutoMapper;
using DAL;

namespace Common
{
    public static class CommonMappingProfile
    {
        public static void AddIdentityMaps(Profile profile)
        {
            profile.CreateMap<AspNetUser, UserModel>()
                .ReverseMap();
        }
    }
}

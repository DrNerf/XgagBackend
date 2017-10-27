using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    internal class StatsService : ServiceBase<Post>, IStatsService
    {
        private readonly int m_TopStatsCount;
        private readonly IRepository<AspNetUser> m_UsersRepository;

        public StatsService(
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IRepository<AspNetUser> usersRepository) 
            : base(serviceProvider)
        {
            m_TopStatsCount = configuration.GetValue<int>("TopStatsCount");
            m_UsersRepository = usersRepository;
        }

        public IEnumerable<Contributor> GetTopContributors()
        {
            try
            {
                return m_UsersRepository.Get()
                    .Include(u => u.Posts)
                    .OrderByDescending(u => u.Posts.Count())
                    .Take(m_TopStatsCount)
                    .ToList()
                    .Select(u => new Contributor()
                    {
                        PostsCount = u.Posts.Count(),
                        User = Mapper.Map<UserModel>(u)
                    });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Could not retrieve top contributors.");
                return Enumerable.Empty<Contributor>();
            }
        }

        public IEnumerable<PostModel> GetTopPosts()
        {
            try
            {
                var topPosts = Repository.Get()
                        .Include(p => p.Votes)
                        .OrderByDescending(p => p.Votes.Sum(v => v.Type))
                        .Take(m_TopStatsCount)
                        .ToList();

                return Mapper.Map<IEnumerable<PostModel>>(topPosts);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Could not retrieve top posts.");
                return Enumerable.Empty<PostModel>();
            }
        }
    }
}

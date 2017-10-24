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
    internal class PostsService : ServiceBase<Post>, IPostsService
    {
        private int m_PageSize;

        public PostsService(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
            : base(serviceProvider)
        {
            m_PageSize = configuration.GetValue<int>("PostsPageSize");
        }

        public IEnumerable<PostModel> GetPostsByPage(int page)
        {
            try
            {
                var result = Repository.GetAll()
                        .Include(p => p.ImageImage)
                        .Include(p => p.Votes)
                        .Include(p => p.Comments)
                        .OrderByDescending(p => p.DateCreated)
                        .Skip(m_PageSize * (page - 1))
                        .Take(m_PageSize);

                return Mapper.Map<IList<PostModel>>(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Could not retrieve posts for page: {page}.");
                return Enumerable.Empty<PostModel>();
            }
        }
    }
}

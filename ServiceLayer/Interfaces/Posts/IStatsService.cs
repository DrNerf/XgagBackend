using Common;
using System.Collections;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IStatsService : IServiceBase
    {
        IEnumerable<Contributor> GetTopContributors();

        IEnumerable<PostModel> GetTopPosts();
    }
}

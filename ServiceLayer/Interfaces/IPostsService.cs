using Common;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IPostsService : IServiceBase
    {
        IEnumerable<PostModel> GetPostsByPage(int page);
    }
}

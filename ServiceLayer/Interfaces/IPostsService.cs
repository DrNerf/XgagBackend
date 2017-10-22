using Common;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IPostsService
    {
        IEnumerable<PostModel> GetPostsByPage(int page);
    }
}

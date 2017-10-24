using Common;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IPostsService : IServiceBase
    {
        IEnumerable<PostModel> GetByPage(int page);

        PostRichModel GetById(int id);
    }
}

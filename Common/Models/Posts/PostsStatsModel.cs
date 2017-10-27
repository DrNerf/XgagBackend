using System.Collections.Generic;

namespace Common
{
    public class PostsStatsModel
    {
        public IEnumerable<Contributor> TopContributers { get; set; }

        public IEnumerable<PostModel> TopPosts { get; set; }
    }
}

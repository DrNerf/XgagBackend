using System.Collections.Generic;

namespace Common
{
    public class PostsStatsModel
    {
        public IEnumerable<Contributor> TopContributors { get; set; }

        public IEnumerable<PostModel> TopPosts { get; set; }
    }
}

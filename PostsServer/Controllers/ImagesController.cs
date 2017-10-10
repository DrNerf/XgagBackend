using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PostsServer
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class ImagesController : Controller
    {
        private readonly XgagDbContext m_DbContext;

        public ImagesController(XgagDbContext dbContext)
        {
            m_DbContext = dbContext;
        }

        [HttpGet("{id}.jpg")]
        public IActionResult Index([FromRoute]int id)
        {
            var image = m_DbContext.Images
                .SingleOrDefault(i => i.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return File(image.Data, "image/jpeg", string.Format("{0}.jpeg", id));
        }
    }
}
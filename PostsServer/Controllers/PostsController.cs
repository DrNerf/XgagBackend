using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ServiceLayer;

namespace PostsServer
{
    [Produces("application/json")]
    [Route("api/Posts")]
    //[ServiceFilter(typeof(AuthorizeAttribute))]
    public class PostsController : Controller
    {
        private readonly IPostsService m_PostsService;

        public PostsController(
            IPostsService postsService)
        {
            m_PostsService = postsService;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<PostModel> GetPosts(
            [FromQuery]int page = 1)
        {
            return m_PostsService.GetPostsByPage(page);
        }

        // GET: api/Posts/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPost(
        //    [FromRoute] int id,
        //    [FromHeader]string SessionToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var post = await m_Context.Posts
        //        .Include(p => p.ImageImage)
        //        .Include(p => p.Votes)
        //        .SingleOrDefaultAsync(m => m.PostId == id);

        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(m_Mapper.Map<PostModel>(post));
        //}

        //// PUT: api/Posts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPost(
        //    [FromRoute] int id,
        //    [FromBody] Post post,
        //    [FromHeader]string SessionToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != post.PostId)
        //    {
        //        return BadRequest();
        //    }

        //    m_Context.Entry(post).State = EntityState.Modified;

        //    try
        //    {
        //        await m_Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Posts
        //[HttpPost]
        //public async Task<IActionResult> PostPost(
        //    [FromBody] Post post,
        //    [FromHeader]string SessionToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    m_Context.Posts.Add(post);
        //    await m_Context.SaveChangesAsync();

        //    return CreatedAtAction("GetPost", new { id = post.PostId }, post);
        //}

        //// DELETE: api/Posts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePost(
        //    [FromRoute] int id,
        //    [FromHeader]string SessionToken)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var post = await m_Context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    m_Context.Posts.Remove(post);
        //    await m_Context.SaveChangesAsync();

        //    return Ok(m_Mapper.Map<PostModel>(post));
        //}
    }
}
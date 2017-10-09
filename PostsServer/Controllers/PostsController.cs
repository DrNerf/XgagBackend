﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PostsServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    //[ServiceFilter(typeof(AuthorizeAttribute))]
    public class PostsController : Controller
    {
        private readonly XgagDbContext m_Context;
        private readonly IConfiguration m_Configuration;
        private readonly int m_PageSize;

        public PostsController(
            XgagDbContext context,
            IConfiguration configuration)
        {
            m_Context = context;
            m_Configuration = configuration;
            m_PageSize = m_Configuration.GetValue<int>("PostsPageSize");
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts(
            [FromHeader]string SessionToken,
            [FromQuery]int page = 1)
        {
            return m_Context.Posts
                .OrderByDescending(p => p.DateCreated)
                .Skip(m_PageSize * (page - 1))
                .Take(m_PageSize)
                .ToList();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(
            [FromRoute] int id,
            [FromHeader]string SessionToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await m_Context.Posts.SingleOrDefaultAsync(m => m.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(
            [FromRoute] int id,
            [FromBody] Post post,
            [FromHeader]string SessionToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            m_Context.Entry(post).State = EntityState.Modified;

            try
            {
                await m_Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<IActionResult> PostPost(
            [FromBody] Post post,
            [FromHeader]string SessionToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            m_Context.Posts.Add(post);
            await m_Context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(
            [FromRoute] int id,
            [FromHeader]string SessionToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await m_Context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            m_Context.Posts.Remove(post);
            await m_Context.SaveChangesAsync();

            return Ok(post);
        }

        private bool PostExists(int id)
        {
            return m_Context.Posts.Any(e => e.PostId == id);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                m_Context.Dispose();
            }
        }
    }
}
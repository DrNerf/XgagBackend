using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Common;

namespace PostsServer
{
    [Produces("application/json")]
    [Route("api/Stats")]
    public class StatsController : Controller
    {
        private readonly IStatsService m_StatsService;

        public StatsController(IStatsService statsService)
        {
            m_StatsService = statsService;
        }

        // GET: api/Stats
        [HttpGet]
        [Produces(typeof(PostsStatsModel))]
        public IActionResult Get()
        {
            var model = new PostsStatsModel();
            model.TopPosts = m_StatsService.GetTopPosts();
            model.TopContributers = m_StatsService.GetTopContributors();

            return Ok(model);
        }

        // GET: api/Stats/5
        [HttpGet("{id}", Name = "Get")]
        [NonAction]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Stats
        [HttpPost]
        [NonAction]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Stats/5
        [HttpPut("{id}")]
        [NonAction]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [NonAction]
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                m_StatsService.Dispose();
            }
        }
    }
}

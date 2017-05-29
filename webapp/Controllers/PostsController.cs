using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers
{
    [Route("Posts")]
    public class PostsController : Controller
    {
        private readonly PostRepository postRepository;
        public PostsController()
        {
            postRepository = new PostRepository();
        }


        public IActionResult Index()
        {
            var posts = postRepository.GetAll();
            return View(posts);
        }


        [HttpGet("{id}")]
        public Post Detail(int id)
        {
            return postRepository.GetByID(id);
        }


        [HttpGet("New")]
        public IActionResult New()
        {
            // not sure what goes here
            return View();
        }


        [HttpPost]
        public void Create([FromBody]Post post)
        {
            if (ModelState.IsValid)
                postRepository.Add(post);
        }


        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Post post)
        {
            post.id = id;
            if (ModelState.IsValid)
                postRepository.Update(post);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            postRepository.Delete(id);
        }
    }
}
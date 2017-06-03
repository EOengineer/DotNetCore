using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers
{
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly PostRepository postRepository;
        public PostsController()
        {
            postRepository = new PostRepository();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var posts = postRepository.Index();
            return View(posts);
        }


        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var post = postRepository.Details(id);

            if (id == null)
            {
                return NotFound();
            }

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpGet("Create")]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("title,body")] Post post)
        {
            

            if (ModelState.IsValid)
            {
                postRepository.Create(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
            
        }


        [HttpGet("{id:int}/[action]")]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = postRepository.Details(id);

            if (postRepository == null)
            {
                return NotFound();
            }

            return View(post);
        }


        [HttpPost("{id:int}/[action]"), ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                postRepository.Update(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //postRepository.Delete(id);
        }
    }
}
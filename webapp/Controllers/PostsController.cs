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
        public IActionResult Details(int? id)
        {
            //var post = postRepository.Details(id);
            return View();
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
                //postRepository.Create(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm]Post post)
        {
            post.id = id;
            if (ModelState.IsValid)
            {
                //postRepository.Update(post);
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
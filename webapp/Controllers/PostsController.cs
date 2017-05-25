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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }
    }
}
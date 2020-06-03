using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentsApplication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentsApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Boromir ",
                    Text = "One does not simply walk into Mordor!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Smeagol",
                    Text = "My precious!"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Legolas",
                    Text = "They're taking the hobbits to Isengard!"
                },
            };
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PartialAddComment(Comment comment)
		{
			Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var blogıd = c.Blogs.Where(x => x.BlogContent == usermail).Select(y => y.BlogID).FirstOrDefault();

            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogID = 5;
			cm.CommentAdd(comment);
			return RedirectToAction("Index", "Blog");
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}

using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke(int id)
		{
			
			var values = bm.GetBlogListByWriter(id);
			//ViewBag.id= bm.GetBlogListByWriter(id);
			return View(values);
		}
	}
}

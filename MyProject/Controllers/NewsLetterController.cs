using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml;

namespace MyProject.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		

       
        [HttpGet]
		public IActionResult SubscribeMail()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter p )
		{
			p.MailStatus = true;
			nm.AddNewsLetter(p);
			return RedirectToAction("Index","Blog");
		}
	}
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		ContactManager cmb = new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			cmb.ContactAdd(contact);
			return RedirectToAction("Index","Blog");
		}
	}
}

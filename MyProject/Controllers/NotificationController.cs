using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
	public class NotificationController : Controller
	{
		NotificationManager nm = new NotificationManager(new EfNotificationRepository());
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult AllNotification()
		{
			var value = nm.GetList();
			return View(value);
		}
	}
}

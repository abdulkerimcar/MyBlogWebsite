using Microsoft.AspNetCore.Mvc;
using MyProject.Areas.Admin.Models;
using Newtonsoft.Json;

namespace MyProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WriterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterList()
		{
			var jsonWriters = JsonConvert.SerializeObject(writers);
			return Json(jsonWriters);
		}

		public static List<WriterClass> writers = new List<WriterClass>
		{
			new WriterClass
			{
				Id=1,
				Name="Sinan"
			},
			new WriterClass
			{
				Id=2,
				Name="Abdülkerim"
			},
			new WriterClass
			{
				Id=3,
				Name="Semih"
			}
		};
	}
}

using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager vm = new WriterManager(new EfWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Index(Writer p)
        {
			WriterValidator vR = new WriterValidator();
			ValidationResult result = vR.Validate(p);
			if (result.IsValid)
			{
				p.WriterStatus = true;
				p.WriterAbout = "Deneme Test";
				vm.TAdd(p);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
        }
    }
}

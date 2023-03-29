using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using X.PagedList;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var value = cm.GetList().ToPagedList(page,4);
            return View(value);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {      
            CategoryValidator cv = new CategoryValidator();
            FluentValidation.Results.ValidationResult result = cv.Validate(category);

            if (result.IsValid)
            {
                category.CategoryStatus = true;
    
                cm.TAdd(category);
                return RedirectToAction("Index", "Category");
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
        public IActionResult CategoryDelete(int id  )
        {
            var value = cm.TGetByID(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}

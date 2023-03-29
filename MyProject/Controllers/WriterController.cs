using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.ViewComponents.Blog;

namespace MyProject.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());

        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
            return View();
        }
        [AllowAnonymous]
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult writerNavBarPartial()
        {
            var usermail = User.Identity.Name;
            ViewBag.v1 = usermail;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult writerFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //Context c = new Context();
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();		
            //var id = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var values = userManager.TGetByID(id);
            //return View(values);


            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            //UserManager userManager = new UserManager(new EfUserRepository()); 
            //userManager.TUpdate(p);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
           
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer1 = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer1.WriterImage = newimagename;
            }
            writer1.WriterMail = p.WriterMail;
            writer1.WriterName = p.WriterName;
            writer1.WriterPassword = p.WriterPassword;
            writer1.WriterStatus = true;
            writer1.WriterAbout = p.WriterAbout;
            wm.TAdd(writer1);
            return RedirectToAction("Index", "Dashboard");
        }
        //public async Task<IActionResult> LogOut()
        //{
        //    await
        //}

    }
}

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Security.Claims;

namespace MyProject.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //proje içerisinde koyulan bütün kurallardan muaf tutar
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSıgnInViewModel p)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(p.usernama, p.password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {

                    return RedirectToAction("Index", "Login");
                   
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //	Context c = new Context();
        //	var value = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //          if (value!=null)
        //          {
        //              var claims = new List<Claim>
        //              {
        //                  new Claim(ClaimTypes.Name,writer.WriterMail)
        //              };
        //              var useridentity = new ClaimsIdentity(claims, "a");
        //              ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //              await HttpContext.SignInAsync(principal);
        //              return RedirectToAction("Index", "Dashboard");
        //          }
        //          else
        //          {
        //              return View();
        //          }
        //}

    }
}
//Context c = new Context();
//var value = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
//if (value != null)
//{
//	HttpContext.Session.SetString("username", writer.WriterMail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//	return View();
//}
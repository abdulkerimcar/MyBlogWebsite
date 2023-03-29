using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyProject.ViewComponents.Writer
{
	
	public class WriterAboutOnDashboard:ViewComponent
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
		{

            //         var usermail = User.Identity.Name;
            //         var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //         var value = wm.GetWriterByID(writerID);
            //return View(value);


            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var value = wm.GetWriterByID(writerID);
            return View(value);
            
        }
	}
}

using Portfolio.Models;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Login login)
        {


            portfolioContext context = new portfolioContext();

            if (!ModelState.IsValid)
            {
                // return Content("call");
                return View("Index", login);
            }

            var userExistence = context.Logins.SingleOrDefault(x => x.UserName == login.UserName);

            if (userExistence == null)
            {
                ViewBag.usernotexist = "User Does Not Exists";
                return View("Index");
            }
            else if (!string.Equals(userExistence.Password,login.Password))
            {
                ViewBag.incorrectpassword = "Incorrect Password";
                return View("Index");
            }
            else if (string.Equals(userExistence.Password, login.Password))
            {
                Session["User"] = userExistence.UserName;

                return RedirectToAction("Main", "Admin");
            }
            return View("Index");
        }

        public ActionResult Main()
        {
            portfolioContext context = new portfolioContext();
            var FilterType = context.filters.ToList();
            var viewmodel = new UploadViewModel
            {
                filters = FilterType
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Main(UploadViewModel upload)
        {
            portfolioContext context = new portfolioContext();

            if (!ModelState.IsValid)
            {
                return View("Index", upload);
            }
            HttpPostedFileBase image = Request.Files["Image"];
            byte[] bytes = null;
            using (BinaryReader br = new BinaryReader(image.InputStream))
            {
                bytes = br.ReadBytes(image.ContentLength);
            }
            Works work = new Works
            {
                Image = bytes,
                Description = upload.Works.Description,
                Title = upload.Works.Title,
                Filter = upload.Works.Filter,
                DT=DateTime.Now
            };
            context.Works.Add(work);
            context.SaveChanges();
            return RedirectToAction("Main", "Admin");
        }

            public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Portfolio");
        }

    }


}
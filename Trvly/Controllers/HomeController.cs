using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trvly.Models;

namespace Trvly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canManageTours))
            {
                return View("Index_Admin");
            }
            return View();
        }
        public ActionResult UnApprovedPosts() {
            return RedirectToAction("UnApprovedPosts", "BlogPost");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Addids24Hours()
        {

            return View();
        }
        public ActionResult RedirectArticle()
        {
            return RedirectToAction("Index", "Tour");
        }

        public ActionResult ApprovedBlog()
        {
            return RedirectToAction("IndexPosts", "BlogPost");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
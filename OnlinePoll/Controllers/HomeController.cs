using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlinePoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePoll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult CasteVote(string voteTo, string userName)
        {
            bool result = BalletBox.Instance.CastVote(userName, voteTo);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        [Route()]
        [Route("Index")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Article")]
        [Route("Home/Article")]
        public ActionResult Article()
        {
            return View();
        }

        [Route("Editor")]
        [Route("Home/Editor")]
        public ActionResult Editor()
        {
            return View();
        }

        [Route("List")]
        [Route("Home/List")]
        public ActionResult List()
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
    }
}
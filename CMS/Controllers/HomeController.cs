using CMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private ArticleModel db = new ArticleModel();

        //[Route()]
        [Route("Index")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Get_carousel_news")]
        public ActionResult Get_carousel_news()
        {
            var num = Convert.ToInt32(Request.Params.Get("num"));
            string sql = @"Select top " + num + @" [Id],[Title],[Update_time],[Class],[Img],[Abstract] From Articles order by [Update_time],[Id] ASC";

            ArticleModel navigation = new ArticleModel();
            var res = navigation.Database.SqlQuery<Navigation>(sql);
            return Json(JsonConvert.SerializeObject(res));
        }

        [Route("List")]
        [Route("Home/List")]
        public ActionResult List()
        {
            return View();
        }

        [Route()]
        [Route("Home")]
        [Route("Home/Home")]
        public ActionResult Home()
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
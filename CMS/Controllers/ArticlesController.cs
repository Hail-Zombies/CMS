using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using Newtonsoft.Json;

namespace CMS.Controllers
{
    public class AjaxResult
    {
        public bool res;
        public string message;

        public AjaxResult()
        {
        }

        public AjaxResult(bool res, string message)
        {
            this.res = res;
            this.message = message;
        }

        public static bool PingSQLServer()
        {
            // 主机地址
            string targetHost = "192.168.57.128";
            string data = " ";

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1024;

            PingReply reply = pingSender.Send(targetHost, timeout);

            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ArticlesController : Controller
    {
        //跳转文章页
        [Route("Article")]
        [Route("Articles/Article")]
        public ActionResult Article()
        {
            return View();
        }

        //跳转编辑页
        [Route("Editor")]
        [Route("Articles/Editor")]
        public ActionResult Editor()
        {
            return View();
        }

        /// <summary>
        /// 提交编辑的文章
        /// </summary>
        /// <returns>成功则返回成功</returns>
        [HttpPost]
        [Route("Submit")]
        [Route("Articles/Submit")]
        public ActionResult Submit()
        {
            if (!AjaxResult.PingSQLServer())
            {
                AjaxResult ajaxResult = new AjaxResult(false, "无法连接到数据库");
                return Json(JsonConvert.SerializeObject(ajaxResult));
            }
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            Articles articles = JsonConvert.DeserializeObject<Articles>(stream);

            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(articles.Content);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] retValue = sha256.ComputeHash(bytValue);

            articles.Update_time = DateTime.Now;
            articles.Content_HASH = retValue;

            var temp = from p in db.Articles
                       where p.Content_HASH == retValue
                       orderby p.Id descending
                       select p;

            if (articles.Content != "" && articles.Content != null)
            {
                if (temp.Count() == 0)
                {
                    AjaxResult ajaxResult = new AjaxResult(true, "保存成功");
                    try
                    {
                        db.Articles.Add(articles);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ajaxResult.res = false;
                        ajaxResult.message = e.ToString();
                        return Json(JsonConvert.SerializeObject(ajaxResult));
                    }
                    return Json(JsonConvert.SerializeObject(ajaxResult));
                }
                else
                {
                    AjaxResult ajaxResult = new AjaxResult(false, "已有相同的文章");
                    return Json(JsonConvert.SerializeObject(ajaxResult));
                }
            }
            else
            {
                AjaxResult ajaxResult = new AjaxResult(false, "保存失败");
                return Json(JsonConvert.SerializeObject(ajaxResult));
            }
        }

        private ArticleModel db = new ArticleModel();

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <returns>返回文章</returns>
        [Route("GetArticle")]
        [Route("Articles/GetArticle")]
        public ActionResult GetArticle()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return Content("文章好像丢失了。。。。。。");
            }
            return Content(articles.Content);
        }

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Content,Update_time,Class,Abstract")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articles);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: Articles/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Content,Update_time,Class,Abstract")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articles);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articles articles = db.Articles.Find(id);
            db.Articles.Remove(articles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
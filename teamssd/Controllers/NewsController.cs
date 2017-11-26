using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
using teamssd.Data;
using teamssd.Data.Entities;

namespace teamssd.Controllers
{
    public class NewsController : GeneralController
    {

        // GET: News
        public ActionResult Index()
        {
            var newses = Db.Newses.Include(n => n.Chanel);
            return View(newses.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = Db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.ChanelId = new SelectList(Db.Chanels, "Id", "Name");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Img,Video,UrlRef,ChanelId")] News news)
        {
            if (ModelState.IsValid)
            {
                news.DateTime = DateTime.Now;
                Db.Newses.Add(news);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChanelId = new SelectList(Db.Chanels, "Id", "Name", news.ChanelId);
            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = Db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChanelId = new SelectList(Db.Chanels, "Id", "Name", news.ChanelId);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Img,Video,UrlRef,ChanelId")] News news)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(news).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChanelId = new SelectList(Db.Chanels, "Id", "Name", news.ChanelId);
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = Db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = Db.Newses.Find(id);
            Db.Newses.Remove(news);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }


        private void RecountNews(int id)
        {
            var news = Db.Newses.Find(id);
            if (news != null)
            {
                var countViews = news.Viewers.Count;
                var countInterests = news.InterestNews.Count;
                var countRelevants = news.RelevantNews.Count;
                var countUsefuls = news.UsefulNews.Count;

                news.ViewsCount = countViews;
                news.InterestsСount = countInterests;
                news.RelevantsСount = countRelevants;
                news.UsefulsСount = countUsefuls;
            }
        }

        private void MarkViewed(int id)
        {
            var viewed = Db.Views.Any(x => x.NewsId == id && x.OwnerId == CurrentUser.Id);
            if (!viewed)
            {
                var view = new View
                {
                    NewsId = id,
                    OwnerId = CurrentUser.Id
                };


                Db.Views.Add(view);
                Db.SaveChanges();

                MarkViewed(id);
            }

            RecountNews(id);
        }

        [HttpPost]
        public ActionResult MarkInterest(int id)
        {
            var isInterest = Db.InterestNews.Any(x => x.NewsId == id && x.OwnerId == CurrentUser.Id);
            if (!isInterest)
            {
                var interest = new InterestNews()
                {
                    NewsId = id,
                    OwnerId = CurrentUser.Id
                };

                Db.InterestNews.Add(interest);
                Db.SaveChanges();

                MarkViewed(id);
            }

            return Json(new { status = 1 });
        }

        [HttpPost]
        public ActionResult MarkRelevant(int id)
        {
            var isRelevant = Db.RelevantNews.Any(x => x.NewsId == id && x.OwnerId == CurrentUser.Id);
            if (!isRelevant)
            {
                var relevant = new RelevantNews()
                {
                    NewsId = id,
                    OwnerId = CurrentUser.Id
                };

                Db.RelevantNews.Add(relevant);
                Db.SaveChanges();

                MarkViewed(id);
            }

            return Json(new { status = 1 });
        }


        [HttpPost]
        public ActionResult MarkUseful(int id)
        {
            var isUseful = Db.UsefulNews.Any(x => x.NewsId == id && x.OwnerId == CurrentUser.Id);
            if (!isUseful)
            {
                var useful = new UsefulNews()
                {
                    NewsId = id,
                    OwnerId = CurrentUser.Id
                };

                Db.UsefulNews.Add(useful);
                Db.SaveChanges();
            }

            return Json(new {status = 1});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

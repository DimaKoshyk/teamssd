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

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
using teamssd.Data;
using teamssd.Data.Entities;
using teamssd.Models;

namespace teamssd.Controllers
{
    public class ChanelsController : GeneralController
    {

        

        public ActionResult Follow(int id)
        {
            var folowed = Db.Followers.Any(x => x.ChanelId == id && x.OwnerId == CurrentUser.Id);
            if (folowed)
            {
                Chanel chanel = Db.Chanels.Find(id);
                if (chanel != null)
                {
                    Db.Chanels.Remove(chanel);
                    Db.SaveChanges();
                }
                folowed = false;
            }
            else
            {
                Db.Followers.Add(new Follower
                {
                    ChanelId = id,
                    OwnerId = CurrentUser.Id
                });
                Db.SaveChanges();

                folowed = true;
            }

            return Json(new {status = 1, follow = folowed });
        }

        public ActionResult MyChanels()
        {
            ViewBag.MyChanels = true;
            var chanels = Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id).Include(c => c.Owner);
            return View("Index", chanels.ToList());
        }

        public ActionResult FollowedChanels()
        {
            ViewBag.FollowedChanels = true;
            var chanels = Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)).Include(c => c.Owner);
            return View("Index", chanels.ToList());
        }

        public ActionResult SearchChanels()
        {
            ViewBag.SearchChanels = true;
            var chanels = Db.Chanels
                .Where(x => x.OwnerId != CurrentUser.Id && x.Followers.All(y => y.OwnerId == CurrentUser.Id))
                .Include(c => c.Owner);
            return View("Index", chanels.ToList());
        }

        // GET: Chanels
        public ActionResult Index()
        {
            var chanels = Db.Chanels.Include(c => c.Owner);
            return View(chanels.ToList());
        }

        // GET: Chanels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = Db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            return View(chanel);
        }

        // GET: Chanels/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(Db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Chanels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,OwnerId")] Chanel chanel)
        {
            if (ModelState.IsValid)
            {
                Db.Chanels.Add(chanel);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(Db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        // GET: Chanels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = Db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(Db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        

        // POST: Chanels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,OwnerId")] Chanel chanel)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(chanel).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(Db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        // GET: Chanels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = Db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            return View(chanel);
        }

        // POST: Chanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chanel chanel = Db.Chanels.Find(id);
            Db.Chanels.Remove(chanel);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetNewsByChanel(int id)
        {
            var news = Db.Chanels.Find(id)?.News.ToList();

            return PartialView("_ListNews", news);
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

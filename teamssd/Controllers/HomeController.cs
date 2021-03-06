﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using teamssd.Controllers.Abstract;
using teamssd.Data.Entities;
using teamssd.Models;

namespace teamssd.Controllers
{
    public class NewsFilter
    {
        public int? ChanelId { get; set; }

    }

    public class HomeController : GeneralController
    {

        

        private int GetCountOfNews(int? page)
        {
            if (page == null || page.Value < 0)
            {
                page = 0;
            }

            return 10 * page.Value;
        }

        private IList<News> GetNews(bool isMy, bool viewed, int? chanelId, int? page)
        {
            IList<News> news = Db.Newses.ToList();

            if (isMy)
            {
                news = news.Where(x => x.Chanel.OwnerId == CurrentUser.Id).ToList();
            }
            else if (viewed)
            {
                news = news.Where(x => x.Chanel.Followers.Any(y => y.OwnerId == CurrentUser.Id) && x.Viewers.Any(y => y.OwnerId == CurrentUser.Id)).ToList();

            }
            else 
            {
                news = news.Where(x => x.Chanel.Followers.Any(y => y.OwnerId == CurrentUser.Id) && x.Viewers.All(y => y.OwnerId != CurrentUser.Id)).ToList();
            }

            if (chanelId.HasValue)
            {
                news = news.Where(x => x.ChanelId == chanelId.Value).ToList();
            }

            var skipNews = GetCountOfNews(page);

            return news
                //.OrderByDescending(x => (x.InterestsСount + x.RelevantsСount + x.UsefulsСount) / (DbFunctions.DiffHours(DateTime.Now, x.DateTime) + 1))
                .OrderByDescending(x => (x.InterestsСount + x.RelevantsСount + x.UsefulsСount) / ((DateTime.Now - x.DateTime).TotalHours + 1))
                .ThenBy(x => x.DateTime)
                .Skip(skipNews)
                .Take(10)
                .ToList();
        }

        public ActionResult Index(int? chanelId)
        {
            //ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name", );
            //var model = new DashboardViewModels();

            //model.Chanels = CurrentUser.Chanels.ToList();
            //var firstChanel = model.Chanels.FirstOrDefault();
            //model.NewsOfFirstChanel = firstChanel?.News.ToList() ?? new List<News>();

            return News(chanelId);
        }

        public ActionResult MyNews(int? chanelId)
        {
            if (chanelId != null)
            {
                ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name", chanelId);
            }
            else
            {
                ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.OwnerId == CurrentUser.Id), "Id", "Name");
            }
            ViewBag.MyNews = true;

            var model = new DashboardViewModels();
            model.News = GetNews(true, false, chanelId, 0);

            return View("Index", model);
        }

        public ActionResult News(int? chanelId)
        {
            ViewBag.News = true;
            if (chanelId != null)
            {
                ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)), "Id", "Name", chanelId);

            }
            else
            {
                ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)), "Id", "Name");
            }

            var model = new DashboardViewModels();
            model.News = GetNews(false, false, chanelId, 0);

            return View("Index", model);
        }

        public ActionResult ViewedNews()
        {
            ViewBag.ViewedNews = true;
            ViewBag.ChanelId = new SelectList(Db.Chanels.Where(x => x.Followers.Any(y => y.OwnerId == CurrentUser.Id)), "Id", "Name");

            var model = new DashboardViewModels();
            model.News = GetNews(false, true, null, 0);

            //return NotFound404();
            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //for test
            var usersQ = Db.Views.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ViewResult NotFound404()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ViewResult InternalServerError500()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teamssd.Data;

namespace teamssd.Controllers
{
    public abstract class GeneralController : Controller
    {
        // GET: General
        public readonly ApplicationDbContext Db = new ApplicationDbContext();
    }
}
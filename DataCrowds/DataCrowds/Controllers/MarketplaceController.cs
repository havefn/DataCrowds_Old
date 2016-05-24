using DataCrowds.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCrowds.Controllers
{
    public class MarketplaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marketplace
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult _SearchDataSets(string keyword)
        {
            System.Threading.Thread.Sleep(2000);
            var data = db.DataSets.Where(f =>
            f.title.Contains(keyword)).ToList();
            return PartialView(data);
        }



    }
}
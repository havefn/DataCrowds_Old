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
        private DataCrowdsContext db = new DataCrowdsContext();

        // GET: Marketplace
        public ActionResult Index()
        { 
            return View();
        }


        public PartialViewResult _SearchDataSets(string keyword)
        {
            System.Threading.Thread.Sleep(2000);
            var data = db.DataSets.Where(f =>
            f.title.StartsWith(keyword)).ToList();
            return PartialView(data);
        }
    }
}
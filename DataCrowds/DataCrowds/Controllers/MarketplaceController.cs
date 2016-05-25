using DataCrowds.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

       
        [Authorize]
        public ActionResult BuyDataSet(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var userId = User.Identity.GetUserId();
            DataSet data = db.DataSets.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }

            var user = db.Users.Include("BoughtData").Single(x=> x.Id == userId);

            ViewBag.Message = "Confirm Buy DataSet ?";
            ReceiptView temp = new ReceiptView
            {
                boughtData = data,
                User = user

            };

            return View(temp);
        }

        public ActionResult ConfirmBuyDataSet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();
            DataSet data = db.DataSets.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }

            var user = db.Users.Include("BoughtData").Single(x => x.Id == userId);
            user.BoughtData.Add(data);
            db.SaveChanges();

            ReceiptView temp = new ReceiptView
            {
                boughtData = data,
                User = user

            };

            return View();
        }
       
    }
}
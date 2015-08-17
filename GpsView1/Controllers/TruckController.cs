using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GpsView1.Controllers
{
    public class TruckController : Controller
    {
        // GET: Truck
        public ActionResult Index(int truckId)
        {
            User user = FetchUser();
            if (truckId == 0)
            {
                if (user == null)
                {
                    return View("Index", _dataService.Trucks.All().Where(x => x.IsPrivate == false).OrderBy(x => x.Name));
                }
                // Show this user's trucks
                return View("Index", _dataService.Trucks.All().Where(x => x.User.Id == user.Id).OrderBy(x => x.Name));
            }
        }
    }
}
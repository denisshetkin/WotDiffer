using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcApplication.Models.Entities.EncyclopediaDetails;
using WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks;
using WotApi;
using Tank = WargamingApiManager.Entities.PlayerDetails.Tank;

namespace MvcApplication.Controllers
{
    public class TanksController : Controller
    {
      private const string AppId = "3ea00a80eeb1cdda0e1053d6b0b6c2b7";
      private readonly WargamingManager _manager = new WargamingManager(AppId);
        //
        // GET: /Tanks/

        public ActionResult Index()
        {
          var allVehicles = _manager.GetAllVehicles();

          Mapper.CreateMap<Tank, TankViewModel>();
          var tanks = Mapper.Map<IEnumerable<Tank>, List<TankViewModel>>(allVehicles);

          return View(tanks);
        }

    }
}

using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurCms.Controllers
{

    public class resController : Controller
    {
        OurCmsContext db = new OurCmsContext();
        private IResrvationRepository reservationRepository;
        private IStationRepositorycs stationRepositorycs;
        private IHourReservation hourReservation;
        public resController()
        {
            reservationRepository = new ReservationRepository(db);
            stationRepositorycs = new StatinRepositorycs(db);
            hourReservation = new HourRepository(db);
        }

        //GET: res
        //        public ActionResult Index()
        //        {
        //            //ViewBag.HourID = new SelectList(hourReservation.GetAllHours(), "HourID", "SelectHour");
        //            //ViewBag.StationID = new SelectList(stationRepositorycs.GetAllStations(), "StationID", "StationName");
        //            return View(/*reservationRepository.GetAllReservations()*/);
        //        }
        //        [HttpPost]
        //        public ActionResult Index(rezViewModel rez)
        //        {

//            Reservation re = new Reservation()
//            {
//                ReservationID = 1,
//                UserName = rez.UserName,
//                HourID = rez.HourID,
//                StationID = rez.StationID,
//                DateRez = DateTime.Now
//            };
//            db.Reservations.Add(re);
//            //db.SaveChanges();

//            return View(rez);
//        }
    }
}
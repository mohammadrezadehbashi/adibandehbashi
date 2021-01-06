using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace OurCms.Controllers
{
    public class ReservationsController : Controller
    {
        OurCmsContext db = new OurCmsContext();
        
        private IResrvationRepository reservationRepository;
        private IStationRepositorycs stationRepositorycs;
        private IHourReservation hourReservation;
        public ReservationsController()
        {
            reservationRepository = new ReservationRepository(db);
            stationRepositorycs = new StatinRepositorycs(db);
            hourReservation = new HourRepository(db);
        }

        // GET: Reservations
        public ActionResult Index()
        {
            //var reservations = db.Reservations.Include(r => r.Hour).Include(r => r.Station);
            return View(reservationRepository.GetAllReservations().ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservationById(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.HourID = new SelectList(hourReservation.GetAllHours(), "HourID", "SelectHour");
            ViewBag.StationID = new SelectList(stationRepositorycs.GetAllStations(), "StationID", "StationName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,StationID,HourID,UserName,Email,DateRez")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
               
               reservationRepository.InsertReservation(reservation);
                reservationRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.HourID = new SelectList(hourReservation.GetAllHours(), "HourID", "SelectHour", reservation.HourID);
            ViewBag.StationID = new SelectList(stationRepositorycs.GetAllStations(), "StationID", "StationName", reservation.StationID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservationById(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.HourID = new SelectList(hourReservation.GetAllHours(), "HourID", "SelectHour", reservation.HourID);
            ViewBag.StationID = new SelectList(stationRepositorycs.GetAllStations(), "StationID", "StationName", reservation.StationID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,StationID,HourID,UserName,Email,DateRez")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservationRepository.UpdateReservation(reservation);
               reservationRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.HourID = new SelectList(db.Hours, "HourID", "SelectHour", reservation.HourID);
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", reservation.StationID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = reservationRepository.GetReservationById(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservationRepository.DeleteReservation(id);
            reservationRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                reservationRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

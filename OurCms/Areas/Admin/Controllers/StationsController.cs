using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace OurCms.Areas.Admin.Controllers
{
    public class StationsController : Controller
    {
        private OurCmsContext db = new OurCmsContext();
        private IStationRepositorycs stationRepositorycs;
        public StationsController()
        {
            stationRepositorycs = new StatinRepositorycs(db);
        }

        // GET: Admin/Stations
        public ActionResult Index()
        {
            return View(stationRepositorycs.GetAllStations());
        }

        // GET: Admin/Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = stationRepositorycs.GetStationById(id.Value);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Admin/Stations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationID,StationName")] Station station)
        {
            if (ModelState.IsValid)
            {
                stationRepositorycs.InsertStation(station);
                stationRepositorycs.Save();
                return RedirectToAction("Index");
            }

            return View(station);
        }

        // GET: Admin/Stations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = stationRepositorycs.GetStationById(id.Value);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Admin/Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationID,StationName")] Station station)
        {
            if (ModelState.IsValid)
            {
                stationRepositorycs.UpdateStation(station);
               stationRepositorycs.Save();
                return RedirectToAction("Index");
            }
            return View(station);
        }

        // GET: Admin/Stations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = stationRepositorycs.GetStationById(id.Value);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Admin/Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stationRepositorycs.DeleteStation(id);
            stationRepositorycs.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                stationRepositorycs.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

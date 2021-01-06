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
    public class HoursController : Controller
    {
        private OurCmsContext db = new OurCmsContext();
        private IHourReservation hourReservation;

        public HoursController()
        {
            hourReservation = new HourRepository(db);
        }

        // GET: Admin/Hours
        public ActionResult Index()
        {
            return View(hourReservation.GetAllHours());
        }

        // GET: Admin/Hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = hourReservation.GetHourById(id.Value);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // GET: Admin/Hours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HourID,SelectHour")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                hourReservation.InsertHour(hour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hour);
        }

        // GET: Admin/Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = hourReservation.GetHourById(id.Value);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // POST: Admin/Hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HourID,SelectHour")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                hourReservation.UpdateHour(hour);
                hourReservation.Save();
                return RedirectToAction("Index");
            }
            return View(hour);
        }

        // GET: Admin/Hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = hourReservation.GetHourById(id.Value);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // POST: Admin/Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            hourReservation.DeleteHour(id);
            hourReservation.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                hourReservation.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

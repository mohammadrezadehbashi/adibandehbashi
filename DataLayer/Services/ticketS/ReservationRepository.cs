using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReservationRepository : IResrvationRepository
    {
        private OurCmsContext db;

        public ReservationRepository(OurCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
           return db.Reservations;
        }

        public Reservation GetReservationById(int reservationId)
        {
            return db.Reservations.Find(reservationId);
        }

        public bool InsertReservation(Reservation reservation)
        {
            try
            {
                db.Reservations.Add(reservation);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool UpdateReservation(Reservation reservation)
        {
            try
            {
                db.Entry(reservation).State = EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteReservation(Reservation reservation)
        {           
            try
            {
                db.Entry(reservation).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteReservation(int resrevationId)
        {
            var p = GetReservationById(resrevationId);
            DeleteReservation(p);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

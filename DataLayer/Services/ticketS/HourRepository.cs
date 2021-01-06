using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HourRepository : IHourReservation
    {
        private OurCmsContext db;
        public HourRepository(OurCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Hour> GetAllHours()
        {
           return db.Hours;
        }

        public Hour GetHourById(int hourId)
        {
            return db.Hours.Find(hourId);
        }

        public bool InsertHour(Hour hour)
        {
            try
            {
                 db.Hours.Add(hour);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool UpdateHour(Hour hour)
        {
            try
            {
                db.Entry(hour).State = EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteHour(Hour hour)
        {
            try
            {
                db.Entry(hour).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteHour(int hourId)
        {
            var p = GetHourById(hourId);
            DeleteHour(p);
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

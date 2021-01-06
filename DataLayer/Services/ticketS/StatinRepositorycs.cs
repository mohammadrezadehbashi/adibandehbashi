using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StatinRepositorycs : IStationRepositorycs
    {
        private OurCmsContext db;
        public StatinRepositorycs(OurCmsContext context)
        {
            this.db = context;
        }


        public IEnumerable<Station> GetAllStations()
        {
            return db.Stations;
        }

        public Station GetStationById(int stationId)
        {
            return db.Stations.Find(stationId);
        }

        public bool InsertStation(Station station)
        {
            try
            {
                 db.Stations.Add(station);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateStation(Station station)
        {
            try
            {
                db.Entry(station).State = EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }
       
        public bool DeleteStation(Station station)
        {
            try
            {
                db.Entry(station).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteStation(int stationId)
        {
            var p = db.Stations.Find(stationId);
            DeleteStation(p);
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

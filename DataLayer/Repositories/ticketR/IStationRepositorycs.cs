using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IStationRepositorycs:IDisposable
    {
        IEnumerable<Station> GetAllStations();
        Station GetStationById(int stationId);
        bool InsertStation(Station station);
        bool UpdateStation(Station station);
        bool DeleteStation(Station station);
        bool DeleteStation(int stationId);
        void Save();
    }
}

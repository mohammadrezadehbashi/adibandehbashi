using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IHourReservation:IDisposable
    {
        IEnumerable<Hour> GetAllHours();
        Hour GetHourById(int hourId);
        bool InsertHour(Hour hour);
        bool UpdateHour(Hour hour);
        bool DeleteHour(Hour hour);
        bool DeleteHour(int hourId);
        void Save();
    }
}

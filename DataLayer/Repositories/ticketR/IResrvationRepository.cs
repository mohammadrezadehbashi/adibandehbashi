using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IResrvationRepository:IDisposable
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        bool InsertReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool DeleteReservation(Reservation reservation);
        bool DeleteReservation(int resrevationId);
        void Save();

    }
}

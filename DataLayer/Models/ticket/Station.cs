using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Station
    {
        [Key]
        public int StationID { get; set; }
        [Display(Name = "ایستگاه")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        public string StationName { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
        public Station()
        {

        }
    }
}

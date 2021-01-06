using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Hour
    {
        [Key]
        public int HourID { get; set; }
        [Display(Name = "زمان رزرو")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        public string SelectHour { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
        public Hour()
        {

        }
    }
}

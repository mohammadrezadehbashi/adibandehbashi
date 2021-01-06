using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
     public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Display(Name = "ایستگاه")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        public int StationID { get; set; }
        [Display(Name = "ایستگاه")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        public int HourID { get; set; }
        //[Display(Name = "ایستگاه")]
        //[Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        //public int DataRezervID { get; set; }
        //این پروپرتی بالا رو با ویومدل اضافه میکنیم
        [Display(Name = "نام")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "خواهشمندم {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }

        [Display(Name = "تاریخ رزرو")]
      
        public DateTime DateRez { get; set; }


        public virtual Station Station { get; set; }
        public virtual Hour Hour { get; set; }
        public Reservation()
        {

        }
    }
}

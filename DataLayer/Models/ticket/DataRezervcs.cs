using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataRezervcs
    {
        [Key]
        public int DataRezervID { get; set; }
        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateRez { get; set; }

        public virtual List<Numbering> Numberings { get; set; }
        public DataRezervcs()
        {

        }
    }
}

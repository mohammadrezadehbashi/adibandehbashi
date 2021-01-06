using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Numbering
    {
        [Key]
        public int NumberingID { get; set; }
        [Display(Name = "شماره صندلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Number { get; set; }

        public virtual DataRezervcs DataRezervcs { get; set; }
        public Numbering()
        {

        }
    }
}

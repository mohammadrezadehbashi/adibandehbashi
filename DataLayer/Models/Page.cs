﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupID { get; set; }
        [Display(Name = " عنوان خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Display(Name = " چکیده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = " متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
        [Display(Name = " بازدید")]
        public int Visit { get; set; }
        [Display(Name = " اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "تصویر")]

        public string ImageName { get; set; }
        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "کلیدواژه")]
        public string Tags { get; set; }

        public virtual PageGroup PageGroup { get; set; }
        public virtual List<PageComment> PageComments { get; set; }
        public Page()
        {

        }
    }
}

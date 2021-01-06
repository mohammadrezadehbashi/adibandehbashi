using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OurCms
{
    public static class PersianConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value).ToString() +"/"+ pc.GetMonth(value).ToString("00") +"/"+ pc.GetDayOfMonth(value).ToString("00");
                }
    }
}
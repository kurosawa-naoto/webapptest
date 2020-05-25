using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace webapptest.Controllers
{
    public class ChangeDate
    {
        private DateTime parseDate;
        private string jpCalender;

        public DateTime ParseDate { get => this.parseDate; }
        public string JpCalender { get => this.jpCalender; }

        public void DoChange(InputData id)
        {
            int intYear = int.Parse(id.Year);
            int intMonth = int.Parse(id.Month);
            int intDay = int.Parse(id.Day);

            string strYear = id.Year;
            string strMonth;
            string strDay;
            if (id.Month.Length == 1)
            {
                strMonth = "0" + id.Month;
            }
            else
            {
                strMonth = id.Month;
            }
            if (id.Day.Length == 1)
            {
                strDay = "0" + id.Day;
            }
            else
            {
                strDay = id.Day;
            }

            parseDate = DateTime.ParseExact(strYear + strMonth + strDay, "yyyyMMdd", null);

            CultureInfo cif = new CultureInfo("ja-JP", true);
            cif.DateTimeFormat.Calendar = new JapaneseCalendar();
            DateTime dt = new DateTime(intYear, intMonth, intDay);
            jpCalender = dt.ToString("ggyy年MM月dd日", cif);


        }
    }
}

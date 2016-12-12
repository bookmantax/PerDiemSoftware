using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest2
{
    class Month
    {
        public int days, previousMonthDays;
        public string previousMonth;

        public Month(int days, int previousMonthDays, string previousMonth)
        {
            this.days = days;
            this.previousMonthDays = previousMonthDays;
            this.previousMonth = previousMonth;
        }
    }
}

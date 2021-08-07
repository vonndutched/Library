using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE114L_CLS
{
    class Penalty
    {
        int days;
        decimal penalty;
        const decimal penaltyPerDay = 20m;
        const decimal damagePenalty = 200m;
        string DBorrowedString;
        bool isDamaged;
        DateTime DateBorrowed;
        DateTime DateToday;
        TimeSpan DaysBorrowed;

        public Penalty() { }

        public Penalty(string dateBorrowedString, bool damagedBa)
        {
            penalty = 0m;
            isDamaged = damagedBa;
            DateToday = DateTime.Now;
            DBorrowedString = dateBorrowedString;
        }

        //Coconvert nya yung string to date and time
        //for example ang string mo "12, 03, 2015"
        //(month, date, year)

        public void ConvertDateToDateTime()
        {
            DateBorrowed = Convert.ToDateTime(DBorrowedString);
        }

        //kinukuha nya yung number of days na nahiram yung libro
        public void ComputeDateDifferenceDay()
        {
            DaysBorrowed = DateToday - DateBorrowed;
            days = DaysBorrowed.Days;
        }

        //Compute penalty 
        public void ComputePenalty()
        {
            if (days>7 && isDamaged==false)
            {
                penalty = penaltyPerDay * (decimal)(days-7);
            }

            else if (days>7 && isDamaged==true)
            {
                 penalty = (penaltyPerDay * (decimal)(days-7)) + damagePenalty;
            }

            else if (days < 7 && isDamaged == true)
            {
                penalty =  damagePenalty;
            }
        }

        public int getDaysBorrowed()
        {
            return days;
        }
        public decimal getPenalty()
        {
            return penalty;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exceptions___Jahre.Models
{
    internal class SimpleDate
    {
        private int _year;
        private int _month;
        private int _day;

        public int Year { 
            get { return _year; } 
            set
            {
                try
                {
                    TestYear(value);
                }
                catch(YearOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    value = 1;
                }
                _year = value; 
            } 
        }

        public int Month { 
            get { return _month; } 
            set 
            { 
                try
                {
                    TestMonth(value);
                }
                catch(MonthOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    value = 1;
                }
                _month = value; 
            } 
        }

        public int Day
        {
            get { return _day; }
            set
            {
                try
                {
                    TestDay(value);
                } 
                catch(DayOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    value = 28;
                }
                _day = value; 
            }
        }

        public SimpleDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString()
        {
            return $"{Year} {Month} {Day}";
        }

        public static int TestYear(int value)
        {
            if (value < 1 || value > 9999)
            {
                throw new YearOutOfRangeException();
            }
            return value;
        }
        public static int TestMonth(int value)
        {
            if (value < 1 || value > 12)
            {
                throw new MonthOutOfRangeException();
            }
            return value;
        }

        public int TestDay(int value)
        {
            if(this.Year > 1582)
            {
                if (value > DateTime.DaysInMonth(this.Year, this.Month))
                {
                    throw new DayOutOfRangeException();
                }
            }
            return value;
        }
    }
}

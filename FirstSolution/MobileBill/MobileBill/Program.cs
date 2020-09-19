using System;

namespace MobileBill
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Start time:");
            DateTime start = DateTime.Parse(Console.ReadLine());
            Console.Write("End time:");
            DateTime end = DateTime.Parse(Console.ReadLine());
            double rate = 0;
            if (IsPeak(start, end))
                rate = 30;
            else
                rate = 20;
            double seconds = (end - start).TotalSeconds;
            double pulse = seconds / 20.0;
            Console.WriteLine((pulse * rate)/100.0);

        }

        static bool IsPeak(DateTime start,DateTime end)
        {
            DateTime peakstartDate = DateTime.Parse("2019-08-31 9.00.00 am");
            var peakstart = peakstartDate.TimeOfDay;
            DateTime peakendDate = DateTime.Parse("2019-08-31 10.59.59 pm");
            var peakend = peakendDate.TimeOfDay;
            var startday = start.TimeOfDay;
            var endday = end.TimeOfDay;
            if (startday >= peakstart && startday <= peakend)
                return true;
            if (endday >= peakstart && endday <= peakend)
                return true;
            return false;
        }
    }
}

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
            var peaks = IsPeak(start,end);

            Console.WriteLine($"{((double)peaks.Item1*30.0+(double)peaks.Item2*20.0)/100.00} taka");

        }

        static (int,int) IsPeak(DateTime start,DateTime end)
        {
            int offpick = 0;
            int onpick = 0;
            DateTime peakstartDate = DateTime.Parse("2019-08-31 9.00.00 am");
            var peakstart = peakstartDate.TimeOfDay;
            DateTime peakendDate = DateTime.Parse("2019-08-31 10.59.59 pm");
            var peakend = peakendDate.TimeOfDay;
            var startday = start.TimeOfDay;
            var endday = end.TimeOfDay;
            if (startday >= peakstart && startday <= peakend && endday >= peakstart && endday <= peakend)
            {
                double seconds = (end - start).TotalSeconds;
                onpick =(int)seconds / 20;
                return (onpick, offpick);
            }
            else if (startday >= peakstart && startday <= peakend)
            {
                double tot = (end - start).TotalSeconds;
                double seconds = (peakend - startday).TotalSeconds;
                double totalpeak = Math.Ceiling(tot / 20);
                onpick = (int)Math.Ceiling(seconds / 20)+1;
                offpick = (int)totalpeak - onpick;
                return (onpick, offpick);
            }else if(endday >= peakstart && endday <= peakend)
            {
                double tot = (end - start).TotalSeconds;
                double seconds = (endday - peakstart).TotalSeconds;
                double totalpeak = Math.Ceiling(tot / 20);
                onpick = (int)Math.Ceiling(seconds / 20)+1;
                offpick = (int)totalpeak - onpick;
                return (onpick, offpick);
            }
            else
            {
                double seconds = (end - start).TotalSeconds;
                offpick = (int)seconds / 20;
                return (onpick, offpick);
            }
        }
    }
}

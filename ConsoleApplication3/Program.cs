using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTIME
        {

            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minutes;
            public short Seconds;
            public short Milliseconds;
        }

        [DllImport("kernel32.dll")]
        static extern bool SetLocalTime(ref SYSTIME time);
        static void Main(string[] args)
        {
            var s = new SYSTIME
            {
                Year = (short) DateTime.Now.Year,
                Month = (short) DateTime.Now.Month,
                DayOfWeek = (short) DateTime.Now.DayOfWeek,
                Day = (short) DateTime.Now.Day,
                Hour = 20, // o la hora que quieras...
                Minutes = 0,
                Seconds = 0,
                Milliseconds = 0
            };


            SetLocalTime(ref s);
        }
    }
}

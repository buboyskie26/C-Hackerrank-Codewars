using System;
using System.Collections.Generic;
using System.Text;

namespace BuildPrac.MoveCode

{ 

    public static class DateExtenstion
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday;
        }
    }
    public class IntroduceExtensionMethod
    {
        public bool CanScheduleEvent()
        {
            /*            bool canSchedule = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || 
                            DateTime.Now.DayOfWeek == DayOfWeek.Sunday;*/

            return DateTime.Now.IsWeekend();
        }
    }
}

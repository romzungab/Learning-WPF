using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDatePicker
{
    class DatepickerViewModel
    {
        public DatepickerViewModel()
        {
            List<NonWorkingDayDto> nonWorkingDayDtos = new List<NonWorkingDayDto>();
            nonWorkingDayDtos.Add(new NonWorkingDayDto(DateTime.Now.AddDays(1).Date, "Today +1 is no good"));
            nonWorkingDayDtos.Add(new NonWorkingDayDto(DateTime.Now.AddDays(2).Date, "Today +2 is no good"));

            //SetValue(CalendarBehavior.NonWorkingDaysProperty, nonWorkingDayDtos);
        }
        
    }
}

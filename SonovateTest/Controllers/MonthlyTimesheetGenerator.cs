using SonovateTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Controllers
{
    public class MonthlyTimesheetGenerator : ITimeSheetGenerator
    {
        public List<TimeSheet> Generate(DateTime startDate, DateTime endDate)
        {
            var timeSheetList = new List<TimeSheet>();
            TimeSheet timesheet = null;
            int timesheetCounter = 1;

            for (var i = 0; startDate.AddDays(i) <= endDate; i++)
            {
                if (startDate.AddDays(i) == startDate || startDate.AddDays(i).Day == 1)
                {
                    timesheet = new TimeSheet()
                    {
                        Title = "TS" + timesheetCounter.ToString().PadLeft(4 - timesheetCounter.ToString().Length, '0'),
                        Dates = new List<string>()
                    };

                    timesheetCounter += 1;
                    var lastDayInMonth = new DateTime(startDate.AddDays(i).Year, startDate.AddDays(i).Month, DateTime.DaysInMonth(startDate.AddDays(i).Year, startDate.AddDays(i).Month));
                    if (lastDayInMonth < endDate)
                    {
                        timesheet.SubTitle = startDate.AddDays(i).ToString("dd MMM") + "-" + lastDayInMonth.ToString("dd MMM");
                    }
                    else
                    {
                        timesheet.SubTitle = startDate.AddDays(i).ToString("dd MMM") + "-" + endDate.ToString("dd MMM");
                    }                    

                    timeSheetList.Add(timesheet);
                }

                timesheet.Dates.Add(startDate.AddDays(i).ToString("dd ddd"));
            }

            return timeSheetList;
        }
    }
}

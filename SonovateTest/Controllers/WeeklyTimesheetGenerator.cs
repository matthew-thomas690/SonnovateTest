﻿using SonovateTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Controllers
{
    public class WeeklyTimesheetGenerator : ITimeSheetGenerator
    {
        public List<TimeSheet> Generate(DateTime startDate, DateTime endDate)
        {
            var timeSheetList = new List<TimeSheet>();
            TimeSheet timesheet = null;
            int timesheetCounter = 1;

            for (var i = 0; startDate.AddDays(i) <= endDate; i++)
            {
                if (startDate.AddDays(i) == startDate || startDate.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    timesheet = new TimeSheet()
                    {
                        Title = "TS" + timesheetCounter.ToString().PadLeft(4 - timesheetCounter.ToString().Length, '0'),
                        SubTitle = startDate.AddDays(i).ToString("dd MMM") + "-" + (startDate.AddDays(i).AddDays(6) < endDate ? startDate.AddDays(i).AddDays(6).ToString("dd MMM") : endDate.ToString("dd MMM")),
                        Dates = new List<string>()
                    };
                    timesheetCounter += 1;
                    timeSheetList.Add(timesheet);
                }

                timesheet.Dates.Add(startDate.AddDays(i).ToString("dd ddd"));
            }

            return timeSheetList;
        }
    }
}

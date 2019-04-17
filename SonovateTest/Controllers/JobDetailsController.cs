using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonovateTest.Models;

namespace SonovateTest.Controllers
{
    public class JobDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View(new JobDetailsModel() { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) });
        }

        public IActionResult GenerateTimesheet(JobDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var timeSheetModel = new TimeSheetModel() { Client = model.Client, FullName = model.FirstName + " " +model.LastName, JobTitle = model.JobTitle };

            ITimeSheetGenerator timeSheetGenerator;

            if(model.TimeSheetFrequency == "Weekly")
            {
                timeSheetGenerator = new WeeklyTimesheetGenerator();
            }
            else
            {
                timeSheetGenerator = new MonthlyTimesheetGenerator();
            }

            timeSheetModel.TimeSheets = timeSheetGenerator.Generate(model.StartDate, model.EndDate);

            return View("TimeSheetView", timeSheetModel);
        }

    }
}

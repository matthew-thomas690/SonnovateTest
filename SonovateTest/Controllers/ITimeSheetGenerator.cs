using SonovateTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Controllers
{
    public interface ITimeSheetGenerator
    {
        List<TimeSheet> Generate(DateTime startDate, DateTime endDate);
    }
}

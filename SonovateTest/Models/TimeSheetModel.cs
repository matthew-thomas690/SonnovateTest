using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Models
{
    public class TimeSheetModel
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string Client { get; set; }
        public List<TimeSheet> TimeSheets { get; set; }
    }
}

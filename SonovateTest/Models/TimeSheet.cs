using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Models
{
    public class TimeSheet
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<string> Dates { get; set; }
    }
}

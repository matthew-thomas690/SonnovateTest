using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonovateTest.Controllers;
using System;

namespace TimeSheetTests
{
    [TestClass]
    public class TimeSheetGeneratorTest
    {

        [TestMethod]
        public void WeeklyTimeSheetGeneratorTest()
        {
            var generator = new WeeklyTimesheetGenerator();
            var result = generator.Generate(new DateTime(2017,1,2), new DateTime(2017, 2, 5));
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0].Dates.Count == 7);
            Assert.IsTrue(result[1].Dates.Count == 7);
            Assert.IsTrue(result[2].Dates.Count == 7);
            Assert.IsTrue(result[3].Dates.Count == 7);
            Assert.IsTrue(result[4].Dates.Count == 7);
            Assert.IsTrue(result[0].SubTitle == "02 Jan-08 Jan");
            Assert.IsTrue(result[1].SubTitle == "09 Jan-15 Jan");
            Assert.IsTrue(result[2].SubTitle == "16 Jan-22 Jan");
            Assert.IsTrue(result[3].SubTitle == "23 Jan-29 Jan");
            Assert.IsTrue(result[4].SubTitle == "30 Jan-05 Feb");
        }

        [TestMethod]
        public void MonthlyTimeSheetGeneratorTest()
        {
            var generator = new MonthlyTimesheetGenerator();
            var result = generator.Generate(new DateTime(2017, 1, 4), new DateTime(2017, 5, 12));
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0].Dates.Count == 28);
            Assert.IsTrue(result[1].Dates.Count == 28);
            Assert.IsTrue(result[2].Dates.Count == 31);
            Assert.IsTrue(result[3].Dates.Count == 30);
            Assert.IsTrue(result[4].Dates.Count == 12);
            Assert.IsTrue(result[0].SubTitle == "04 Jan-31 Jan");
            Assert.IsTrue(result[1].SubTitle == "01 Feb-28 Feb");
            Assert.IsTrue(result[2].SubTitle == "01 Mar-31 Mar");
            Assert.IsTrue(result[3].SubTitle == "01 Apr-30 Apr");
            Assert.IsTrue(result[4].SubTitle == "01 May-12 May");
        }
    }
}

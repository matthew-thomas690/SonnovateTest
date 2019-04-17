using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SonovateTest.Models
{
    public class JobDetailsModel : IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeSheetFrequency { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (TimeSheetFrequency != "Weekly" && TimeSheetFrequency != "Monthly")
            {
                result.Add( new ValidationResult(  $"Please select a timesheet frequency", new[] { "TimeSheetFrequency" }));
            }

            if (StartDate > EndDate)
            {
                result.Add(new ValidationResult($"end date must be before end date", new[] { "StartDate" }));
            }            
 
            return result;
        }
    }

}

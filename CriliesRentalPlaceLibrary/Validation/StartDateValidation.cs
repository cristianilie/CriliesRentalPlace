using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Validation
{
    public class StartDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object startDate, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(startDate).Date >= DateTime.Today.Date && 
                Convert.ToDateTime(startDate).Date <= DateTime.Today.AddMonths(6).Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Rental time range: today - next 6 months");
            }
        }
    }
}

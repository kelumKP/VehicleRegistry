using System;
using System.ComponentModel.DataAnnotations;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Application.Helpers
{
    public class RangeFromLessThanRangeToAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var category = (CategoryDetailsDto)validationContext.ObjectInstance;

            if (category != null && value is decimal rangeFrom)
            {
                // Check if RangeTo is not null
                if (category.RangeTo.HasValue)
                {
                    // Check if RangeFrom is greater than or equal to RangeTo
                    if (rangeFrom >= category.RangeTo)
                    {
                        return new ValidationResult("RangeFrom must be less than RangeTo.");
                    }
                }
            }

            // Validation is successful
            return ValidationResult.Success;
        }
    }
}
#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using System.ComponentModel.DataAnnotations;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Application.Helpers
{
    /// <summary>
    /// Custom validation attribute to check if RangeFrom is less than RangeTo in CategoryDetailsDto.
    /// </summary>
    public class RangeFromLessThanRangeToAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates if RangeFrom is less than RangeTo.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating whether the validation succeeded.</returns>
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

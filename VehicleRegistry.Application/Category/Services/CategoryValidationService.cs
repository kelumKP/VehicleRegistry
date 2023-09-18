using System;
using System.Collections.Generic;
using System.Linq;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Application.Category.Services
{
    public class CategoryValidationService : ICategoryValidationService
    {
        public bool IsCategoryValidForInsert(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto newCategory)
        {
            // Check if the new category overlaps with any existing category
            foreach (var existingCategory in existingCategories)
            {
                if (newCategory.RangeTo == null)
                {
                    // If the new category has no upper bound (RangeTo is null),
                    // it should not overlap with any existing category
                    if (newCategory.RangeFrom >= existingCategory.RangeFrom &&
                        newCategory.RangeFrom <= existingCategory.RangeTo)
                    {
                        return false; // Overlaps with an existing category
                    }
                }
                else if (newCategory.RangeFrom >= existingCategory.RangeFrom &&
                         newCategory.RangeFrom <= existingCategory.RangeTo)
                {
                    return false; // Overlaps with an existing category
                }
            }

            // Other validation rules, such as ensuring the minimum RangeFrom or maximum RangeTo, can be added here.

            return true; // The new category is valid for insertion
        }

        public bool IsCategoryValidForUpdate(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory)
        {
            // Check if the updated category is valid for update
            var existingCategory = existingCategories.FirstOrDefault(c => c.CategoryId == updatedCategory.CategoryId);
            if (existingCategory == null)
            {
                // Category to update not found in existing categories
                return false;
            }

            if (existingCategory.RangeFrom == updatedCategory.RangeFrom && existingCategory.RangeTo == updatedCategory.RangeTo)
            {
                // No change in RangeFrom and RangeTo, which is considered valid
                return true;
            }

            // Check for gaps and overlaps with other categories
            foreach (var category in existingCategories)
            {
                if (category.CategoryId != updatedCategory.CategoryId && IsOverlap(category, updatedCategory))
                {
                    return false; // Overlaps with another category
                }
            }

            return true; // No gaps or overlaps found
        }

        private bool IsOverlap(CategoryDetailsDto category1, CategoryDetailsDto category2)
        {
            // Check for an overlap between two categories
            var rangeTo1 = category1.RangeTo ?? decimal.MaxValue;
            var rangeFrom2 = category2.RangeFrom;

            return rangeTo1 >= rangeFrom2;
        }
    }
}

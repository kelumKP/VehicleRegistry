﻿using System;
using System.Collections.Generic;
using System.Linq;
using VehicleRegistry.Application.Category;
using VehicleRegistry.Application.Category.Services;

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
        public bool IsCategoryValidForUpdate(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory, CategoryDetailsDto existingCategory)
        {
            // Check if the updated category has the same RangeFrom and RangeTo values as the existing category
            if (updatedCategory.RangeFrom == existingCategory.RangeFrom &&
                updatedCategory.RangeTo == existingCategory.RangeTo)
            {
                // It's valid if the updated category's Id matches the existing category's Id
                return updatedCategory.CategoryId == existingCategory.CategoryId;
            }

            // Check for gaps and overlaps
            return !IsGap(existingCategories, updatedCategory) && !IsOverlap(existingCategories, updatedCategory);
        }

        public bool IsGap(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory)
        {
            // Check for a gap between the updated category and all existing categories
            foreach (var existingCategory in existingCategories)
            {
                if (IsGap(existingCategory, updatedCategory))
                {
                    return true; // Gap found
                }
            }
            return false; // No gap found
        }

        public bool IsOverlap(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory)
        {
            // Check for an overlap between the updated category and all existing categories
            foreach (var existingCategory in existingCategories)
            {
                if (IsOverlap(existingCategory, updatedCategory))
                {
                    return true; // Overlap found
                }
            }
            return false; // No overlap found
        }

        private bool IsGap(CategoryDetailsDto category1, CategoryDetailsDto category2)
        {
            // Check for a gap between two categories
            var rangeTo1 = category1.RangeTo ?? decimal.MaxValue;
            var rangeFrom2 = category2.RangeFrom;

            return rangeTo1 + 1 != rangeFrom2;
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

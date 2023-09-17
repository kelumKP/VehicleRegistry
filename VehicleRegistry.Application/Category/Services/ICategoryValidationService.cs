using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Services
{
    public interface ICategoryValidationService
    {
        bool IsCategoryValidForInsert(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto newCategory);
        bool IsCategoryValidForUpdate(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory, CategoryDetailsDto existingCategory);
        bool IsGap(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory);
        bool IsOverlap(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory);
    }
}

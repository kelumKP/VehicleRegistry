using System.Collections.Generic;
using VehicleRegistry.Application.Category;

namespace VehicleRegistry.Application.Category.Services
{
    public interface ICategoryValidationService
    {
        bool IsCategoryValidForInsert(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto newCategory);
        bool IsCategoryValidForUpdate(List<CategoryDetailsDto> existingCategories, CategoryDetailsDto updatedCategory);
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand  : IRequest<CategoryDetailsDto>
    {
        public CategoryDetailsDto NewCategory {  get; set; }
    }
}

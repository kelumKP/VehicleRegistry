﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<List<CategoryDetailsDto>>
    {
        public int CategoryId { get; set; }
    }
}

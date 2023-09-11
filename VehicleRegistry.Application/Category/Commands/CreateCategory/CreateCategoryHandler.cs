using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Core.Models.Category>
    {
        private readonly DataContext _ctx;
        public CreateCategoryHandler(DataContext ctx) 
        { 
            _ctx = ctx;
        }
        public async Task<Core.Models.Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            _ctx.Categories.Add(request.NewCategory);
            await _ctx.SaveChangesAsync();

            return request.NewCategory;
        }
    }
}

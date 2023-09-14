using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegistry.Application.Category.Commands.CreateCategory;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Icon.Commands.CreateIcon
{
    public class CreateIconHandler : IRequestHandler<CreateIconCommand, Core.Models.Icon>
    {
        private readonly DataContext _ctx;
        public CreateIconHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Core.Models.Icon> Handle(CreateIconCommand request, CancellationToken cancellationToken)
        {
            _ctx.Icons.Add(request.NewIcon);
            await _ctx.SaveChangesAsync();

            return request.NewIcon;
        }
    }
}

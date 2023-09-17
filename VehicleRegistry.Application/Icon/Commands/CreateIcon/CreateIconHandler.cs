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
    public class CreateIconHandler : IRequestHandler<CreateIconCommand, IconDto>
    {
        private readonly DataContext _ctx;
        public CreateIconHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IconDto> Handle(CreateIconCommand request, CancellationToken cancellationToken)
        {
            // Create a new Icon entity from the provided data
            var newIcon = new Core.Models.Icon
            {
                // Map properties from request.NewIcon to the new entity
                Name = request.NewIcon.Name,
                // Add other properties as needed
            };

            // Add the new Icon entity to the context
            _ctx.Icons.Add(newIcon);

            // Save changes to the database to get the generated IconId
            await _ctx.SaveChangesAsync();

            // Create an IconDto from the newly created entity
            var iconDto = new IconDto
            {
                Id = newIcon.Id,
                Name = newIcon.Name,
                // Map other properties as needed
            };

            return iconDto;
        }
    }
}

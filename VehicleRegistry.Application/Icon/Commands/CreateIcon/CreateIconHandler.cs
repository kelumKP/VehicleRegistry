#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;
using VehicleRegistry.DAL;

namespace VehicleRegistry.Application.Icon.Commands.CreateIcon
{
    /// <summary>
    /// Handler for creating a new icon.
    /// </summary>
    public class CreateIconHandler : IRequestHandler<CreateIconCommand, IconDto>
    {
        private readonly DataContext _ctx;

        public CreateIconHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Handles the command to create a new icon.
        /// </summary>
        /// <param name="request">The command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IconDto"/> representing the newly created icon.</returns>
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
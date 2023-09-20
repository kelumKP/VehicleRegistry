#region File Ownership
// File Ownership: Kelum
#endregion

#region File Copyright
// File Copyright: MIT license
#endregion

using MediatR;

namespace VehicleRegistry.Application.Icon.Queries.GetAllIcons
{
    /// <summary>
    /// Represents a query to retrieve all icons.
    /// </summary>
    public class GetAllIconsQuery : IRequest<List<IconDto>>
    {
    }
}


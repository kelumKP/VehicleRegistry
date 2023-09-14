using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Icon.Commands.CreateIcon
{
    public class CreateIconCommand : IRequest<Core.Models.Icon>
    {
        public Core.Models.Icon NewIcon { get; set; }
    }
}

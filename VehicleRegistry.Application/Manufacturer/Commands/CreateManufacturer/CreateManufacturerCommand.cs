﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegistry.Application.Manufacturer.Commands.CreateManufacturer
{
    public class CreateManufacturerCommand : IRequest<Core.Models.Manufacturer>
    {
        public Core.Models.Manufacturer NewManufacturer { get; set; }
    }
}
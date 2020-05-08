using Project.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Model
{
    public class VehicleFilter : IVehicleFilter
    {
        public string sortOrder { get; set; }
        public string searchString { get; set; }

    }
}

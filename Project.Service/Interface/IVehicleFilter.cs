using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Interface
{
    public interface IVehicleFilter
    {
        string sortOrder { get; set; }

        string searchString { get; set; }

    }
}

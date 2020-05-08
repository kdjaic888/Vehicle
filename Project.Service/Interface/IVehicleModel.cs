using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Interface.Interface
{
    public interface IVehicleModel
    {
        int id { get; set; }

        int makeId { get; set; }

        string name { get; set; }

        string abrv { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Interface.Interface;
using Microsoft.Extensions.Logging;
using Project.Service.DataContext;

namespace Project.Service.Model
{
    public class VehicleModel:IVehicleModel
    {
        private readonly ILogger<VehicleModel> _logger;

        public VehicleModel(ILogger<VehicleModel> logger)
        {
            _logger = logger;
        }

        public VehicleModel()
        {

        }

        public int id { get; set; }

        public int makeId { get; set; }

        public string name { get; set; }

        public string abrv { get; set; }
    }
}

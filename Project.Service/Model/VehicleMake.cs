using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Project.Interface.Interface;
using Microsoft.Extensions.Logging;
using Project.Service.DataContext;

namespace Project.Service.Model
{
    public class VehicleMake:IVehicleMake
    {
        private readonly ILogger<VehicleMake> _logger;


        public VehicleMake(ILogger<VehicleMake> logger)
        {
            _logger = logger;
        }

        public VehicleMake()
        {
           
        }

        public int id { get; set; }

        public string name { get; set; }

        public string abrv { get; set; }
    }
}

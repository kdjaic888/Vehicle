using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.Model;
using Project.Service.ViewModel;

namespace Project.MVC
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>();
            CreateMap<VehicleModel, VehicleModelViewModel>(); 
        }
    }
}

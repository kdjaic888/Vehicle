using Project.Interface.Interface;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Project.Service.Interface
{
    public interface IVehicleModelService
    {
        IEnumerable<VehicleModel> GetVehicleModel();
        VehicleModel GetVehicleModelById(int id);
        void InsertVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(int id);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void SaveVehicleModel();
        Task OnGetAsync(string sortOrder);
        Task OnGetAsync(string sortOrder, string searchString);
        Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex);

    }
}

using Project.Interface.Interface;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interface
{
    public interface IVehicleMakeService
    {
        IEnumerable<VehicleMake> GetVehicleMake();
        VehicleMake GetVehicleMakeById(int id);
        void InsertVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicleMake(int id);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        void SaveVehicleMake();
        Task OnGetAsync(string sortOrder);
        Task OnGetAsync(string sortOrder, string searchString);
        Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex);

    }
}

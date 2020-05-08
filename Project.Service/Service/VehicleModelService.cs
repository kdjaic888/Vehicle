using Microsoft.EntityFrameworkCore;
using Project.Interface.Interface;
using Project.Service.DataContext;
using Project.Service.Interface;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

namespace Project.Service.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private EFDbContext _context;
        private IMapper mapper;
        public IList<VehicleModel> vehicleModel { get; set; }
        public string nameSort { get; set; }
        public string abrvSort { get; set; }
        public string currentFilter { get; set; }
        public string currentSort { get; set; }

        public VehicleModelService(EFDbContext vehicleModelContext, IMapper mapper)
        {
            this._context = vehicleModelContext;
            this.mapper=mapper;
        }

        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = _context.VehicleModel.Find(id);
            _context.VehicleModel.Remove(vehicleModel);
        }

        public IEnumerable<VehicleModel> GetVehicleModel()
        {
            return _context.VehicleModel.ToList();
        }

        public VehicleModel GetVehicleModelById(int id)
        {
            return _context.VehicleModel.Find(id);
        }

        public void InsertVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModel.Add(vehicleModel);
        }

        public void SaveVehicleModel()
        {
            _context.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            _context.Entry(vehicleModel).State = EntityState.Modified;
        }

        public async Task OnGetAsync(string sortOrder)
        {
            nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            abrvSort = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            IQueryable<VehicleModel> vehicleModelIQ = from s in _context.VehicleModel
                                                    select s;

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.name);
                    break;
            }

            vehicleModel = await vehicleModelIQ.AsNoTracking().ToListAsync();
        }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            abrvSort = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            currentFilter = searchString;

            IQueryable<VehicleModel> vehicleModelIQ = from s in _context.VehicleModel
                                                    select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModelIQ = vehicleModelIQ.Where(s => s.name.Contains(searchString)
                                       || s.abrv.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.name);
                    break;
            }

            vehicleModel = await vehicleModelIQ.AsNoTracking().ToListAsync();
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            currentSort = sortOrder;
            nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            abrvSort = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            currentFilter = searchString;

            IQueryable<VehicleModel> vehicleModelIQ = from s in _context.VehicleModel
                                                    select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModelIQ = vehicleModelIQ.Where(s => s.name.Contains(searchString)
                                       || s.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleModelIQ = vehicleModelIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleModelIQ = vehicleModelIQ.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 3;
            vehicleModel = await PagingParameters<VehicleModel>.CreateAsync(
                vehicleModelIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

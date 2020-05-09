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
    public class VehicleMakeService : IVehicleMakeService
    {
        private EFDbContext _context;
        private IMapper mapper;
        public IList<VehicleMake> vehicleMake { get; set; }
        public string nameSort { get; set; }
        public string abrvSort { get; set; }
        public string currentFilter { get; set; }
        public string currentSort { get; set; }

        public VehicleMakeService(EFDbContext vehicleMakeContext, IMapper mapper)
        {
            this._context = vehicleMakeContext;
            this.mapper=mapper;
        }

        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = _context.VehicleMake.Find(id);
            _context.VehicleMake.Remove(vehicleMake);
        }

        public IEnumerable<VehicleMake> GetVehicleMake()
        {
            return _context.VehicleMake.ToList();
        }

        public VehicleMake GetVehicleMakeById(int id)
        {
            return _context.VehicleMake.Find(id);
        }

        public void InsertVehicleMake(VehicleMake vehicleMake)
        {
            _context.VehicleMake.Add(vehicleMake);
        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            _context.Entry(vehicleMake).State = EntityState.Modified;
        }

        public void SaveVehicleMake()
        {
            _context.SaveChanges();
        }

        public async Task OnGetAsync(string sortOrder)
        {
            nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            abrvSort = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            IQueryable<VehicleMake> vehicleMakeIQ = from s in _context.VehicleMake
                                             select s;

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.name);
                    break;
            }

            vehicleMake = await vehicleMakeIQ.AsNoTracking().ToListAsync();
        }


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            abrvSort = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            currentFilter = searchString;

            IQueryable<VehicleMake> vehicleMakeIQ = from s in _context.VehicleMake
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakeIQ = vehicleMakeIQ.Where(s => s.name.Contains(searchString)
                                       || s.abrv.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.name);
                    break;
            }

            vehicleMake = await vehicleMakeIQ.AsNoTracking().ToListAsync();
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

            IQueryable<VehicleMake> vehicleMakeIQ = from s in _context.VehicleMake
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakeIQ = vehicleMakeIQ.Where(s => s.name.Contains(searchString)
                                       || s.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.name);
                    break;
                case "Abrv":
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.abrv);
                    break;
                case "abrv_desc":
                    vehicleMakeIQ = vehicleMakeIQ.OrderByDescending(s => s.abrv);
                    break;
                default:
                    vehicleMakeIQ = vehicleMakeIQ.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 3;
            vehicleMake = await PagingParameters<VehicleMake>.CreateAsync(
                vehicleMakeIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

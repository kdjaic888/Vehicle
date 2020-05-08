using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Interface;
using Project.Service.Model;
using AutoMapper;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this._vehicleMakeService = vehicleMakeService;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {           
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                _vehicleMakeService.InsertVehicleMake(vehicleMake);
                _vehicleMakeService.SaveVehicleMake();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            VehicleMake model = _vehicleMakeService.GetVehicleMakeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(VehicleMake model)
        {
            if (ModelState.IsValid)
            {
                _vehicleMakeService.UpdateVehicleMake(model);
                _vehicleMakeService.SaveVehicleMake();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteVehicleMake(int id)
        {
            VehicleMake model = _vehicleMakeService.GetVehicleMakeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _vehicleMakeService.DeleteVehicleMake(id);
            _vehicleMakeService.SaveVehicleMake();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            VehicleMake vehicleMake = _vehicleMakeService.GetVehicleMakeById(id);
            return View(vehicleMake);
        }

        public ActionResult SortingVehicleMake(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            var vehicleMake = from v in _vehicleMakeService.GetVehicleMake()
                               select v;
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleMake = vehicleMake.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.abrv);
                    break;
                default:
                    vehicleMake = vehicleMake.OrderBy(v => v.name);
                    break;
            }
            return View(vehicleMake.ToList());
        }

        public ActionResult FilteringVehicleMake(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            var vehicleMake = from v in _vehicleMakeService.GetVehicleMake()
                              select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMake = vehicleMake.Where(v => v.name.Contains(searchString)
                                       || v.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleMake = vehicleMake.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.abrv);
                    break;
                default:
                    vehicleMake = vehicleMake.OrderBy(v => v.name);
                    break;
            }
            return View(vehicleMake.ToList());
        }

        public ViewResult PagingVehicleMake(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var vehicleMake = from v in _vehicleMakeService.GetVehicleMake()
                              select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMake = vehicleMake.Where(v => v.name.Contains(searchString)
                                       || v.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleMake = vehicleMake.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleMake = vehicleMake.OrderByDescending(v => v.abrv);
                    break;
                default:  
                    vehicleMake = vehicleMake.OrderBy(v => v.name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vehicleMake.ToPagedList(pageNumber, pageSize));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Interface.Interface;
using Project.Service;
using Project.Service.DataContext;
using Project.Service.Interface;
using Project.Service.Model;
using Project.Service.Service;
using AutoMapper;
using PagedList;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this._vehicleModelService = vehicleModelService;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _vehicleModelService.InsertVehicleModel(vehicleModel);
                _vehicleModelService.SaveVehicleModel();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            VehicleModel model = _vehicleModelService.GetVehicleModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(VehicleModel model)
        {
            if (ModelState.IsValid)
            {
                _vehicleModelService.UpdateVehicleModel(model);
                _vehicleModelService.SaveVehicleModel();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteVehicleModel(int id)
        {
            VehicleModel model = _vehicleModelService.GetVehicleModelById(id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _vehicleModelService.DeleteVehicleModel(id);
            _vehicleModelService.SaveVehicleModel();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            VehicleModel vehicleModel = _vehicleModelService.GetVehicleModelById(id);
            return View(vehicleModel);
        }

        public ActionResult SortingVehicleModel(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            var vehicleModel = from v in _vehicleModelService.GetVehicleModel()
                           select v;
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleModel = vehicleModel.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.abrv);
                    break;
                default:
                    vehicleModel = vehicleModel.OrderBy(v => v.name);
                    break;
            }
            return View(vehicleModel.ToList());
        }

        public ActionResult FilteringVehicleModel(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";
            var vehicleModel = from v in _vehicleModelService.GetVehicleModel()
                              select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModel = vehicleModel.Where(v => v.name.Contains(searchString)
                                       || v.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleModel = vehicleModel.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.abrv);
                    break;
                default:
                    vehicleModel = vehicleModel.OrderBy(v => v.name);
                    break;
            }
            return View(vehicleModel.ToList());
        }

        public ViewResult PagingVehicleModel(string sortOrder, string currentFilter, string searchString, int? page)
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
            var vehicleModel = from v in _vehicleModelService.GetVehicleModel()
                              select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModel = vehicleModel.Where(v => v.name.Contains(searchString)
                                       || v.abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.name);
                    break;
                case "Abrv":
                    vehicleModel = vehicleModel.OrderBy(v => v.abrv);
                    break;
                case "abrv_desc":
                    vehicleModel = vehicleModel.OrderByDescending(v => v.abrv);
                    break;
                default:
                    vehicleModel = vehicleModel.OrderBy(v => v.name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vehicleModel.ToPagedList(pageNumber, pageSize));
        }
    }
}

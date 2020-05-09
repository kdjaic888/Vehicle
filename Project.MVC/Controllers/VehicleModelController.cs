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

       
    }
}

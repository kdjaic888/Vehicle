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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Service;
using Project.Service.DataContext;
using Project.Service.Model;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        public EFDbContext _dbContext = new EFDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<VehicleModel> vehmodel = this._dbContext.VehicleModel.ToList();
            return View(vehmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View();
        }
        /*[HttpPost]
        public ActionResult Delete(int Id)
        {
            return View();
        }*/
    }
}
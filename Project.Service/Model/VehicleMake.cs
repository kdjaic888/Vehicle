using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Project.Interface.Interface;

namespace Project.Service.Model
{
    public class VehicleMake:IVehicleMake
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Abrv")]
        [Display(Name = "Abrv")]
        public string Abrv { get; set; }
    }
}

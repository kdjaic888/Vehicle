using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ViewModel
{
    public class VehicleMakeViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter abrv")]
        [Display(Name = "abrv")]
        public string abrv { get; set; }
    }
}

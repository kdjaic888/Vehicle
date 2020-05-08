using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ViewModel
{
    public class VehicleModelViewModel
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("MakeId")]
        public int makeId { get; set; }

        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter abrv")]
        [Display(Name = "abrv")]
        public string abrv { get; set; }
    }
}

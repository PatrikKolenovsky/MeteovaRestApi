using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Location
{
    public class LocationCreateDto
    {
        [Required(ErrorMessage = "Latitude is required")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longtitude is required")]
        public double Longtitude { get; set; }

        [Required(ErrorMessage = "Adress is required")]
        public string Adress { get; set; }

        public int Zipcode { get; set; }
    }
}

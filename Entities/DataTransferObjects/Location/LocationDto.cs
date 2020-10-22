using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Location
{
    public class LocationDto
    {
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string Adress { get; set; }
        public int Zipcode { get; set; }
    }
}

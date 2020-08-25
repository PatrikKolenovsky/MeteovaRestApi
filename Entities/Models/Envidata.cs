using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Envidata
    {
        [Key]
        public string RecordedTime { get; set; }
        public string DeviceId { get; set; }
        public int Lat { get; set; }
        public int Lon { get; set; }
        public int NO2 { get; set; }
        public int NOISE_AVG { get; set; }
        public int NOISE_MAX { get; set; }
        public int PM01 { get; set; }
        public int PM10 { get; set; }
        public int PM25 { get; set; }
    }
}

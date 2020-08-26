using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EnvidataDto
    {
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

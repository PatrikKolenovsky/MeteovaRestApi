using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Device
{
    public class DeviceUpdateDto
    {
        [StringLength(45, ErrorMessage = "DeviceName cannot be longer than 45 characters")]
        public string DeviceName { get; set; }

        [StringLength(45, ErrorMessage = "Ip cannot be longer than 45 characters")]
        public string Ip { get; set; }

        public int Port { get; set; }

        [StringLength(45, ErrorMessage = "ComServIp cannot be longer than 45 characters")]
        public string ComServIp { get; set; }

        public int ComServPort { get; set; }

        public bool InUse { get; set; }

        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [StringLength(45, ErrorMessage = "Address cannot be longer than 45 characters")]
        public string Address { get; set; }
    }
}

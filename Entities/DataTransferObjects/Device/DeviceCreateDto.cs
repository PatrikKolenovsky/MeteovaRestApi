using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Device
{
    public class DeviceCreateDto
    {
        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string DeviceName { get; set; }

        [Required(ErrorMessage = "IP is required")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Port is required")]
        public int Port { get; set; }

        [Required(ErrorMessage = "ComServIP is required")]
        public string ComServIp { get; set; }

        [Required(ErrorMessage = "ComServPort is required")]
        public int ComServPort { get; set; }

        [Required(ErrorMessage = "Latitude is required")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Address { get; set; }

        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class DeviceForCreationDto
    {
        [Required(ErrorMessage = "DeviceNameId is required")]
        public int DeviceNameId { get; set; }

        [Required(ErrorMessage = "IP is required")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Port is required")]
        public int Port { get; set; }

        [Required(ErrorMessage = "ComServIP is required")]
        public string ComServIp { get; set; }

        [Required(ErrorMessage = "ComServPort is required")]
        public int ComServPort { get; set; }

        [Required(ErrorMessage = "ComTypeID is required")]
        public int ComTypeId { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Device location cannot be longer than 100 characters")]
        public string Device_location { get; set; }
    }
}

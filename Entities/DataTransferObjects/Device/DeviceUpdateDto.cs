using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class DeviceUpdateDto
    {

        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Device location cannot be longer than 100 characters")]
        public string DeviceLocation { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class DeviceForUpdateDto
    {

        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Device location cannot be longer than 100 characters")]
        public string Device_location { get; set; }
    }
}

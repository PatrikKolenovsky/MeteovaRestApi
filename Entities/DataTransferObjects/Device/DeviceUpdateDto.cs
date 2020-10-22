using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Device
{
    public class DeviceUpdateDto
    {
        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }
    }
}

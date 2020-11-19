using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Module
{
    public class ModuleCreateDto
    {
        [Required(ErrorMessage = "Name of the module is required!")]
        [StringLength(45, ErrorMessage = "Name cannot be longer than 45 characters")]
        public string Name { get; set; }

        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DeviceId is required!")]
        public int DeviceId { get; set; }

        [Required(ErrorMessage = "ModuleTypeId required!")]
        public int ModuleTypeId { get; set; }
    }
}

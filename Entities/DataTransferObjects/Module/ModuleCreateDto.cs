using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects.Module
{
    public class ModuleCreateDto
    {
        [Required(ErrorMessage = "Name of the module is required!")]
        [StringLength(45, ErrorMessage = "Name cannot be longer than 45 characters")]
        public string Name { get; set; }

        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Device required to create module!")]
        public virtual Models.Device Device { get; set; }
        
        [Required(ErrorMessage = "Module type is required to create module!")]
        public virtual Models.Moduletype ModuleType { get; set; }
    }
}

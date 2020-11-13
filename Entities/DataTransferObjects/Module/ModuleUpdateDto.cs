using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Module
{
    public class ModuleUpdateDto
    {
        [StringLength(45, ErrorMessage = "Name cannot be longer than 45 characters")]
        public string Name { get; set; }

        public int ModuleTypeId { get; set; }

        public int DeviceId { get; set; }

        [StringLength(45, ErrorMessage = "ComServIp cannot be longer than 45 characters")]
        public string Description { get; set; }
    }
}

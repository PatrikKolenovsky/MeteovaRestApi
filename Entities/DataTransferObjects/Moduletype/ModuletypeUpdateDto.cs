using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Moduletype
{
    public class ModuletypeUpdateDto
    {
        [StringLength(45, ErrorMessage = "Name cannot be longer than 45 characters")]
        public string Name { get; set; }

        public int MakerId { get; set; }

        [StringLength(45, ErrorMessage = "Description cannot be longer than 45 characters")]
        public string Description { get; set; }
    }
}

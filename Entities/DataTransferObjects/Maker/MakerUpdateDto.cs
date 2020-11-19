using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Maker
{
    public class MakerUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, ErrorMessage = "Name cannot be longer than 45 characters")]
        public string Name { get; set; }
    }
}

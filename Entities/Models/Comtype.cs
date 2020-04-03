using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Comtype
    {
        public Comtype()
        {
            Device = new HashSet<Device>();
        }

        public int ComTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}

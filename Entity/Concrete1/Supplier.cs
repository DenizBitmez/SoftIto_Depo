using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete1
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}

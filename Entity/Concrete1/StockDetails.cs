using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete1
{
    public class StockDetails
    {
        [Key]
        public int StockDetailsId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete1
{
    public class Barcode
    {
        public int BarcodeId { get; set; }
        public string Number { get; set; } // Barkod numarası
        public int ProductId { get; set; } // Ürün ID
        public bool MovementType { get; set; } // true: Giriş, false: Çıkış
        public DateTime CreatedDate { get; set; } // İşlem tarihi

        // Navigation property
        public Product Product { get; set; }
    }
}

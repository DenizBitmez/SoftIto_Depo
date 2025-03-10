using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBarcodeService
    {
        List<Barcode> Barcodeliste();
        void BarcodeInsert(Barcode barcode);
        void BarcodeUpdate(Barcode barcode);
        void BarcodeDelete(Barcode barcode);
        Barcode GetById(int id);
    }
}

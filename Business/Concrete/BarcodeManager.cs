using Business.Abstract;
using Data.Abstract;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BarcodeManager:IBarcodeService
    {
        IBarcodeDal _dal;

        public BarcodeManager(IBarcodeDal dal)
        {
            _dal = dal;
        }

        public void BarcodeDelete(Barcode barcode)
        {
           _dal.Delete(barcode);
        }

        public void BarcodeInsert(Barcode barcode)
        {
            _dal.Insert(barcode);
        }

        public List<Barcode> Barcodeliste()
        {
            return _dal.List();
        }

        public void BarcodeUpdate(Barcode barcode)
        {
            _dal.Update(barcode);
        }

        public Barcode GetById(int id)
        {
            return _dal.GetById(id);
        }
    }
}

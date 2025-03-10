using Business.Abstract;
using Data.Abstract;
using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SupplierManager:ISupplierService
    {
        ISupplierDal dal;

        public SupplierManager(ISupplierDal dal)
        {
            this.dal = dal;
        }

        public Supplier GetById(int id)
        {
           return dal.GetById(id);
        }

        public void SupplierDelete(Supplier s)
        {
           dal.Delete(s);
        }

        public void SupplierInsert(Supplier s)
        {
           dal.Insert(s);
        }

        public List<Supplier> Supplierliste()
        {
            return dal.List();
        }

        public void SupplierUpdate(Supplier s)
        {
           dal.Update(s);
        }
    }
}

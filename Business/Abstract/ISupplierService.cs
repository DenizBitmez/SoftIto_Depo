using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        List<Supplier> Supplierliste();
        void SupplierInsert(Supplier s);
        void SupplierUpdate(Supplier s);
        void SupplierDelete(Supplier s);
        Supplier GetById(int id);
    }
}

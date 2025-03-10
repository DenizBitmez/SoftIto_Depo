using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> Productliste();
        void ProductInsert(Product product);
        void ProductUpdate(Product product);
        void ProductDelete(int id);
        Product GetById(int id);
    }
}

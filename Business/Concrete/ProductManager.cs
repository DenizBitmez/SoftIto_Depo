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
    public class ProductManager:IProductService
    {
        IProductDal _product;

        public ProductManager(IProductDal product)
        {
            _product = product;
        }

        public Product GetById(int id)
        {
            return _product.GetById(id);
        }

        public void ProductDelete(int id)
        {
           _product.Delete(id);
        }

        public void ProductInsert(Product product)
        {
            _product.Insert(product);
        }

        public List<Product> Productliste()
        {
            return _product.List();
        }

        public void ProductUpdate(Product product)
        {
           _product.Update(product);
        }
    }
}

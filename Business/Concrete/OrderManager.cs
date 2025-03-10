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
    public class OrderManager:IOrderService
    {
        IOrderDal _order;

        public OrderManager(IOrderDal order)
        {
            _order = order;
        }

        public Order GetById(int id)
        {
            return _order.GetById(id);
        }

        public void OrderDelete(Order order)
        {
           _order.Delete(order);
        }

        public void OrderInsert(Order order)
        {
            _order.Insert(order);
        }

        public List<Order> Orderliste()
        {
            return _order.List();
        }

        public void OrderUpdate(Order order)
        {
          _order.Update(order);
        }
    }
}

using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> Orderliste();
        void OrderInsert(Order order);
        void OrderUpdate(Order order);
        void OrderDelete(Order order);
        Order GetById(int id);
    }
}

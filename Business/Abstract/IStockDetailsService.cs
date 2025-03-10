using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IStockDetailsService
    {
        List<StockDetails> StockDetailsliste();
        void StockDetailsInsert(StockDetails stockDetails);
        void StockDetailsUpdate(StockDetails stockDetails);
        void StockDetailsDelete(StockDetails stockDetails);
        StockDetails GetById(int id);
    }
}

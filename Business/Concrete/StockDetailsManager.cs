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
    public class StockDetailsManager:IStockDetailsService
    {
        IStockDetailsDal _dal;

        public StockDetailsManager(IStockDetailsDal dal)
        {
            _dal = dal;
        }

        public StockDetails GetById(int id)
        {
            return _dal.GetById(id);
        }

        public void StockDetailsDelete(StockDetails stockDetails)
        {
            _dal.Delete(stockDetails);
        }

        public void StockDetailsInsert(StockDetails stockDetails)
        {
           _dal.Insert(stockDetails);
        }

        public List<StockDetails> StockDetailsliste()
        {
           return _dal.List();
        }

        public void StockDetailsUpdate(StockDetails stockDetails)
        {
           _dal.Update(stockDetails);
        }
    }
}

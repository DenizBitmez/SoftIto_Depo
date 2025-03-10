using Data.Abstract;
using Data.Concrete;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework
{
    public class EFBarcodeDal : GenericRepository<Barcode>, IBarcodeDal
    {
    }
}

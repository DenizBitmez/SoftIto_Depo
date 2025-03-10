using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> Categoryliste();
        void CategoryInsert(Category category);
        void CategoryUpdate(Category category);
        void CategoryDelete(Category category);
        Category GetById(int id);
    }
}

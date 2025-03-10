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
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _category;

        public CategoryManager(ICategoryDal category)
        {
            _category = category;
        }

        public void CategoryDelete(Category category)
        {
            _category.Delete(category);
        }

        public void CategoryInsert(Category category)
        {
            _category.Insert(category);
        }

        public List<Category> Categoryliste()
        {
            return _category.List();
        }

        public void CategoryUpdate(Category category)
        {
           _category.Update(category);
        }

        public Category GetById(int id)
        {
           return _category.GetById(id);
        }
    }
}

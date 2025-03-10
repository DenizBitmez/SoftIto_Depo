using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> Userliste();
        void UserInsert(User u);
        void UserUpdate(User u);
        void UserDelete(User u);
        User GetById(int id);
    }
}

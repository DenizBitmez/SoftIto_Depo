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
    public class UserManager:IUserService
    {
        IUserDal _dal;

        public UserManager(IUserDal dal)
        {
            _dal = dal;
        }

        public User GetById(int id)
        {
           return _dal.GetById(id);
        }

        public void UserDelete(User u)
        {
           _dal.Delete(u);
        }

        public void UserInsert(User u)
        {
           _dal.Insert(u);
        }

        public List<User> Userliste()
        {
           return _dal.List();
        }

        public void UserUpdate(User u)
        {
            _dal.Update(u);
        }
    }
}

using Core.DataAccess.Entityframework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, ToDoContext>, IUserDal
    {
        ToDoContext _context = new ToDoContext();
        public void AddUser(User user)
        {

        }
        public int GetUserMailAndPassword(string userMail, string password)
        {
            User user = _context.Users.Where(x => x.Email == userMail).Where(y => y.Password == password).FirstOrDefault();
            if (user != null)
            {
                return user.UserID;
            }
            return 0;
        }

    }
}

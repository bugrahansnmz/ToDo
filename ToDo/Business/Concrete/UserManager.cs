using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            if (user != null)
            {
                user.Status = true;
                _userDal.Add(user);
            }
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User Get(int? userID)
        {
            return _userDal.Get(x => x.UserID == userID);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll().ToList();
        }

        public int GetUserLogin(string email, string password)
        {
            if (email != null && password != null)
            {
                return _userDal.GetUserMailAndPassword(email, password);
            }
            return 0;
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}

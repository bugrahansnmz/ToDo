using Core.DataAccess.Entityframework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFReminderDal : EFEntityRepositoryBase<Reminder, ToDoContext>, IReminderDal
    {
    }
}

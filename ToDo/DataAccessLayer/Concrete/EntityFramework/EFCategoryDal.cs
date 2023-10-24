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
    public class EFCategoryDal : EFEntityRepositoryBase<Category,ToDoContext>,ICategoryDal
    {
    }
}

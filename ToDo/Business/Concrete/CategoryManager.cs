using Business.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
           _categoryDal.Add(category);
        }

        public void Delete(int categoryID)
        {
            var category = _categoryDal.Get(x=>x.CategoryID==categoryID);
            _categoryDal.Delete(category);
        }

        public Category Get(int categoryID)
        {
            var cateogry = _categoryDal.Get(x=>x.CategoryID==categoryID);
            return cateogry;
        }

        public List<Category> GetAll(int? userID)
        {
           return _categoryDal.GetAll(x=>x.UserID == userID);
        }

        public void Update(Category category)
        {
           _categoryDal.Update(category);
        }
    }
}

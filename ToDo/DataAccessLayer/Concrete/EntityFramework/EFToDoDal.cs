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
    public class EFToDoDal : EFEntityRepositoryBase<ToDo, ToDoContext>, IToDoDal
    {
        ToDoContext _context = new ToDoContext();
        public List<ToDo> GetAllTodos(string searchText, int? userID)
        {
            return (from p in _context.ToDos
                   where (p.TodoCaption.Contains(searchText) && p.UserID==userID)
                   select p).ToList();
        }
    }
}

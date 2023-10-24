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
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }
        public void Add(ToDo todo)
        {
           _toDoDal.Add(todo);
        }

        public void Delete(ToDo todoID)
        {
          _toDoDal.Delete(todoID);
        }

        public ToDo Get(int todoID)
        {
            return _toDoDal.Get(x => x.TodoID == todoID);
        }

        public List<ToDo> GetAll(int? userID)
        {
            return _toDoDal.GetAll(x=>x.UserID == userID).ToList();
        }

        public List<ToDo> GetAllTodos(string searchText, int? userID)
        {
            return _toDoDal.GetAllTodos(searchText,userID);
        }

        public void Update(ToDo todo)
        {
          _toDoDal.Update(todo);
        }
    }
}

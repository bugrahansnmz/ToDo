using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        List<ToDo> GetAll(int? userID);
        ToDo Get(int todoID);
        void Add(ToDo todo);
        void Update(ToDo todo);
        void Delete(ToDo todoID);
        List<ToDo> GetAllTodos(string searchText, int? userID);
    }
}

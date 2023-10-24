using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IToDoDal:IEntityRepository<ToDo>
    {
        List<ToDo> GetAllTodos(string searchText, int? userID);
    }
}

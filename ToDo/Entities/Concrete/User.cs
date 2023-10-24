using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User :IEntity
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public ICollection<Category> Categories { get; set; }

        public ICollection<ToDo> ToDos { get; set; }
    }
}

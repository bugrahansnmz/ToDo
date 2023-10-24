using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ToDo:IEntity
    {
        [Key]
        public int TodoID{ get; set; }
        public string TodoCaption { get; set; }
        public string TodoDescription { get; set; }
        public bool IsComplated { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public bool PriorityLevel { get; set; }
        public bool Status{ get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public User User { get; set; }
        public int? UserID { get; set; }
    }
}

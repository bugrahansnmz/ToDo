using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reminder:IEntity
    {
        [Key]
        public int ReminderID { get; set; }
        public string ReminderCation { get; set; }
        public string ReminderDesc { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool  Status { get; set; }

    }
}

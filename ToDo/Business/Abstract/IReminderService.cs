using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReminderService
    {
        List<Reminder> GetAll();
        Reminder Get(int reminderID);
        void Add(Reminder reminder);
        void Update(Reminder reminder);
        void Delete(Reminder reminderID);
    }
}

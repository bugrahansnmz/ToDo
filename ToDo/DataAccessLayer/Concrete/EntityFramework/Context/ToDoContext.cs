using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Context
{
    public class ToDoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BUGRA\\SQLEXPRESS01;database=DbToDo; integrated security = true; trusted_connection=true; TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<ToDo> ToDos { get; set; } 
        public DbSet<Reminder> Reminders { get; set; } 
    }
}

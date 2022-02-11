using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace todo_list.Models
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = C:\Users\Lenovo\source\repos\todo list\todo list\DB\DbToDoListe.db");
        }
        public DbSet<List> Lists { get; set; }
        public object List { get; internal set; }

      
    }
}

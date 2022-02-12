using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_list.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tache { get; set; }
        public DateTime Date { get; set; }
        public int completed { get; set; } 
    }
}

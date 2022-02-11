using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_list.Models;

namespace todo_list.ControlleurList
{
    public class ControlleurListe
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        
        public bool Add(List list)
        {
            _dbContext.Lists.Add(list);
            return _dbContext.SaveChanges()>0;
        }
        public List<List> GetAll()
        {
            return _dbContext.Lists.ToList();
        }
        public bool Update(List list)
        {
            var data = _dbContext.Lists.FirstOrDefault(c=>c.Id==list.Id);
            if (data == null)
            {
                return false;
            }
            data.Date = list.Date;
            data.Description = list.Description;
            data.Tache = list.Tache;
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var list = _dbContext.Lists.FirstOrDefault(s => s.Id == id);
            if(list == null)
            {
                return false;
            }
            _dbContext.Lists.Remove(list);
            return _dbContext.SaveChanges()>0;
        }
    }
}

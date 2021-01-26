using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class MenuService
    {
        public List<MenuItem> MenuItems { get; set; }
        private ApplicationDbContext DbContext { get; set; }
        public MenuService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public List<MenuItem> GetMenu()
        {
            return DbContext.ArticleMenuItems.ToList();
        }
        public void AddMenuItem(MenuItem item)
        {
            DbContext.ArticleMenuItems.Add(item);
            DbContext.SaveChanges();
        }
        public void RemoveMenuItem(int id)
        {
            DbContext.ArticleMenuItems.Remove(DbContext.ArticleMenuItems.FirstOrDefault((i) => i.Id == id));
            DbContext.SaveChanges();
        }
    }
}

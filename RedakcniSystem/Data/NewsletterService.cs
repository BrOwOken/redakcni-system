using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;

namespace RedakcniSystem.Data
{
    public class NewsletterService
    {
        private ApplicationDbContext DbContext { get; set; }
        public NewsletterService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public bool IsRegistered(string email)
        {
            if (DbContext.Newsletters.Contains(DbContext.Newsletters.FirstOrDefault(e => e.Email == email)))
            {
                return true;
            }
            return false;
        }
        public void SignupEmail(string email)
        {
            DbContext.Newsletters.Add(new Models.Newsletter() { Email = email });
            DbContext.SaveChanges();
        }
        public void RemoveEmail(string email)
        {
            DbContext.Newsletters.Remove(DbContext.Newsletters.FirstOrDefault(e => e.Email == email));
            DbContext.SaveChanges();
        }
        public List<Newsletter> GetEmails()
        {
            return DbContext.Newsletters.ToList();
        }
    }
}

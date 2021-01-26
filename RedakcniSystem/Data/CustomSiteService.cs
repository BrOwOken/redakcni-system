using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class CustomSiteService
    {
        private ApplicationDbContext DbContext;
        public CustomSiteService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public void AddSite(CustomSite site)
        {
            DbContext.CustomSites.Add(site);
            DbContext.SaveChanges();
        }
        public void RemoveSite(int id)
        {
            DbContext.CustomSites.Remove(DbContext.CustomSites.FirstOrDefault((s) => s.Id == id));
            DbContext.SaveChanges();
        }
        public CustomSite GetSite(int id)
        {
            return DbContext.CustomSites.FirstOrDefault((s) => s.Id == id);
        }
        public List<CustomSite> UserGetSites(string userId)
        {
            var sites = DbContext.CustomSites.ToList();
            List<CustomSite> userSites = new List<CustomSite>();
            foreach (var site in sites)
            {
                if(site.UserId == userId)
                {
                    userSites.Add(site);
                }
            }
            return userSites;
        }
    }
}

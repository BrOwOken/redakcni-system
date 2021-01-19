using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class ArticleService
    {
        private ApplicationDbContext DbContext { get; set; }
        public ArticleService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public List<Article> GetArticles()
        {
            return DbContext.Articles.ToList();
        }
        public void AddArticle(Article article)
        {
            DbContext.Articles.Add(article);
            DbContext.SaveChanges();
        }
        public void DeleteArticle(int id)
        {
            DbContext.Articles.Remove(DbContext.Articles.FirstOrDefault((a) => a.Id == id));
            DbContext.SaveChanges();
        }
        public void EditArticle(Article article)
        {
            var temp = GetArticle(article.Id);
            DbContext.Entry(temp).CurrentValues.SetValues(article);
            DbContext.SaveChanges();
        }
        public Article GetArticle(int id)
        {
            return DbContext.Articles.FirstOrDefault((a) =>  a.Id == id );
        }
    }
}

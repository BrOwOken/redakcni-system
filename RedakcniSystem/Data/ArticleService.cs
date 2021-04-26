using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;

namespace RedakcniSystem.Data
{
    public class ArticleService
    {
        private ApplicationDbContext DbContext { get; set; }
        private UsersService usersService;
        public ArticleService(ApplicationDbContext dbContext, UsersService usersService)
        {
            this.DbContext = dbContext;
            this.usersService = usersService;
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
            return DbContext.Articles.FirstOrDefault((a) => a.Id == id);
        }
        public void AddFavoriteArticle(int articleId)
        {
            var article = DbContext.Articles.FirstOrDefault((a) => a.Id == articleId);
            var user = usersService.GetCurrentUser();
            DbContext.Favorites.Add(new Favorites(user, article));
            DbContext.SaveChanges();
        }
        public void RemoveFavouriteArticle(int favoriteId)
        {
            var fav = DbContext.Favorites.FirstOrDefault((a) => a.Id == favoriteId);
            DbContext.Favorites.Remove(fav);
            DbContext.SaveChanges();
        }
        public bool IsFavourited(int articleId)
        {
            var userId = usersService.GetCurrentUserId();
            foreach (var favorites in DbContext.Favorites)
            {
                var fav = DbContext.Favorites.FirstOrDefault((a) => a.Id == favorites.Id);
                if (fav.UserId == userId)
                {
                    if (fav.ArticleId == articleId)
                    {
                        return true;
                    }
                    else continue;
                }
            }
            return false;
            
        }
        public List<Favorites> GetFavourites()
        {
            var user = usersService.GetCurrentUser();
            List<Favorites> favs = new List<Favorites>();
            foreach (var fav in DbContext.Favorites)
            {
                var f = DbContext.Favorites.FirstOrDefault((a) => a.Id == fav.Id);
                if (f.UserId == user.Id)
                {
                    favs.Add(f);
                }
            }
            return favs;
        }
    }
}

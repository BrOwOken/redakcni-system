using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data.Models
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ArticleId { get; set; }
        public Favorites(IdentityUser user, Article article)
        {
            UserId = user.Id;
            ArticleId = article.Id;
        }
        public Favorites()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string AlbumName { get; set; }

        public Article(string title, string author, string content, string imageUrl, string tags)
        {
            Title = title;
            Author = author;
            Content = content;
            ImageUrl = imageUrl;
            Tags = tags;
        }
        public Article()
        {

        }
    }
}

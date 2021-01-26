using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public MenuItem(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public MenuItem()
        {

        }
    }
}

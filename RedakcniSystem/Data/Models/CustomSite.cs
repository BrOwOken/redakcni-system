using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class CustomSite
    {
        [Key]
        public int Id { get; set; }
        public string Html { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }


    }
}

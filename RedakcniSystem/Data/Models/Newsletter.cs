using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data.Models
{
    public class Newsletter
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}

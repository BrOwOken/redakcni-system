using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RedakcniSystem.Controllers
{
    public class MailController : Controller
    {
        [Route("/email")]
        public IActionResult Email()
        {
            return View(new MailModel()
                {
                    Email = "prd@el.me",
                    Text = "Uwu nuzzles chci se zabit daddy uwu suwucide",
                    Title = "18 yo commits suwucide because of his website programming class's teacher"
                }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Movie_Ladder.Controllers
{
    public class SearchController : Controller
    {
        // GET: /Search/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Search/Movie
        public IActionResult Movie(string title)
        {
            ViewData["MovieTitle"] = title;

            return View();
        }
    }
}

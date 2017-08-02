using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedApp.Models;
using FeedApp.Parsers;

namespace FeedApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //var items = FeedParser.Parse(new FeedSource() { Url = "http://www.nt.se/nyheter/norrkoping/rss/" });
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}

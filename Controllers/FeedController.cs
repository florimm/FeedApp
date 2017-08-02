using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedApp.Parsers;
using FeedApp.Models;
using FeedApp.Database;
using Microsoft.EntityFrameworkCore;
using FeedApp.Utils;
using FeedApp.ViewModels;

namespace FeedApp.Controllers
{
    [Route("api/[controller]")]
    public class FeedController : Controller
    {
        private FeedDbContext dbContext;
        public FeedController(FeedDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("[action]")]
        [ETag]
        public async Task<IEnumerable<FeedSourceViewModel>> Sources()
        {
            return (await dbContext.FeedSources.ToListAsync()).ToViewModel();
        }

        [HttpGet("[action]/{id}")]
        [ETag]
        public async Task<IEnumerable<NewsItemViewModel>> Items(int id)
        {
            return (await dbContext.NewsItems.Where(t => t.FeedSourceId == id).Include(t=> t.FeedSource).ToListAsync()).ToViewModel();
        }
    }
}

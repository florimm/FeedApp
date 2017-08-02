using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FeedApp.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DNTScheduler.Core.Contracts;
using FeedApp.Parsers;
using FeedApp.Utils;
using System;
using FeedApp.Models;
using System.Collections.Generic;

namespace FeedApp.Services
{
    public class FeedFetcherService : IScheduledTask
    {
        private FeedDbContext dbContext;
        private readonly ILogger<FeedFetcherService> logger;

        public FeedFetcherService(
            FeedDbContext dbContext,
            ILogger<FeedFetcherService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public bool IsShuttingDown { get; set; }

        public async Task RunAsync()
        {

            if (this.IsShuttingDown)
            {
                return;
            }
            var sources = await dbContext.FeedSources.ToListAsync();
            foreach (var source in sources)
            {
                var rssDoc = FeedLoader.LoadUrlAndParseAsXml(source.Url, source.EncodingType);

                var items = FeedParser.Parse(source.Id, rssDoc);
                var oldItems = dbContext.NewsItems.Where(t => t.FeedSourceId == source.Id).ToList();
                if (HasNewNewsItems(items, oldItems))
                {
                    source.LastFetched = DateTime.Now;
                    dbContext.NewsItems.RemoveRange(oldItems);
                    dbContext.NewsItems.AddRange(items);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private bool HasNewNewsItems(List<NewsItem> items, List<NewsItem> oldItems)
        {
            if (oldItems.Count() == 0 && items.Count() > 0)
            {
                return true;
            }
            if (oldItems.Count() > 0 && items.Count() == 0)
            {
                return false;
            }
            var newestItemByDate = items.OrderByDescending(t => t.Timestamp).First();
            var newestOldItemByDate = oldItems.OrderByDescending(t => t.Timestamp).First();
            if(newestItemByDate.Id == newestOldItemByDate.Id)
            {
                return false;
            }
            return true;
        }
    }

}
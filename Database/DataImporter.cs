using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedApp.Models;

namespace FeedApp.Database
{

    /// <summary>
    /// This class seeds FeedSources
    /// </summary>
    public  class DataImporter
    {
        public static bool EnsureFeedSourceData(FeedDbContext context)
        {
            bool hasData = false;
            try
            {
                hasData = context.FeedSources.Any();
            }
            catch
            {
                context.Database.EnsureCreated(); // just create the schema as is no migrations
                hasData = context.FeedSources.Any();
            }


            if (!hasData)
            {
                return Seed(context) > 0;
            }


            return true;
        }

        /// <summary>
        /// Imports data from json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static int Seed(FeedDbContext context)
        {
            var sources = new List<FeedSource>()
            {
                new FeedSource() {Interval = 2, Name = "nt.se", Url= "http://www.nt.se/nyheter/norrkoping/rss/", EncodingType = EncodingType.Default},
                new FeedSource() {Interval = 2, Name = "expressen.se", Url= "http://www.expressen.se/Pages/OutboundFeedsPage.aspx?id=3642159&amp;viewstyle=rss", EncodingType = EncodingType.Default},
                new FeedSource() {Interval = 2, Name = "svd.se", Url= "https://www.svd.se/?service=rss", EncodingType = EncodingType.UTF8},
            };

            foreach (var source in sources)
            {
                // clear out primary/identity keys so insert works
                source.Id = 0;
                context.Add(source);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Error adding: " + source.Url);
                }
            }
            context.SaveChanges();

            return 1;
        }
    }
}
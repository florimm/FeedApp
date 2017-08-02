using FeedApp.Models;
using System;

namespace FeedApp.ViewModels
{
    public class NewsItemViewModel
    {
        public int Id { get; set; }
        public string FeedItemId { get; set; }
        public string Url { get; set; }
        public TimeSpan TimeSincePost { get; set; }
        public DateTime FetchTime { get; set; }
        public string Source { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public FeedType FeedType { get; set; }
        public int FeedSourceId { get; set; }
    }
}

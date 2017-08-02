using System;

namespace FeedApp.Models
{
    public class NewsItem
    {
		public NewsItem()
		{
			timestamp = DateTime.Now;
		}
		public int Id { get; set; }
		public string FeedItemId {get; set;}
		private DateTimeOffset timestamp;
		public string Url { get; set; }
		public DateTime FetchTime { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
        public string Category { get; set; }
        public FeedType FeedType { get; set; }
		public int FeedSourceId { get; set; }
		public FeedSource FeedSource { get; set; }

	}
}
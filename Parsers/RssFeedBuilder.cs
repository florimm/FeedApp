using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FeedApp.Models;

namespace FeedApp.Parsers
{
	public class RssFeedBuilder : IFeedParser
	{

		private XDocument doc;

		public RssFeedBuilder(XDocument d)
		{
			doc = d;
		}

		public List<NewsItem> Create(int feedSourceId)
		{
			try
			{
				if (!doc.Elements().Any()) return null;

				XNamespace ns = "http://purl.org/rss/1.0/modules/slash/";

				List<NewsItem> items = (from item in doc.Descendants("item")
										select new NewsItem
										{
											FeedItemId = (item.Element("guid") != null ? item.Element("guid").Value : item.Element("link").Value),
											Title = item.Element("title").Value,
											Timestamp = DateHelper.Parse(item.Element("pubDate").Value ?? DateTime.Now.ToString()),
											Url = item.Element("link").Value,
											Description = (item.Element("description").Value ?? ""),
                                            Category = (item.Element("category") != null ? item.Element("category").Value : ""),
                                            FeedSourceId = feedSourceId,
											FetchTime = DateTime.Now.ToUniversalTime(),
											FeedType = FeedType.RSS,
										}).ToList();

				return items;
			}
			catch
			{
				return null;
			}
		}
	}
}